using AutoMapper;
using ECCMS.Core.Interfaces.IServices;
using ECCMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ECCMS.Api.Dtos;

namespace ECCMS.Api.Controllers
{
    public class ProvinceController : CommonController<ProvinceController>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService, IMapper mapper)
        {
            _provinceService = provinceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _provinceService.GetAllAsync();
            return Ok(_mapper.Map<IReadOnlyList<ProvinceDto>>(items));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProvinceDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Province>(model);
            item.CreatedBy = access!.UserId;
            await _provinceService.AddAsync(item);

            return CreatedAtAction("GetAll", _mapper.Map<ProvinceDto>(item));
        }
    }
}
