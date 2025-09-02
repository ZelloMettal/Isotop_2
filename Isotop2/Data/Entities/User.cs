namespace Isotop2.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public bool Administrator { get; set; }
    }
}
