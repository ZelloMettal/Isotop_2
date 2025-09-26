using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;
using System.Security;

namespace Isotop2.Data.Models
{
    internal class AuthorizationModel : IAuthorizationModel
    {
        private bool _currentUserRole = false;
        private string _currentUserName = "Unknown";

        public bool GetUserRole()
        {
            return _currentUserRole;
        }
    
        public bool IsVerifyPassword(string userName, SecureString userPassword)
        {
            User? user = new DataStorage<User>().GetOneEntityWher(u => u.UserName == userName);
            if (user != null)
            {     
                if (PasswordHasher.Verify(userPassword, user.HashPassword))
                {
                    _currentUserName = user.UserName;
                    _currentUserRole = user.Administrator;
                    new Logger($"Верификация прошла успешна; {DateTime.Now.ToString()}");
                    return true;
                }
            }
            else            
                new Logger($"При попытке получения пользователя вернудся Null; {DateTime.Now.ToString()}");
            
            return false;
        }
 
        public string GetUserName() 
        {
            return _currentUserName;
        }
    }
}
