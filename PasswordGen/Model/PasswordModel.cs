using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PasswordGen.Model
{
    
    public class PasswordModel

    {
        
        public string Name { get; set; }
        public string Password { get; set; }
        public int UtenteId { get; set; }
        public Utente u;
        public PasswordModel(string name, string password)
        {
            if (CredenzialiManger.Verifica(name, password)) {
                Name = name;
                Password = password;
            }else
            throw new Exception("credenziali per creazione password non corretti");
        }
        public bool SetPassword(string password)
        {
            if (CredenzialiManger.Verifica(this.Name, password))
            {
                Password = password;
                return true;
            }
            return false;
        }
    }
}