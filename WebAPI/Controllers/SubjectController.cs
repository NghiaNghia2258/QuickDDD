using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Subjects;
using WebApi.Domain.ApiResult;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IAuthoziService _authoziService;
        private readonly ISubjectService _subjectService;
        public SubjectController(IAuthoziService authoziService, ISubjectService subjectService)
        {
            _authoziService = authoziService;
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterSubject option)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _subjectService.GetAll(option);
            res = new ApiSuccessResult<List<GetAllSubjectDto>>(data);
            return Ok(res);
        }
    }
}
