using System.Runtime.InteropServices;

namespace PasswordGen.Model
{
    public class Utente
    {
        public int Id { get; set; }
        public string UsernameUtente { get; set; }
        public string PasswordUtente { get; set; }
        public virtual List<PasswordModel> PasswordList { get; set; }=new List<PasswordModel>();
        public bool AddPassword(string name, string password)
        {
            if (PasswordModel.Create(name, password) is PasswordModel p)
            {
                PasswordList.Add(p);
                return true;
            }
            return false;
        }
        public bool DeletePassword(string name)
        {
            try
            {
                if (GetPassword(name) is PasswordModel p)
                    return PasswordList.Remove(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public PasswordModel? GetPassword(string name)
        {
            if (PasswordList.Where(x => x.Name == name) is PasswordModel p)
                return p;
            return null;
        }
        private Utente(string UsernameUtente, string PasswordUtente)
        {
                this.UsernameUtente = UsernameUtente;
                this.PasswordUtente = PasswordUtente;
        }
        public static Utente? Create(string UsernameUtente, string PasswordUtente)
        {
            if (CredenzialiManger.Verifica(UsernameUtente, PasswordUtente))
            {
                return new Utente(UsernameUtente, PasswordUtente);
            }
            else
                return null;
        }
        public bool ChangeCredenziali(string username,string password)
        {
            bool Changed= false;
            if (CredenzialiManger.VerificaUserName(username))
            {
                this.UsernameUtente = username;
                Changed = true;
            }
            if (CredenzialiManger.VerificaPassword(password))
            {
                this.PasswordUtente = password;
                Changed = true;
            }
            return Changed;

        }
    }

}
