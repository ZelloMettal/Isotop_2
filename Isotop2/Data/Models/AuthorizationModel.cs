using Isotop2.Data.Entities;
using System.Security;

namespace Isotop2.Data.Models
{
    internal class AuthorizationModel
    {
        private bool _currentUserRole = false; //Роль текущего пользователя Администратор
        private string _currentUserName = string.Empty; //Текущего пользователь
        //Метод получения роли пользователя
        public bool GetUserRole()
        {
            return _currentUserRole;
        }
        //Метод проверки данных пользователя
        public bool IsVerifyPassword(string userName, SecureString userPassword)
        {
            User? user = new DataStorage<User>().GetOneEntityWher(u => u.UserName == userName);
            if (user != null)
            {
                if (PasswordHasher.Verify(userPassword, user.HashPassword))
                {
                    _currentUserName = user.UserName;
                    _currentUserRole = user.Administrator;
                    return true;
                }
            }
            return false;
        }
        //Метод получения текущего пользователя
        public string GetUserName() 
        {
            return _currentUserName;
        }
    }
}
