using Microsoft.AspNetCore.Http;
using WebApi.BLL.Mapper.Students;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface IStudentService
{
    Task<bool> Create(CreateStudentDto model);
    Task<bool> Delete(int id);
    Task<IEnumerable<GetAllStudentDto>> GetAll(OptionFilterStudent option);
    Task<GetByIdStudentDto> GetById(int id);
    Task<bool> ImportFileExcel(IFormFile file);
    Task<bool> Update(UpdateStudentDto model);
}
