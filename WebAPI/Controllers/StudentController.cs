using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
using WebApi.BLL.Mapper.Teachers;
using WebApi.BLL.Services;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IAuthoziService _authoziService;
    private readonly IStudentService _studentService;

    public StudentController(IAuthoziService authoziService, IStudentService studentService)
    {
        _authoziService = authoziService;
        _studentService = studentService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] OptionFilterStudent option)
    {
        ApiResult res = new ApiSuccessResult();
        var data = await _studentService.GetAll(option);
        res = new ApiSuccessResult<IEnumerable<GetAllStudentDto>>(data)
        {
            TotalRecordsCount = TotalRecords.STUDENT
        };
        return Ok(res);
    }
    [HttpGet("get-by-class-id")]
    public async Task<IActionResult> GetStudentsByClassId([FromQuery] int schoolClassId)
    {
        ApiResult res = new ApiSuccessResult();
        var data = await _studentService.GetStudentsByClassId(schoolClassId);
        res = new ApiSuccessResult<IEnumerable<GetAllStudentDto>>(data)
        {
            TotalRecordsCount = TotalRecords.STUDENT
        };
        return Ok(res);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto model)
    {
        ApiResult res = new ApiSuccessResult();
        await _studentService.Create(model);
        return Ok(res);
    }
    [HttpPost("import-excel")]
    public async Task<IActionResult> ImportExcel(IFormFile file)
    {
        ApiResult res = new ApiSuccessResult();
        await _studentService.ImportFileExcel(file);
        return Ok(res);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResult res = new ApiSuccessResult();

        var data = await _studentService.GetById(id);
        res = new ApiSuccessResult<GetByIdStudentDto>(data);
        return Ok(res);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResult res = new ApiSuccessResult();

        var data = await _studentService.Delete(id);
        res = new ApiSuccessResult<bool>(data);
        return Ok(res);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentDto model)
    {
        ApiResult res = new ApiSuccessResult();
        var data = await _studentService.Update(model);
        res = new ApiSuccessResult<bool>(data);
        return Ok(res);
    }
    [HttpGet("get-grades/{id}")]
    public async Task<IActionResult> GetGradeById(int id)
    {
        ApiResult res = new ApiSuccessResult();
        var data = await _studentService.GetGradeById(id);
        res = new ApiSuccessResult<IEnumerable<StudentGradeDto>>(data);
        return Ok(res);
    }
}
