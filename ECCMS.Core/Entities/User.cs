using ECCMS.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace ECCMS.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDelete { get; set; }

        public string FirstName { get; set; } =null!;

        public string LastName { get; set; } = null!;

        public string Nic {  get; set; } =null!;

        public string? Address { get; set; }

        public string MobileNo { get; set; } = null!;

        public DateTime? Dob { get; set; }

        public string Gender { get; set; } = null!;

        public string? Status { get; set; }

        public UserType Type { get; set; }

    }
}
