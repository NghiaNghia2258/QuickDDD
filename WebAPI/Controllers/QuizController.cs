using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Quiz;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IAuthoziService _authoziService;

        public QuizController(IQuizService quizService, IAuthoziService authoziService)
        {
            _quizService = quizService;
            _authoziService = authoziService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterQuiz option)
        {
            await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_QUIZ);

            ApiResult res = new ApiSuccessResult();
            IEnumerable<QuizGetAllDto> quizzes = await _quizService.GetAll(option);
            res = new ApiSuccessResult<IEnumerable<QuizGetAllDto>>(quizzes)
            {
                TotalRecordsCount = TotalRecords.QUIZ
            };
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_QUIZ);

            ApiResult res = new ApiSuccessResult();
            QuizDto quiz = await _quizService.GetById(id);
            res = new ApiSuccessResult<QuizDto>(quiz);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuizDto model)
        {
            await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.CREATE_QUIZ);

            ApiResult res = new ApiSuccessResult();
            bool isSuccess = await _quizService.Add(model, HttpContext);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] QuizDto model)
        {
            await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.UPDATE_QUIZ);

            ApiResult res = new ApiSuccessResult();
            bool isSuccess = await _quizService.Update(model, HttpContext);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.DELETE_QUIZ);

            ApiResult res = new ApiSuccessResult();
            bool isSuccess = await _quizService.Delete(id, HttpContext);
            return Ok(res);
        }
    }
}
