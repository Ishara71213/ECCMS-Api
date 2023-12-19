using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities
{
    public class CrimeType : BaseEntity
    {

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CrimeLevel { get; set; }

        public int AverageResponseHours { get; set; }

        public int InstitutionId { get; set; }

        public virtual Institution? Institution { get; set; }
    }
}
