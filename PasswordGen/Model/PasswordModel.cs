using Microsoft.EntityFrameworkCore;
using PasswordGen.Service.PasswordService.GeneratorePassword;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace PasswordGen.Model
{    public enum State
    {
        ready, notReady, inContruction 
    }
    public class PasswordModel
    {
        public string Name { get; private set; }
        private string? _password;
      
        public int UtenteId { get; private set; }

        public State State { get; private set; }
        public string? Password
        {
            get { return (State is State.ready) ? _password : null; }
            private set { _password = value; }
        }
        private PasswordModel(string name)
        {
            Name = name;
            State = State.notReady;
            Password = "";
        }
        private PasswordModel(string name, string password)
        {
            Name = name;
            Password = password;
            State = State.ready;
        }
        public static PasswordModel? CreateNew(string name)
        {
            if (CredenzialiManger.VerificaUserName(name))
                return new(name);
            return null;
        }
        public static PasswordModel? CreateNew(string name, string password)
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
        public void AddPart(string part)
        {
            _password += part;
        }
        public PasswordModel? CompleteCreation()
        {
            if (CredenzialiManger.Verifica(Name, _password))
            {
                State = State.ready;
                return this;
            }
            return default;
        }
    }
}
