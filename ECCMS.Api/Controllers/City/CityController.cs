using AutoMapper;
using ECCMS.Core.Interfaces.IServices;
using ECCMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ECCMS.Api.Dtos;

namespace ECCMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
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
    }
}
