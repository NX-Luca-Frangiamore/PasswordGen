namespace PasswordGen.Model
{
    public class Utente
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public IEnumerable<Password> passwords { get; set; }
    }
}
