using ECCMS.Core.Enums;

namespace ECCMS.Api.Dtos
{
    public class InquiryPostDto 
    {

        public int UserId { get; set; }

        public int InstitutionId { get; set; }

        public int BranchId { get; set; }

        public int CrimeTypeId { get; set; }

        public InquiryStatus Status { get; set; } = InquiryStatus.Reviewing;

        public string InquiryEntry { get; set; } = string.Empty;

        public string? UserAttachment { get; set; }


    }
}
