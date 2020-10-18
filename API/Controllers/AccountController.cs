using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private const string RegisterUser = "register";
        private const string UserLogin = "login";
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        // http://localhost:5000/api/Account/register
        [HttpPost(RegisterUser)]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.UserName
            };

            // Store user data in AspNetUsers database table
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return Ok(new UserDto {

                UserName= user.UserName,
                AccessToken= _tokenService.CreateToken(user)

                });
            }
            else
            {
                return Ok(result.Errors);
            }
        }

        
        [HttpPost(UserLogin)]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                     loginDto.UserName, loginDto.Password, loginDto.RememberMe, false);

            if (result.Succeeded)
            {
               var user= new AppUser 
               { 
                   UserName= loginDto.UserName,
                   Email = loginDto.UserName
               };

                return Ok(new UserDto 
                {

                UserName= user.UserName,
                AccessToken= _tokenService.CreateToken(user)

                });
            }
            else
            {
                return Ok();
            }
        }
    }
}