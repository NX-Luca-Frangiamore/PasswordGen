using PasswordGen.Service.Db;
using PasswordGen.Model;
namespace PasswordGen.Service.Business.BusinessUtente
{
    public class ManagerUtente : IManagerUtente
    {
        readonly IManagerDb Db;
        public ManagerUtente(IManagerDb db)
        {
            this.Db = db;
        }
        public bool NewUtente(string nome, string cognome)
        {
            try
            {
                Utente u = new(nome,cognome);
                return Db.NewUtente(u);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool ChangeUtente(string username, string password,string usernameNew,string passwordNew)
        {
            if(Db.GetUtente(username, password) is Utente u)
            {
                u.ChangeCredenziali(usernameNew, passwordNew);
                return Db.Save();
                
            }
            return false;
                
        }

        public bool DeleteUtente(string username, string password)
        {
            if (Db.GetUtente(username, password) is not null)
            {
                Db.DeleteUtente(username, password);
                return Db.Save();
            }
            return false;
        }
        public Utente? GetUtente(string username, string password)
        {
            if (Db.GetUtente(username, password) is Utente u)
            {
                return u;
            }
            return null;
        }
    }
}
