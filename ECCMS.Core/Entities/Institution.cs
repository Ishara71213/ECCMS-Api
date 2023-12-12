using ECCMS.Core.Entities.Base;
using System.Net;

namespace ECCMS.Core.Entities
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; } = null!;

        public int? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }

        public int CityId { get; set; }

        public virtual City? City { get; set; }

    }
}
