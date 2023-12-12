using ECCMS.Core.Enums;
namespace ECCMS.Api.Dtos;


public class UserDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string UserName { get; set; } = null!;

    public UserType Type { get; set; }

    public int RoleId { get; set; }

    public int? AddressId { get; set; }

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Status { get; set; }

}

