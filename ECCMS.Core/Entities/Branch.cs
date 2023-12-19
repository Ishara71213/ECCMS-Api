using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities;
public class Branch : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public int CityId { get; set; }

    public int InstitutionId { get; set; }

    public virtual City? City { get; set; }

    public virtual Institution? Institution { get; set; }
}