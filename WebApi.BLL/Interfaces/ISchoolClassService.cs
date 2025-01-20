using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ISchoolClassService
{
    Task AddStudentsToClass(AddStudentsToClassDto model);
    Task AddTeachersToClass(AddTeachersToClassDto model);
    Task<bool> Delete(int id);
    Task<IEnumerable<GetAllSchoolClassDto>> GetAll(OptionFilterSchoolClass option);
    Task<GetByIdSchoolClassDto> GetById(int id);
    Task RemoveStudentFromClass(int studentId, int schoolClassId);
    Task RemoveTeacher(int schoolClassId, int teacherId, int subjectId);
    Task<bool> Update(GetByIdSchoolClassDto model);
}
