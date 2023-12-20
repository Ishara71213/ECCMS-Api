using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Enums;
using ECCMS.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECCMS.Api.Controllers
{
    public class InquiryResponseController : CommonController<InquiryController>
    {
        private readonly IMapper _mapper;
        private readonly IInquiryService _inquiryService;
        public InquiryResponseController(IInquiryService inquiryService, IMapper mapper)
        {
            _inquiryService = inquiryService;
            _mapper = mapper;
        }

        [HttpPut("AssignOfficer")]
        public async Task<IActionResult> AssignOficcer(InquiryAssignOfficerDto model)
        {
            var item = await _inquiryService.GetByIdAsync(model.Id);
            if (item == null)
            {
                return BadRequest("Inquiry Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            item.EmployeeId = model.EmployeeId;
            await _inquiryService.UpdateAsync(item);

            return Ok();
        }

        [HttpPut("StatusChange")]
        public async Task<IActionResult> StatusChange(InquiryAssignOfficerDto model)
        {
            var item = await _inquiryService.GetByIdAsync(model.Id);
            if (item == null)
            {
                return BadRequest("Inquiry Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            item.EmployeeId = model.EmployeeId;
            await _inquiryService.UpdateAsync(item);

            return Ok();
        }

        [HttpPut("InquiryResponse")]
        public async Task<IActionResult> InquiryResponse(InquiryResponseDto model)
        {
            var item = await _inquiryService.GetByIdAsync(model.Id);
            if (item == null)
            {
                return BadRequest("Inquiry Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            item.Status = model.Status;

            if (model.Status == InquiryStatus.AssignToOfficer)
            {
                item.AssignResponse = model.Response;
            }
            else if (model.Status == InquiryStatus.Investigating)
            {
                item.InvestigatingResponse = model.Response;
                item.InvestigatingAttachment = model.Attachment;
            }
            else if (model.Status == InquiryStatus.Complete)
            {
                item.CompleteResponse = model.Response;
            }
            else
            {
                return BadRequest("Invalid Status");
            }
            await _inquiryService.UpdateAsync(item);

            return Ok();
        }

        [HttpPut("Feedback")]
        public async Task<IActionResult> Feedback(InquiryFeedbackDto model)
        {
            var item = await _inquiryService.GetByIdAsync(model.Id);
            if (item == null)
            {
                return BadRequest("Inquiry Not Found");
            }

            var access = HttpContext.Items["Access"] as AccessDto;
            item.ModifiedBy = access!.UserId;
            item.ModifiedOn = DateTime.UtcNow;
            item.UserComment = model.UserComment;
            item.IsSatisfied = model.IsSatisfied;
            item.Rating = model.Rating;
            await _inquiryService.UpdateAsync(item);

            return Ok();
        }
    }
}
