using PasswordGen.Model;

namespace PasswordGen.Service.Db
{
    public abstract class IManagerDb
    {
        protected Context db;
        public IManagerDb(Context db) { this.db = db; }

        public abstract Utente? GetUtente(string username,string passwordUsername);
        public abstract bool NewUtente(Utente utente);

        public abstract bool DeleteUtente(string username, string passwordUsername);
        public abstract bool Save();
    }
}
