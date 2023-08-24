using PasswordGen.Data;
using PasswordGen.Model;

namespace PasswordGen.Service.Db
{
    public abstract class IManagerDb
    {
        protected Context db;
        public IManagerDb(Context db) { this.db = db; }

        public abstract Task<Utente?> GetUtente(string username,string passwordUsername);
        public abstract Task<bool> NewUtente(Utente utente);

        public abstract Task<bool> DeleteUtente(string username, string passwordUsername);
        public abstract Task<bool> Save();
    }
}
