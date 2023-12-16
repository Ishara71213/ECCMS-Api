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
            var userResponse = await _userService.AddUser(user, userDto.RoleId);

            return Ok(new { userDto.Email, userResponse.Password });
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
    }
}
