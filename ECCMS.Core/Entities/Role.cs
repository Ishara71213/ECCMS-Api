using ECCMS.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace ECCMS.Core.Entities
{
    public class Role : IdentityRole<int>
    {

        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int InstitutionId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Institution Institution { get; set; } = null!;
    }
}
