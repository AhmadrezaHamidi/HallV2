using System.Net;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tama.Data;
using tama.Domain.BaseDomain;
using tama.Domain.Entity;
using tama.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace tama.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserContoller : ControllerBase
    {
        private TamasaContext _tamasaContext;
        private IuserReposetory _userReposetory;
        private readonly ILogger<UserContoller> _logger;

        public UserContoller(TamasaContext tamasaContext, ILogger<UserContoller> logger, IuserReposetory userReposetory)
        {
            _tamasaContext = tamasaContext;
            _logger = logger;
            _userReposetory = userReposetory;
        }
        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data ");

            // if (!string.IsNullOrEmpty(input?.UserName) || !string.IsNullOrEmpty(input?.PhoneNumber)
            // || !string.IsNullOrEmpty(input?.Email) || !string.IsNullOrEmpty(input?.Password)
            // || !string.IsNullOrEmpty(input?.RepeatPassword))
            //     return BadRequest("Invalid data ");



            // if(input.Password != input.RepeatPassword );
            //     return BadRequest("the password in not match ");


            // if(input.Password.Length <9)
            //     return BadRequest("is not a strong password !");


            // if( !input.Email.Contains("@gmail.com") || !input.Email.Contains("@yahoo.com"));
            //     return BadRequest("this is not a email");

            var existUserEmail = _userReposetory.isExistByEmail(input.Email.ToLower());

            if (existUserEmail is true)
                return BadRequest("this is not a email");


            var existUserPhoneNumber = _userReposetory.isExistByPhoneNumber(input.PhoneNumber);


            if (existUserPhoneNumber is true)
                return BadRequest("this is not a email");


            // var existUser = _tamasaContext.CustomerTb.FirstOrDefault(x => x.UserName.Equals(input.UserName));


            // if(existUser != null)
            //     return BadRequest("this is not a email");


            var instance = new CustomerEntity(input.UserName, input.Email.ToLower(), input.PhoneNumber, input.Password);
            _userReposetory.AddUser(instance);
            return Ok(instance.Id);
        }



        [HttpGet]
        public IActionResult Login(LoginInWhiteEmailAddressPutDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var cus = _userReposetory.LogingWhiteEmail(input.emailAddress.ToLower(), input.Password);



            if (cus is null)
                return BadRequest();
            var claimes = new List<Claim>()
                {
                   new Claim(ClaimTypes.NameIdentifier,cus.Id),
                   new Claim(ClaimTypes.Name, cus.UserName)
                }; ///bara geterdtane etlate jari user va qara daadane bara cookie 
            var identity = new ClaimsIdentity(claimes, CookieAuthenticationDefaults.AuthenticationScheme);
            ///be system mifahmonim ke az che noyiaz ClimesIdentity estefade mikand  
            var principle = new ClaimsPrincipal(identity);
            var propertoes = new AuthenticationProperties()
            {
                IsPersistent = input.RememeberMe
            };
            HttpContext.SignInAsync(principle, propertoes);
            return Ok();
        }


        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}