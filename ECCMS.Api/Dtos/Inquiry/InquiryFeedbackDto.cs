using ECCMS.Core.Enums;

namespace ECCMS.Api.Dtos
{
    public class InquiryFeedbackDto 
    {
        public int Id { get; set; }

        public string? UserComment { get; set; }

        public bool? IsSatisfied { get; set; }

        public int? Rating { get; set; }

    }
}
