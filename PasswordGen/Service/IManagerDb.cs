
using PasswordGen.Model;

namespace PasswordGen.Service
{
    public abstract class IManagerDb
    {
        private Context db;
        public IManagerDb(Context db) { this.db = db; }
        abstract public int getId(string username, string password);
        abstract public int getPassword(int idUtente, string nome);


    }
}
