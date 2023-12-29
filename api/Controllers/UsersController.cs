using api.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]/me")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(UserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserProfile()
        {
            var result = await userService.GetUserProfile("tmp");
            return Ok(result);
        }

        private readonly UserService userService;
    }
}
