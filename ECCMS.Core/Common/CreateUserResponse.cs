using ECCMS.Core.Entities;

namespace ECCMS.Core.Common
{
    public class CreateUserResponse
    {
        public string Password { get; set; } = string.Empty;

        public User User { get; set; } = null!;
    }
}
