using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Application.Services;
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECCMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : CommonController<BranchController>
    {
        private readonly IMapper _mapper;
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<BranchDto>> GetAll()
        {
            var branches = await _branchService.GetAllAsync();
            var branchDtos = _mapper.Map<List<BranchDto>>(branches);
            return branchDtos;
        }

        [HttpGet("GetAllByInstitution/{id:int}")]
        public async Task<IReadOnlyList<BranchDto>> GetAllByInstitutionId(int id)
        {
            var branches = await _branchService.GetAllAsync();
            var filteredBranches = branches.Where(item => item!.InstitutionId == id).ToList();
            var branchDtos = _mapper.Map<List<BranchDto>>(filteredBranches);
            return branchDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BranchDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Branch>(model);
            item.CreatedBy = access!.UserId;
            item!.InstitutionId = access!.InstutionId;
            await _branchService.AddAsync(item);

            return CreatedAtAction("GetAll", new { id = item.Id }, _mapper.Map<BranchDto>(item));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BranchDto model)
        {
            var item = await _branchService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Branch Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.Name = model.Name;
            item.Address = model.Address;
            item.PhoneNumber = model.PhoneNumber;
            item.EmailAddress = model.EmailAddress;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            await _branchService.UpdateAsync(item);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _branchService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Branch Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.IsDeleted = true;
            item.DeletedBy = access!.UserId;
            item.DeletedOn = DateTime.UtcNow;

            await _branchService.UpdateAsync(item);
            return Ok();
        }
    }
}
