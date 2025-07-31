using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Isotop2.Data
{
    internal class PasswordHasher
    {
        //Метод хеширования
        static public string Hashing(SecureString password)
        {
            byte[] securePass = SecureStringToByte(password);
            byte[] salt;
            byte[] buffer;
            //Создаём сущность для генерации Соль и Хеш(входной пароль, длина Соль, количество итераций хеширования)
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(securePass), 0x10, 0x3e8))
            {
                salt = bytes.Salt; //Получаем сгенерированную Соль длиной в 16 символов
                buffer = bytes.GetBytes(0x20); //Получаем 32 случайно сгенерированных символа для пароля
            }
            //Собираем Соль и набор символов вместе
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 0, 0x10);
            Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
            string hash = Convert.ToBase64String(dst);
            return hash;
        }
        //Метод проверки пароля
        static public bool Verify(SecureString password, string hashPassword)
        {
            byte[] securePass = SecureStringToByte(password);
            byte[] buffer;
            byte[] src = Convert.FromBase64String(hashPassword); //Получаем массив байт из хешированного пароля
            byte[] salt = new byte[0x10];
            byte[] pass = new byte[0x20];
            //Разбираем хешированный пароль на Соль и пароль
            Buffer.BlockCopy(src, 0, salt, 0, 0x10);
            Buffer.BlockCopy(src, 0x11, pass, 0, 0x20);
            //Получаем хешированный вариант проверяемого пароля
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(securePass), salt, 0x3e8))
            {
                buffer = bytes.GetBytes(0x20);
            }
            //Сравниваем исходный набор символов хешированного пароля с входным набором символов
            bool equal = buffer.SequenceEqual(pass);
            return equal;
        }
        //Метод конвертации SecureString в Byte
        static private byte[] SecureStringToByte(SecureString str)
        {
            IntPtr ptr = Marshal.SecureStringToGlobalAllocUnicode(str); //Получаем указатель на начало строки SecureString
            try
            {
                byte[] unicByte = new byte[str.Length];
                for (var i = 0; i < unicByte.Length; i++)                
                    unicByte[i] = Marshal.ReadByte(ptr, i); //По-байтно вытаскиваем данные из памяти                
                return unicByte;
            }
            finally
            { 
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);    //Удаляем указатель на SecureString
            }
        }
    }
}
