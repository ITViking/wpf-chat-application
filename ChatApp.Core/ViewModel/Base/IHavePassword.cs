using System.Security;

namespace ChatApp.Core
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; set; }
    }
}
