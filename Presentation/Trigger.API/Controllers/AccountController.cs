using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trigger.Domain.Entities;
using Trigger.Domain.Entities.Models;

namespace Trigger.API.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("api/identity/login")]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
        [HttpPost]
        [Route("api/identity/login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if(result.Succeeded)
            {
                return(Ok(model));
            }
            else
            {
                return BadRequest("Wrong Parameter");
            }
        }
        [HttpGet]
        [Route("api/identity/register")]

        public async Task<ActionResult> Register()
        {
            return Ok();
        }
        [HttpPost]
        [Route("api/identity/register")]
        public async Task<Object> Register(RegisterModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                return Ok(result);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    }
}
