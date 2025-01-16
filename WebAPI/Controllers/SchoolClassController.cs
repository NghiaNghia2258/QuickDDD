using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly IAuthoziService _authoziService;
        private readonly ISchoolClassService _schoolClassService;

        public SchoolClassController(IAuthoziService authoziService, ISchoolClassService schoolClassService)
        {
            _authoziService = authoziService;
            _schoolClassService = schoolClassService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterSchoolClass option)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _schoolClassService.GetAll(option);
            res = new ApiSuccessResult<IEnumerable<GetAllSchoolClassDto>>(data)
            {
                TotalRecordsCount = TotalRecords.SCHOOL_CLASS
            };
            return Ok(res);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ApiResult res = new ApiSuccessResult();

            var data = await _schoolClassService.GetById(id);
            res = new ApiSuccessResult<GetByIdSchoolClassDto>(data);
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResult res = new ApiSuccessResult();

            var data = await _schoolClassService.Delete(id);
            res = new ApiSuccessResult<bool>(data);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GetByIdSchoolClassDto model)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _schoolClassService.Update(model);
            res = new ApiSuccessResult<bool>(data);
            return Ok(res);
        }
        [HttpPost("add-students-to-class")]
        public async Task<IActionResult> AddStudentsToClass(AddStudentsToClassDto model)
        {
            ApiResult res = new ApiSuccessResult();
            return Ok(res);
        }
    }
}
