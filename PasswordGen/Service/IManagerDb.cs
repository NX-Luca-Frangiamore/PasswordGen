
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public abstract class IManagerDb
    {
        private Context db;
        public IManagerDb(Context db) { this.db = db; }
        abstract public int getId(string username, string password);
        abstract public Password getPassword(int idUtente, string nome);

        abstract public bool newUtente(string username, string password);
        abstract public bool newPassword(int idUtente, Password password);


    }
}
