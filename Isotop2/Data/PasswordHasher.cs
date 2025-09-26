using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Isotop2.Data
{
    internal class PasswordHasher
    {
        static public string Hashing(SecureString password)
        {
            byte[] securePass = SecureStringToByte(password);
            byte[] salt;
            byte[] buffer;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(securePass), 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(0x20);
            }
      
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 0, 0x10);
            Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
            string hash = Convert.ToBase64String(dst);
            return hash;
        }
     
        static public bool Verify(SecureString password, string hashPassword)
        {
            byte[] securePass = SecureStringToByte(password);
            byte[] buffer;
            byte[] src = Convert.FromBase64String(hashPassword);
            byte[] salt = new byte[0x10];
            byte[] pass = new byte[0x20];
         
            Buffer.BlockCopy(src, 0, salt, 0, 0x10);
            Buffer.BlockCopy(src, 0x11, pass, 0, 0x20);
         
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(securePass), salt, 0x3e8))
            {
                buffer = bytes.GetBytes(0x20);
            }
    
            bool equal = buffer.SequenceEqual(pass);
            return equal;
        }
   
        static private byte[] SecureStringToByte(SecureString str)
        {
            IntPtr ptr = Marshal.SecureStringToGlobalAllocUnicode(str);
            byte[] unicByte = new byte[str.Length];
            for (var i = 0; i < unicByte.Length; i++)                
                unicByte[i] = Marshal.ReadByte(ptr, i);
            Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            return unicByte;
        }
    }
}
