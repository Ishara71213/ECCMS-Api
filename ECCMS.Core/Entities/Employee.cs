using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities;
public class Employee : BaseEntity
{
    public int UserId { get; set; }
    public int BranchId { get; set; }
    public string Designation { get; set; } = null!;
    public int RoleId { get; set; }
    public bool? ChangePassword { get; set; }
    public virtual User? User { get; set; }
    public virtual Branch? Branch { get; set; } 
    public virtual Role? Role { get; set; }
}