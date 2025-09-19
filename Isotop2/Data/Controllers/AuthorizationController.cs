using Isotop2.Data.Models;
using System.Security;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Services;

namespace Isotop2.Data.Controllers
{
    internal class AuthorizationController
    {
        static private AuthorizationModel _model = ServiceProviderHolder.ServiceProvider.GetRequiredService<AuthorizationModel>();

        //Метод получения роли пользователя
        static public bool GetUserRole()
        {
            return _model.GetUserRole();
        }
        //Метод вериикации логина и пароля пользователя
        static public bool VerifyUser(string userName, SecureString userPassword)
        {            
            return _model.IsVerifyPassword(userName, userPassword);
        }
        //Метод получения текущего пользователя
        static public string GetUserName() 
        {
            return _model.GetUserName();
        }
    }
}
