namespace PasswordGen.Model
{
    public class Password
    {
        public int id { get; set; }
        public string password { get; set; }
        public int utenteId { get; set; }
    }
}