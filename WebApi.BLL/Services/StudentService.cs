using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Collections;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class StudentService : ServiceBase, IStudentService
{
    public StudentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<bool> Create(CreateStudentDto model)
    {
        Student newStudent = _mapper.Map<Student>(model);

        int ordinal = await _unitOfWork.Student.GetOrdinalNumberOfCurrentYear();
        newStudent.Code = $"{model.MajorCode}_{TimeConst.CurrentYear}_{ordinal:D3}";
        newStudent.EnrollmentYear = TimeConst.CurrentYear;

        SchoolClass schoolClassAvaiableSlot = await _unitOfWork.SchoolClass.GetOneClassesByMajorIdWithAvailableSlot(model.MajorId);
        if (schoolClassAvaiableSlot == null)
        {
            int countSchoolClass = await _unitOfWork.Major.CountClassesByIdInCurrentYear(model.MajorId);
            schoolClassAvaiableSlot = new SchoolClass()
            {
                Code = $"{model.MajorCode}_{TimeConst.CurrentYear}_{countSchoolClass++:D2}",
                MajorId = model.MajorId,
            };
            await _unitOfWork.SchoolClass.Create(schoolClassAvaiableSlot);
        }
        newStudent.SchoolClasses.Add(schoolClassAvaiableSlot);

        RoleGroup roleStudent = await _unitOfWork.Identity.GetRoleGroupByCode("STUDENT");

        UserLogin newUser = new UserLogin()
        {
            Username = newStudent.Code,
            Password = newStudent.Code,
            RoleGroupId = roleStudent.Id
        };

        newStudent.UserLogin = newUser;

        await _unitOfWork.Student.Create(newStudent);
        return true;
    }
    public async Task<bool> ImportFileExcel(IFormFile file)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var stream = file.OpenReadStream())
        using (var package = new ExcelPackage(stream))
        {
            ExcelWorksheet? worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                return false;
            }
            int ordinal = await _unitOfWork.Student.GetOrdinalNumberOfCurrentYear();

            int totalRows = worksheet.Dimension.Rows;
            int totalColumns = worksheet.Dimension.Columns;
            Dictionary<string, List<Student>> pairsStudentSortByMajor = new Dictionary<string, List<Student>>();
            Dictionary<string, SchoolClass> pairsClass = new Dictionary<string, SchoolClass>();
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    for (int row = 2; row <= totalRows; row++)
                    {
                        ordinal++;
                        Student newStudent = new Student()
                        {
                            Code = $"{worksheet.Cells[row, 6].Text}{TimeConst.CurrentYear}{ordinal:D3}",
                            FullName = worksheet.Cells[row, 2].Text,
                            Country = "Việt Nam",
                            City = worksheet.Cells[row, 3].Text,
                            Gender = worksheet.Cells[row, 4].Text,
                            EnrollmentYear = TimeConst.CurrentYear,
                            CreatedName = "Import from excel",
                            CreatedBy = "Excel",
                            UserLogin = new UserLogin()
                            {
                                Username = $"{worksheet.Cells[row, 6].Text}{TimeConst.CurrentYear}{ordinal:D3}",
                                Password = "123456",
                                RoleGroupId = 4
                            }
                        };
                        if (pairsClass.TryGetValue(worksheet.Cells[row, 5].Text, out SchoolClass schoolClass))
                        {
                            if (schoolClass.AvailableSlots > 0)
                            {
                                newStudent.SchoolClasses.Add(schoolClass);
                                schoolClass.AvailableSlots--;
                            }
                            else
                            {
                                schoolClass.IsAvailableSlot = false;
                                int ordinalClass = await _unitOfWork.Major.CountClassesByIdInCurrentYear(int.Parse(worksheet.Cells[row, 5].Text));
                                ordinalClass++;
                                SchoolClass newSchoolClass = new SchoolClass()
                                {
                                    Code = $"{worksheet.Cells[row, 6].Text}_{TimeConst.CurrentYear}_{ordinalClass:D2}",
                                    MajorId = int.Parse(worksheet.Cells[row, 5].Text)
                                };
                                await _unitOfWork.SchoolClass.Create(newSchoolClass);
                                pairsClass.Remove(worksheet.Cells[row, 5].Text);
                                pairsClass.TryAdd(worksheet.Cells[row, 5].Text, newSchoolClass);
                                newStudent.SchoolClasses.Add(newSchoolClass);
                                newSchoolClass.AvailableSlots--;
                            }
                        }
                        else
                        {
                            int ordinalClass = await _unitOfWork.Major.CountClassesByIdInCurrentYear(int.Parse(worksheet.Cells[row, 5].Text));
                            ordinalClass++;
                            SchoolClass newSchoolClass = new SchoolClass()
                            {
                                Code = $"{worksheet.Cells[row, 6].Text}_{TimeConst.CurrentYear}_{ordinalClass:D2}",
                                MajorId = int.Parse(worksheet.Cells[row, 5].Text)
                            };
                            await _unitOfWork.SchoolClass.Create(newSchoolClass);
                            pairsClass.Remove(worksheet.Cells[row, 5].Text);
                            pairsClass.TryAdd(worksheet.Cells[row, 5].Text, newSchoolClass);
                            newStudent.SchoolClasses.Add(newSchoolClass);
                            newSchoolClass.AvailableSlots--;
                        }
                        if (pairsStudentSortByMajor.TryGetValue(worksheet.Cells[row, 5].Text, out List<Student>? students))
                        {
                            students.Add(newStudent);
                        }
                        else
                        {
                            students = new List<Student>() { newStudent };
                            pairsStudentSortByMajor.TryAdd(worksheet.Cells[row, 5].Text, students);
                        }
                    }
                    List<Student> newStudents = new List<Student>();
                    foreach (List<Student> item in pairsStudentSortByMajor.Values)
                    {
                        newStudents.AddRange(item);
                    }
                    await _unitOfWork.Student.CreateListStudent(newStudents);
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
        return true;
    }
    public async Task<IEnumerable<GetAllStudentDto>> GetAll(OptionFilterStudent option)
    {
        List<Student> students = await _unitOfWork.Student.GetAll(option);
        return _mapper.Map<IEnumerable<GetAllStudentDto>>(students);
    }
    public async Task<bool> Update(UpdateStudentDto model)
    {
        Student student = _mapper.Map<Student>(model);
        await _unitOfWork.Student.Update(student);
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        await _unitOfWork.Student.Delete(id);
        return true;
    }
    public async Task<GetByIdStudentDto> GetById(int id)
    {
        Student student = await _unitOfWork.Student.GetById(id);
        return _mapper.Map<GetByIdStudentDto>(student);
    }
}
