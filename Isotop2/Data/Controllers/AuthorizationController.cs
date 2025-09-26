using Isotop2.Data.Interfaces;
using System.Security;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;

namespace Isotop2.Data.Controllers
{
    internal class AuthorizationController
    {
        static private IAuthorizationModel _model = ServiceProviderHolder.ServiceProvider.GetRequiredService<IAuthorizationModel>();

        static public bool GetUserRole()
        {
            return _model.GetUserRole();
        }

        static public bool VerifyUser(string userName, SecureString userPassword)
        {            
            return _model.IsVerifyPassword(userName, userPassword);
        }

        static public string GetUserName() 
        {
            return _model.GetUserName();
        }
    }
}
