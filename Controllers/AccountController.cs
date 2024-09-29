using BejelentkezesWebAPI.DTOs;
using BejelentkezesWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BejelentkezesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AccountUser> userManager,
                                    RoleManager<IdentityRole> roleManager,
                                    IConfiguration config) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDTO)
        {
            var newUser = new AccountUser()
            {
                FirstName = registerDTO.Firstname,
                LastName = registerDTO.Lastname,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password,
                UserName = registerDTO.Email.Split('@')[0]
            };

           
            var createUser = await userManager.CreateAsync(newUser, registerDTO.Password);
            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return Ok("Admin user created.");
            }

            var checkUser = await roleManager.FindByNameAsync("User");
            if (checkUser is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
            }

            await userManager.AddToRoleAsync(newUser, "User");
            return Ok("User created.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            return Ok();
        }

    }
}
