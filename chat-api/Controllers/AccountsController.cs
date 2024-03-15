using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("signin-google")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties()
            {
                RedirectUri = "http://localhost:4200"
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}
