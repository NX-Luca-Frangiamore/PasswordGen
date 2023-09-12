using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using PasswordGen.Service.Credenziali;

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
            if(GetPassword(name) is null)
                if (PasswordModel.Create(name, password) is PasswordModel p)
                {
                    PasswordList.Add(p);
                    return true;
                }
            return false;
        }
        public bool DeletePassword(string name)
        {
            if (GetPassword(name) is PasswordModel p)
                return PasswordList.Remove(p);
            return false;
        }
        public PasswordModel? GetPassword(string name)
        {
            return PasswordList.Where(x => x.Name == name).FirstOrDefault();
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
        public bool ChangeCredenziali(string? username,string? password)
        {
            bool Changed= false;
            if (username is not null)
            {
                if (!CredenzialiManger.VerificaUsername(username)) return false;
                this.UsernameUtente = username;
                Changed = true;
            }
            if (password is not null)
            {
                if (!CredenzialiManger.VerificaPassword(password)) return false;
                this.PasswordUtente = password;
                Changed = true;
            }
            return Changed;

        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
