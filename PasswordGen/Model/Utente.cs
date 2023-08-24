namespace PasswordGen.Model
{
    public class Utente
    {
        public int Id { get; set; }
        public string UsernameUtente { get; set; }
        public string PasswordUtente { get; set; }
        public virtual List<PasswordModel> PasswordList { get; set; }
        public bool AddPassword(string name, string password)
        {
            try
            {
                PasswordList.Add(new PasswordModel(name, password));
            }
            catch (Exception e)
            {                 
                Console.WriteLine(e);
                return false;
            }          
            return true;
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
        
        public Utente(string UsernameUtente, string PasswordUtente)
        {
            if (CredenzialiManger.Verifica(UsernameUtente, PasswordUtente))
            {
                this.UsernameUtente = UsernameUtente;
                this.PasswordUtente = PasswordUtente;
            }
            else
                throw new Exception("credenziali di registrazione non corrette");
        }
        public bool ChangeCredenziali(string username,string password)
        {
            bool Changed= false;
            if (CredenzialiManger.VerificaUserName(username))
            {
                this.UsernameUtente = username;
                Changed = true;
            }
            if (CredenzialiManger.VerificaUserName(password))
            {
                this.PasswordUtente = password;
                Changed = true;
            }
            return Changed;

        }
    }

}
