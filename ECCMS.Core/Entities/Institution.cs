using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }


    }
}
