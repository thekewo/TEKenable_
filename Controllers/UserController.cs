using Microsoft.AspNetCore.Mvc;

namespace TEKenable_Newsletter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("submit")]
        public IActionResult SubmitNewsletterAsync(
            [FromQuery]
            string email,
            [FromQuery]
            string contactSource,
            [FromQuery]
            string contactReason
            )
        {
            var result = new SingleJsonResult<bool>();
            try
            {
                result.Result = _userService.SubmitNewsLetter(email, contactSource, contactReason);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Result = false;
                result.Success = true;
                result.Message = e.Message;
                _logger.LogError(e, e.Message, e.StackTrace);
            }

            return Ok(result);
        }

        [HttpGet("checkemail")]
        public IActionResult IsEmailInDatabase(
            [FromQuery]
            string email
            )
        {
            var result = new SingleJsonResult<bool>();
            try
            {
                result.Result = _userService.IsEmailInDatabase(email);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Result = false;
                result.Success = true;
                result.Message = e.Message;
                _logger.LogError(e, e.Message, e.StackTrace);
            }

            return Ok(result);
        }
    }
}