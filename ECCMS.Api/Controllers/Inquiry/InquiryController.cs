using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;
using ECCMS.Core.Enums;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ECCMS.Api.Controllers
{
   
    public class InquiryController : CommonController<InquiryController>
    {
        private readonly IMapper _mapper;
        private readonly IInquiryService _inquiryService;
        private readonly ICrimeTypeService _crimeTypeService;
        public InquiryController(IInquiryService inquiryService, ICrimeTypeService crimeTypeService, IMapper mapper)
        {
            _inquiryService = inquiryService;
            _crimeTypeService = crimeTypeService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var inquiry = await _inquiryService.GetByIdAsync(id);
            if (inquiry == null)
            {
                return BadRequest("No Inquiry for this Id");
            }
            var inquiryDto = _mapper.Map<InquiryDto>(inquiry);
            var crimeType = await _crimeTypeService.GetByIdAsync(inquiry!.CrimeTypeId);
            inquiryDto.CrimeTypeName = crimeType!.Name;
            return Ok(inquiryDto);
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
            var inquiries = await _inquiryService.GetAllWithCrimeTypeAsync();
            var filteredList = inquiries.Where(item => item!.InstitutionId == id).ToList();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(filteredList);
            return inquiryDtos;
        }

        [HttpGet("GetAllByUser/{id:int}")]
        public async Task<IReadOnlyList<InquiryDto>> GetAllByUserId(int id)
        {
            var inquiries = await _inquiryService.GetAllWithCrimeTypeAsync();
            var filteredList = inquiries.Where(item => item.UserId == id).ToList();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(filteredList);
            return inquiryDtos;
        }

        [HttpGet("GetAllByEmployee/{id:int}")]
        public async Task<IReadOnlyList<InquiryDto>> GetAllByEmployeeId(int id)
        {
            var inquiries = await _inquiryService.GetAllWithCrimeTypeAsync();
            var filteredList = inquiries.Where(item => item.EmployeeId == id).ToList();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(filteredList);
            return inquiryDtos;
        }

        [HttpGet("GetAllByBranch/{id:int}")]
        public async Task<IReadOnlyList<InquiryDto>> GetAllByBranchId(int Id)
        {
            var inquiries = await _inquiryService.GetAllWithCrimeTypeAsync();
            var filteredList = inquiries.Where(item => item.BranchId == Id).ToList();
            var inquiryDtos = _mapper.Map<List<InquiryDto>>(filteredList);
            return inquiryDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Add(InquiryPostDto model)
        {
            var access = HttpContext.Items["Access"] as AccessDto;
            var item = _mapper.Map<Inquiry>(model);
            item.CreatedBy = access!.UserId;
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                item.EmployeeId = 3;
                item.TicketId = await _inquiryService.GenerateTicketId();
                await _inquiryService.AddAsync(item);

                scope.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception("Add Inquiry: " + ex.Message);
            }
            

            return CreatedAtAction("GetAll", _mapper.Map<InquiryDto>(item));
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
