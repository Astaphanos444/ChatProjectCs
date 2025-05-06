using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using app.src.Dto;
using app.src.Model;
using app.src.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace app.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService, UserManager<User> userManager, SignInManager<User> signInManager) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User?>> Register([FromBody] UserDto request)
        {
            var appUser = new User
            {
                UserName = request.UserName
            };

           var user =  await userManager.CreateAsync(appUser, request.Password);
            if(user.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded) { return Ok(); }
                    else{ return StatusCode(500, roleResult.Errors); }
                }
            else{ return StatusCode(500, user.Errors); }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto request)
        {  
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower());
            if(user == null) return Unauthorized("Invalid UserName!");
            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if(!result.Succeeded) return Unauthorized("UserName notFound and/or Password Incorrect"); 

            var token = await authService.LoginAsync(request);

            if(token == null){ return BadRequest("Invalid Credentials");}

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are Authenticated!");
        }
    }
}