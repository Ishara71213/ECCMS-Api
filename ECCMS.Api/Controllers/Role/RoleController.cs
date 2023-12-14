using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ECCMS.Api.Controllers
{
    public class RoleController : CommonController<RoleController>
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<RoleDto>> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            var roleDtos = _mapper.Map<List<RoleDto>>(roles);
            return roleDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RolePostDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Role>(model);
            item.CreatedBy = access!.UserId;
            item.InstitutionId = access!.CompanyId;
            await _roleService.AddAsync(item);

            return CreatedAtAction("GetAll", new { id = item.Id }, _mapper.Map<RoleDto>(item));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, RolePostDto model)
        {
            var item = await _roleService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Role Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.Name = model.Name;
            item.CanView = model.CanView;
            item.CanEdit = model.CanEdit;
            item.CanDelete = model.CanDelete;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            await _roleService.UpdateAsync(item);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _roleService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Role Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.IsDeleted = true;
            item.DeletedBy = access!.UserId;
            item.DeletedOn = DateTime.UtcNow;
            
            await _roleService.UpdateAsync(item);
            return Ok();
        }
    }
}
