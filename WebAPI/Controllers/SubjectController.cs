using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Subjects;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IAuthoziService _authoziService;

        public SubjectController(ISubjectService subjectService, IAuthoziService authoziService)
        {
            _subjectService = subjectService;
            _authoziService = authoziService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterSubject option)
        {
            await _authoziService.IsAuthozi(HttpContext);

            ApiResult res = new ApiSuccessResult();
            IEnumerable<SubjectGetAllDto> subjects = await _subjectService.GetAll(option);
            res = new ApiSuccessResult<IEnumerable<SubjectGetAllDto>>(subjects)
            {
                TotalRecordsCount = TotalRecords.SUBJECT
            };
            return Ok(res);
        }

    }
}
