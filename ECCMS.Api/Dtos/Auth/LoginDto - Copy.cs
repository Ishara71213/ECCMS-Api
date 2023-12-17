using System.ComponentModel.DataAnnotations;

namespace ECCMS.Api.Dtos;
public class ChangePasswordPostDTO
{
    [Required]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required]
    public string NewPassword { get; set; } = string.Empty;
}
