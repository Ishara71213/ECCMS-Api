namespace ECCMS.Api.Dtos
{
    public class InstitutionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }
    }
}
