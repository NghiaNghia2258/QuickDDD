using Microsoft.AspNetCore.Http;
using WebApi.BLL.Mapper.Students;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface IStudentService
{
    Task<bool> Create(CreateStudentDto model);
    Task<IEnumerable<GetAllStudentDto>> GetAll(OptionFilterStudent option);
    Task<bool> ImportFileExcel(IFormFile file);
}
