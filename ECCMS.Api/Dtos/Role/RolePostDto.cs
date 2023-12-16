namespace ECCMS.Api.Dtos;

public class RolePostDto
{
    public string Name { get; set; } = string.Empty;

    public int InstitutionId { get; set; }
    public bool CanView { get; set; }
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
}

