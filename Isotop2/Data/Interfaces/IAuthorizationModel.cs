using System.Security;

namespace Isotop2.Data.Interfaces
{
    internal interface IAuthorizationModel
    {
        bool GetUserRole();
        bool IsVerifyPassword(string userName, SecureString userPassword);
        string GetUserName();
    }
}
