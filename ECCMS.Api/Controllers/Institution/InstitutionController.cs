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
    
    public class InstitutionController : CommonController<InstitutionController>
    {
        private readonly IMapper _mapper;
        private readonly IInstitutionService _institutionService;
        public InstitutionController(IInstitutionService institutionService, IMapper mapper)
        {
            _institutionService = institutionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _institutionService.GetAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<InstitutionDto>>(items));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _institutionService.GetByIdAsync(id);
            Institution result = _mapper.Map<Institution>(item);

            return result != null ? Ok(result) : BadRequest("Invalid Institution Id");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(InstitutionDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Institution>(model);
            item.CreatedBy = access!.UserId;
            await _institutionService.AddAsync(item);

            return Created("GetAll", _mapper.Map<InstitutionDto>(item));
        }
    }
}
