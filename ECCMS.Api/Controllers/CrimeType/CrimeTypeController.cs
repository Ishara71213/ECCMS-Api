using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECCMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeTypeController : CommonController<CrimeTypeController>
    {
        private readonly IMapper _mapper;
        private readonly ICrimeTypeService _crimeTypeService;
        public CrimeTypeController(ICrimeTypeService crimeTypeService, IMapper mapper)
        {
            _crimeTypeService = crimeTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<CrimeTypeDto>> GetAll()
        {
            var CrimeTypes = await _crimeTypeService.GetAllAsync();
            var crimeTypeDtos = _mapper.Map<List<CrimeTypeDto>>(CrimeTypes);
            return crimeTypeDtos;
        }

        [HttpGet("GetAllByInstitution/{id:int}")]
        public async Task<IReadOnlyList<CrimeTypeDto>> GetAllByInstitutionId(int id)
        {
            var branches = await _crimeTypeService.GetAllAsync();
            var filteredCrimeTypes = branches.Where(item => item!.InstitutionId == id).ToList();
            var branchDtos = _mapper.Map<List<CrimeTypeDto>>(filteredCrimeTypes);
            return branchDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CrimeTypePostDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<CrimeType>(model);
            item.CreatedBy = access!.UserId;
            item!.InstitutionId = access!.InstutionId;
            await _crimeTypeService.AddAsync(item);

            return CreatedAtAction("GetAll", new { id = item.Id }, _mapper.Map<CrimeTypeDto>(item));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CrimeTypePostDto model)
        {
            var item = await _crimeTypeService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Crime Type Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.Name = model.Name;
            item.Description = model.Description;
            item.CrimeLevel = model.CrimeLevel;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            await _crimeTypeService.UpdateAsync(item);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _crimeTypeService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Branch Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.IsDeleted = true;
            item.DeletedBy = access!.UserId;
            item.DeletedOn = DateTime.UtcNow;

            await _crimeTypeService.UpdateAsync(item);
            return Ok();
        }
    }
}
