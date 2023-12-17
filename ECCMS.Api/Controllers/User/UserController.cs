using ECCMS.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using AutoMapper;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Infrastructure.Repositories;
using ECCMS.Application.Services;

namespace ECCMS.Api.Controllers
{
    
    public class UserController : CommonController<UserController>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IRoleRepository _roleRepository;
        public UserController(UserManager<User> userManager,IUserService userService, IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _roleRepository = roleRepository;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userResponse = await _userService.AddUser(user, userDto.RoleId, "");

            return Ok(new { userDto.Email, userResponse.Password });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterPostDto model)
        {
            string message = await ValidateUser(0, 0, model.MobileNo, model.Email);
            if (!string.IsNullOrEmpty(message))
            {
                return BadRequest(message);
            }

            #region User
           

            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.Email;
            user.Nic = model.Nic;
            user.Address = model.Address;
            user.MobileNo = model.MobileNo;
            user.Email = model.Email;
            user.Gender = model.Gender;
            user.Dob = model.Dob;
            user.Status = model.Status;
            user.Type = UserType.User;
            user.CreatedBy = user.Id;
            
            await _userService.AddUser(user, model.RoleId, model.Password);
            #endregion Member

            return Ok("User Created Successfully");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _userService.GetByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(item);
            var user = _mapper.Map<UserDto>(item);
            if (roles != null)
            {
                var role = await _roleRepository.GetByNameAsync(roles[0]);
                user.RoleId = role.Id;
            }
            
            return Ok(user);
        }

        [HttpGet("Type/{type:int}")]
        public async Task<IReadOnlyList<UserDto>> GetUsersByType(UserType type)
        {
            var users = await _userService.GetUserList(type);
            return _mapper.Map<IReadOnlyList<UserDto>>(users);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.RemoveUser(id);
            return Ok();
        }

        private async Task<string> ValidateUser(int memberId, int userId, string mobileNo, string email)
        {
            if (await _userService.IsMobileNoExists(UserType.User, userId, mobileNo))
            {
                return $"MobileNo '{mobileNo}' Already Exist";
            }

            if (await _userService.IsEmailExists(UserType.User, userId, email))
            {
                return $"Email '{email}' Already Exist";
            }

            return "";
        }
    }
}
