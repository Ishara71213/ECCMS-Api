using ECCMS.Core.Entities;
using ECCMS.Core.Enums;

namespace ECCMS.Api.Dtos
{
    public class InquiryDto 
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int InstitutionId { get; set; }

        public int CrimeTypeId { get; set; }

        public string TicketId { get; set; } = string.Empty;

        public InquiryStatus Status { get; set; } = InquiryStatus.Reviewing;

        public string InquiryEntry { get; set; } = string.Empty;

        public string? UserAttachment { get; set; }

        public string? ReviewingResponse { get; set; }

        public string? AssignResponse { get; set; }

        public string? InvestigatingResponse { get; set; }

        public string? InvestigatingAttachment { get; set; }

        public string? CompleteResponse { get; set; }

        public string? UserComment { get; set; }

        public bool? IsSatisfied { get; set; }

        public int? Rating { get; set; }

        public virtual CrimeType? CrimeType { get; set; }

    }
}
