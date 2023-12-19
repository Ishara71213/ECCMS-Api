using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ECCMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : CommonController<InquiryController>
    {
        private readonly IMapper _mapper;
        private readonly IInquiryService _inquiryService;
        public InquiryController(IInquiryService inquiryService, IMapper mapper)
        {
            _inquiryService = inquiryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<InquiryDto>> GetAll()
        {
            var inquiries = await _inquiryService.GetAllAsync();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(inquiries);
            return inquiryDtos;
        }

        [HttpGet("GetAllByInstitution/{id:int}")]
        public async Task<IReadOnlyList<InquiryDto>> GetAllByInstitutionId(int id)
        {
            var inquiries = await _inquiryService.GetAllAsync();
            var filteredList = inquiries.Where(item => item!.InstitutionId == id).ToList();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(filteredList);
            return inquiryDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Add(InquiryPostDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Inquiry>(model);
            item.CreatedBy = access!.UserId;
            await _inquiryService.AddAsync(item);

            return CreatedAtAction("GetAll", new { id = item.Id }, _mapper.Map<InquiryDto>(item));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BranchDto model)
        {
            var item = await _inquiryService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Inquiry Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            await _inquiryService.UpdateAsync(item);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _inquiryService.GetByIdAsync(id);
            if (item == null)
            {
                return BadRequest("Branch Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.IsDeleted = true;
            item.DeletedBy = access!.UserId;
            item.DeletedOn = DateTime.UtcNow;

            await _inquiryService.UpdateAsync(item);
            return Ok();
        }
    }
}
