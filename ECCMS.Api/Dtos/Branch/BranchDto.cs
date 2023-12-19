using ECCMS.Core.Entities;

namespace ECCMS.Api.Dtos
{
    public class BranchDto
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }

        public int CityId { get; set; }
        public int InstitutionId { get; set; }

    }
}
