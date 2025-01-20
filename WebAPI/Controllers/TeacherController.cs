using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
using WebApi.BLL.Mapper.Teachers;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

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
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterTeacher option)
        {
            ApiResult res = new ApiSuccessResult();

            var data = await _teacherService.GetAll(option);
            res = new ApiSuccessResult<List<GetAllTeacherDto>>(data);
            return Ok(res);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ApiResult res = new ApiSuccessResult();

            var data = await _teacherService.GetById(id);
            res = new ApiSuccessResult<GetByIdTeacherDto>(data);
            return Ok(res);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResult res = new ApiSuccessResult();

            var data = await _teacherService.Delete(id);
            res = new ApiSuccessResult<bool>(data);
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GetByIdTeacherDto model)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _teacherService.Update(model);
            res = new ApiSuccessResult<bool>(data);
            return Ok(res);
        }
        [HttpGet("get-grade-by-classId-subjectId")]
        public async Task<IActionResult> GetStudentGradeByClassIDAndSubjectId(int classId,int subjectId)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _teacherService.GetStudentGradeByClassIDAndSubjectId(classId,subjectId);
            res = new ApiSuccessResult<IEnumerable<StudentGradeDto>>(data);
            return Ok(res);
        }
        [HttpPost("update-grade")]
        public async Task<IActionResult> UpdateGradeForStudent(UpdateStudentGradeDto model)
        {
            ApiResult res = new ApiSuccessResult();
            await _teacherService.UpdateGradeForStudent(model);
            return Ok(res);
        }
        [HttpGet("get-by-subjectId")]
        public async Task<IActionResult> GetBySubjectId(int subjectId)
        {
            ApiResult res = new ApiSuccessResult();
            var data = await _teacherService.GetBySubjectId(subjectId);
            res = new ApiSuccessResult<IEnumerable<GetAllTeacherDto>>(data);
            return Ok(res);
        }
    }
}
