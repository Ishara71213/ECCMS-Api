using ECCMS.Core.Entities;

namespace ECCMS.Api.Dtos
{
    public class CrimeTypeDto 
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CrimeLevel { get; set; }

        public int AverageResponseHours { get; set; }

        public int InstitutionId { get; set; }

    }
}
