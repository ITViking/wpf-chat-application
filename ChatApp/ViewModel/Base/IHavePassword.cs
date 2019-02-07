using System.Security;

namespace ChatApp
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; set; }
    }
}
