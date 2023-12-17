using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Application.Services;
using ECCMS.Core.Entities;
using ECCMS.Core.Enums;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECCMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : CommonController<CityController>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(UserManager<User> userManager, IEmployeeService employeeService, IUserService userService, IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _roleRepository = roleRepository;
            _userManager = userManager;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _employeeService.GetAllAsync();
            if (item == null)
            {
                return BadRequest("Some error occured");
            }
            return Ok(_mapper.Map<EmployeeDto>(item));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _employeeService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Member Not Found");
            }
            return Ok(_mapper.Map<EmployeeDto>(item));
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto model)
        {
            var isUsernameNoExist = await _userService.IsUsernameNoExists(0, model.Email);
            if (isUsernameNoExist)
            {
                return BadRequest("Username Already Exist");
            }

            var isEmailExist = await _userService.IsEmailExists(UserType.Employee, 0, model.Email);
            if (isEmailExist)
            {
                return BadRequest("Email Already Exist");
            }

            var access = HttpContext.Items["Access"] as AccessDto;

            var user = _mapper.Map<User>(model);
            user.Type = UserType.Employee;
            //user.CreatedBy = access!.UserId;

            var userResult = await _userService.AddUser(user, model.RoleId,"");
            if (userResult != null)
            {
                var employee = _mapper.Map<Employee>(model);
                employee.UserId = userResult.User.Id;
                //employee.CreatedBy = access!.UserId;
                await _employeeService.AddAsync(employee);
                return CreatedAtAction("GetAll", _mapper.Map<EmployeeDto>(employee));
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeDto model)
        {
            var item = await _employeeService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Employee Not Found");
            }

            item.Designation = model.Designation;
            item.RoleId = model.RoleId;
            item.BranchId = model.BranchId;
            item.ChangePassword = model.ChangePassword;

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;

            await _employeeService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _employeeService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Employee Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.DeletedBy = access!.UserId;
            item.DeletedOn = DateTime.UtcNow;
            item.IsDeleted = true;

            await _employeeService.UpdateAsync(item);
            return NoContent();
        }

    }
}
