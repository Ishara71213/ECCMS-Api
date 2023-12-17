using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Application.Services;
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using ECCMS.Core.Enums;

namespace ECCMS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CommonController<CityController>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthController(SignInManager<User> signInManager, IEmployeeService employeeService, IConfiguration configuration, IUserService userService, IRoleService roleService, IMapper mapper) 
        {
            _signInManager = signInManager;
            _userService = userService;
            _employeeService = employeeService;
            _roleService = roleService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.GetByUsernameAsync(loginDto.Username);
            if (user == null) return NotFound("User Not Found");

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            if (!result.Succeeded) return Unauthorized();

            if (user.Type == UserType.Employee)
            {
                var employee = await _employeeService.GetByUserIdAsync(user.Id);
                if (employee == null) return NotFound("Employee Not Found");

                var role = await _roleService.GetByIdAsync(employee.RoleId);
                if (role == null) return NotFound("Roles Not Found");




                List<Claim> claims = new List<Claim>();
                claims = new List<Claim>
                 {
                    new(ClaimTypes.Name, user.UserName!),
                    new(ClaimTypes.Email, user.Email!),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Role, role.Name!),
                    new Claim(type: "UserId", value: user!.Id.ToString()),
                    new Claim(type: "EmployeeId", value: user!.Id.ToString()),
                    new Claim(type: "InstutionId", value: role.InstitutionId.ToString()),
                    new Claim(type: "BranchId", value: employee!.BranchId.ToString()),
                    new Claim(type: "RoleId", value: employee!.RoleId.ToString()),
                    new Claim(type: ClaimTypes.GivenName, value: user.FirstName),
                    new Claim(type: ClaimTypes.Surname, value: user.LastName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"] ?? string.Empty));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken
                (
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:DurationInHours"]!)),
                    signingCredentials: credentials
                );


                var response = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    role = role,
                    firstName = user.FirstName,  // Include first name in the response
                    lastName = user.LastName,    // Include last name in the response
                };
                return Ok(response);
            }
            else
            {
               
                var role = await _roleService.GetByNameAsync("GUEST");
                if (role == null) return NotFound("Roles Not Found");

                List<Claim> claims = new List<Claim>();
                claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName!),
                    new(ClaimTypes.Email, user.Email!),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Role, role.Name!),
                    new Claim(type: "UserId", value: user!.Id.ToString()),
                    new Claim(type: "RoleId", value: role!.Id.ToString()),
                    new Claim(type: ClaimTypes.GivenName, value: user.FirstName),
                    new Claim(type: ClaimTypes.Surname, value: user.LastName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"] ?? string.Empty));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken
                (
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:DurationInHours"]!)),
                    signingCredentials: credentials
                );


                var response = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    role = role,
                    firstName = user.FirstName,  // Include first name in the response
                    lastName = user.LastName,    // Include last name in the response
                };
                return Ok(response);
            }

            
        }
    }
}
