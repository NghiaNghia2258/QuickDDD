using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
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
        if(schoolClassAvaiableSlot == null)
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
            List<Student> students = new List<Student>();
            for (int row = 2; row <= totalRows; row++) 
            {
                ordinal++;
                Student newStudent = new Student()
                {
                    Code = $"{worksheet.Cells[row, 6].Text}{TimeConst.CurrentYear}{ordinal:D3}",
                    FullName = worksheet.Cells[row,2].Text,
                    Country = "Việt Nam",
                    City = worksheet.Cells[row, 3].Text,
                    Gender = worksheet.Cells[row, 4].Text,
                    CreatedName = "Import from excel",
                    CreatedBy = "Excel",
                    UserLogin = new UserLogin()
                    {
                        Username = $"{worksheet.Cells[row, 6].Text}{TimeConst.CurrentYear}{ordinal:D3}",
                        Password = "123456",
                        RoleGroupId = 4
                    }
                };
                students.Add(newStudent);
            }
            await _unitOfWork.Student.CreateListStudent(students);
        }
        return true;
    }
    public async Task<IEnumerable<GetAllStudentDto>> GetAll(OptionFilterStudent option)
    {
        List<Student> students = await _unitOfWork.Student.GetAll(option);
        return _mapper.Map<IEnumerable<GetAllStudentDto>>(students);
    }
}
