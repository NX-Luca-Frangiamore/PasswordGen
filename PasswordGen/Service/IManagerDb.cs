
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public abstract class IManagerDb
    {
        protected Context db;
        public IManagerDb(Context db) { this.db = db; }
        abstract public int getId(string _username, string _password);
        abstract public Password? getPassword(int _idUtente, string _nome);

        abstract public bool newUtente(string _username, string _password);
        abstract public bool newPassword(int _idUtente, Password _password);


    }
}
