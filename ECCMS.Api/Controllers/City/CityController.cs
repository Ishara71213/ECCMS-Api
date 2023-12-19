using AutoMapper;
using ECCMS.Core.Interfaces.IServices;
using ECCMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ECCMS.Api.Dtos;
using ECCMS.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace ECCMS.Api.Controllers
{
    public class CityController : CommonController<CityController>
    {
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _cityService.GetAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<CityDto>>(items));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CityDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<City>(model);
            item.CreatedBy = access!.UserId;
            await _cityService.AddAsync(item);

            return Created("GetAll", _mapper.Map<CityDto>(item));
        }
    }
}
