namespace ECCMS.Api.Dtos;

public class RoleDto
{
    public int Id { get; set; }

    public int InstitutionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool CanView { get; set; }
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
}


