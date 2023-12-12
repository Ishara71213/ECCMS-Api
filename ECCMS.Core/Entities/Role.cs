using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; } = null!;
    }
}
