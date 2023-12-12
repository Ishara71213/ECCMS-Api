using ECCMS.Core.Entities.Base;

namespace ECCMS.Core.Entities
{
    public class City : BaseEntity
    {

        public string Name { get; set; } = string.Empty;
        public int ProvicnceId { get; set; }
        public virtual Province? Province { get; set; } 
    }
}
