using ECCMS.Core.Enums;

namespace ECCMS.Api.Dtos
{
    public class InquiryStatusChangeDto 
    {
        public int Id { get; set; }

        public InquiryStatus Status { get; set; } = InquiryStatus.Reviewing;

    }
}
