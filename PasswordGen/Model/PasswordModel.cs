using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PasswordGen.Model
{

    public class PasswordModel

    {

        public string Name { get; set; }
        public string Password { get; set; }
        public int UtenteId { get; set; }
        public PasswordModel() { }//Per test
        private PasswordModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public static PasswordModel? Create(string name, string password)
        {
            if (CredenzialiManger.Verifica(name, password))
                return new(name, password);
            return null;
        }
        public bool SetPassword(string password)
        {
            if (CredenzialiManger.VerificaPassword(password))
            {
                Password = password;
                return true;
            }
            return false;
        }

    }
}
