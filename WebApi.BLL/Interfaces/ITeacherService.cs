using WebApi.BLL.Mapper.Students;
using WebApi.BLL.Mapper.Teachers;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ITeacherService
{
    Task<bool> Create(CreateTeacherDto model);
    Task<bool> Delete(int id);
    Task<List<GetAllTeacherDto>> GetAll(OptionFilterTeacher option);
    Task<GetByIdTeacherDto> GetById(int id);
    Task<IEnumerable<GetAllTeacherDto>> GetBySubjectId(int subjectId);
    Task<IEnumerable<StudentFeedBackDto>> GetFeedback(OptionFilterFeedback option);
    Task<IEnumerable<StudentGradeDto>> GetStudentGradeByClassIDAndSubjectId(int classId, int subjectId);
    Task<bool> Update(GetByIdTeacherDto model);
    Task UpdateGradeForStudent(UpdateStudentGradeDto model);
}
