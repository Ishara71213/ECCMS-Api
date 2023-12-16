using ECCMS.Core.Entities;
using ECCMS.Core.Enums;
namespace ECCMS.Api.Dtos;


public class EmployeeDto
{
    
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Nic { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string MobileNo { get; set; } = string.Empty;

    public DateTime? Dob { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string? Status { get; set; }

    public UserType Type { get; set; }

    public int RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;

    public int UserId { get; set; }

    public int BranchId { get; set; }

    public string Designation { get; set; } = null!;

    public bool? ChangePassword { get; set; }

}

