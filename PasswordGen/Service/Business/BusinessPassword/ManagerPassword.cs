using PasswordGen.Service.Db;
using PasswordGen.Model;
namespace PasswordGen.Service.Business.BusinessPassword
{
    public class ManagerPassword : IManagerPassword
    {
        readonly IManagerDb Db;
        public ManagerPassword(IManagerDb db)
        {
            this.Db = db;
        }

        public bool ChangePassword(string username, string passwordUtente, string nomePassword, string newPassword)
        {
            if(Db.GetUtente(username,passwordUtente) is Utente u)
            {
                if (u.GetPassword(nomePassword) is PasswordModel p)
                {
                    p.SetPassword(newPassword);
                    return Db.Save();
                }             
            }
            return false;
        }

        public bool DeletePassword(string username, string passwordUtente, string nomePassword)
        {
            if (Db.GetUtente(username, passwordUtente) is Utente u)
            {
                u.DeletePassword(nomePassword);
                return Db.Save();
            }
            return false;
        }

        public PasswordModel? GetPassword(string username, string passwordUtente, string nomePassword)
        {
            if (Db.GetUtente(username, passwordUtente) is Utente u)
            {
                return u.GetPassword(nomePassword);
            }
            return null;
        }

        public List<PasswordModel>? GetPassword(string username, string passwordUtente)
        {
            if (Db.GetUtente(username, passwordUtente) is Utente u)
            {
                return u.PasswordList;
            }
            return null;
        }

        public bool NewPassword(string username, string passwordUtente, string nomePassword, string password)
        {
            if(Db.GetUtente(username,passwordUtente) is Utente u)
            {
                if (u.AddPassword(nomePassword, password))
                {
                    Db.Save();
                    return true;
                }

            }
            return false;
        }
    }
}
