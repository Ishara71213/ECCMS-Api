using ECCMS.Core.Enums;

namespace ECCMS.Api.Dtos
{
    public class InquiryResponseDto 
    {
        public int Id { get; set; }

        public InquiryStatus Status { get; set; } = InquiryStatus.Reviewing;

        public string? Attachment { get; set; }

        public string? Response { get; set; }

    }
}
