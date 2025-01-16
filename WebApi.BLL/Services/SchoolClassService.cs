using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class SchoolClassService : ServiceBase, ISchoolClassService
{
    public SchoolClassService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<IEnumerable<GetAllSchoolClassDto>> GetAll(OptionFilterSchoolClass option)
    {
        IEnumerable<SchoolClass> schoolClasses = await _unitOfWork.SchoolClass.GetAll(option);
        return _mapper.Map<IEnumerable<GetAllSchoolClassDto>>(schoolClasses);
    }
    public async Task<GetByIdSchoolClassDto> GetById(int id)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(id);
        return _mapper.Map<GetByIdSchoolClassDto>(schoolClass);
    }
    public async Task<bool> Update(GetByIdSchoolClassDto model)
    {
        SchoolClass schoolClass = _mapper.Map<SchoolClass>(model);
        await _unitOfWork.SchoolClass.Update(schoolClass);  
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        await _unitOfWork.SchoolClass.Delete(id);
        return true;
    }
    public async Task AddStudentsToClass(AddStudentsToClassDto model)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(model.SchoolClassId);
        if(schoolClass == null)
        {
            return;
        }
        foreach (var item in model.StudentIds)
        {
            schoolClass.Students.Add(new SchoolClassStudent()
            {
                StudentsId = item,
                SchoolClassesId = schoolClass.Id
            });
        }
        await _unitOfWork.SchoolClass.Update(schoolClass);
    }
    public async Task RemoveStudentFromClass(int studentId, int schoolClassId)
    {
        await _unitOfWork.SchoolClassesStudent.Delete(studentId, schoolClassId);
    }
}
