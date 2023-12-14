using ECCMS.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using AutoMapper;
using ECCMS.Core.Interfaces.IServices;

namespace ECCMS.Api.Controllers
{
    
    public class UserController : CommonController<UserController>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
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
            //return _mapper.Map<IReadOnlyList<ProductDto>>(items);
            return Ok(item);
        }

        [HttpGet("type:int")]
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
