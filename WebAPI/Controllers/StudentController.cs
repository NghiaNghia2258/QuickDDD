﻿using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
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
}
