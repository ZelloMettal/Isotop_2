using Isotop2.Data.Entities;
using Isotop2.Data.Interfaces;
using System.Security;

namespace Isotop2.Data.Models
{
    internal class AuthorizationModel : IAuthorizationModel
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
            User? user = new DataStorage<User>().GetOneEntityWher(u => u.UserName == userName); //Получаем пользователя
            if (user != null)
            {
                //Если верификация удалась устанавливаем текщего пользователя и роль
                if (PasswordHasher.Verify(userPassword, user.HashPassword))
                {
                    _currentUserName = user.UserName;
                    _currentUserRole = user.Administrator;
                    new Logger($"Верификация прошла успешна; {DateTime.Now.ToString()}");
                    return true;
                }
            }
            else
            {
                //Фиксируем неудачную попытку полоучения пользователя
                new Logger($"При попытке получения пользователя вернудся Null; {DateTime.Now.ToString()}");
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
