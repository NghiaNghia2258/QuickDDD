using AutoMapper;
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

        int ordinal = await _unitOfWork.Student.GetOrdinalNumberByMajorIdOfCurrentYear(model.MajorId);
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

    public async Task<IEnumerable<GetAllStudentDto>> GetAll(OptionFilterStudent option)
    {
        List<Student> students = await _unitOfWork.Student.GetAll(option);
        return _mapper.Map<IEnumerable<GetAllStudentDto>>(students);
    }
}
