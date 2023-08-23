
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public abstract class IManagerDb
    {
        protected Context db;
        public IManagerDb(Context db) { this.db = db; }
        abstract public int getId(string _username, string _password);
        abstract public bool newUtente(string _username, string _password);
        abstract public bool changeUtente(string _username, string _password, string _newUsername, string _newPassword);
        abstract public bool deleteUtente(int _idUtente);
        abstract public Utente getUtente(int _idUtente);
        abstract public Password? getPassword(int _idUtente, string _nome);
        abstract public List<Password>? getPassword(int _idUtente);
        abstract public bool changePassword(int _idUtente, string _nome,string _newPassword);
        abstract public bool newPassword(int _idUtente, Password _password);
        abstract public bool deletePassword(int _idUtente, string _nome);





    }
}
