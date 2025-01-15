using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Faculties;
using WebApi.BLL.Mapper.Majors;
using WebApi.Domain.ApiResult;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IAuthoziService _authoziService;
        private readonly IFacultyService _faultyService;

        public FacultyController(IAuthoziService authoziService, IFacultyService faultyService)
        {
            _authoziService = authoziService;
            _faultyService = faultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _faultyService.GetAll();
            res = new ApiSuccessResult<List<GetAllFacultyDto>>(data);
            return Ok(res);
        }
        [HttpGet("get-marjors-by-id/{id:int}")]
        public async Task<IActionResult> GetMajorsById(int id)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _faultyService.GetMajorsById(id);
            res = new ApiSuccessResult<IEnumerable<GetMajorsByFacultyIdDto>>(data);
            return Ok(res);
        }
    }
 
}
