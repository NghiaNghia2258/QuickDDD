using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Teachers;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IAuthoziService _authoziService;
        private readonly ITeacherService _teacherService;

        public TeacherController(IAuthoziService authoziService, ITeacherService teacherService)
        {
            _authoziService = authoziService;
            _teacherService = teacherService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherDto model)
        {
           await _authoziService.IsAuthozi(role: RoleNameConst.CREATE_TEACHER);

            ApiResult res = new ApiSuccessResult();

            await _teacherService.Create(model);

            return Ok(res);
        } 
    }
}
