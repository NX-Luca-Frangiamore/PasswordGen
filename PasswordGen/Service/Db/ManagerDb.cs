using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;

namespace PasswordGen.Service.Db
{
    public class ManagerDb : IManagerDb
    {
        public ManagerDb(Context db) : base(db)
        {
        }
        public override bool NewUtente(Utente utente)
        {
            db.Utente.Add(utente);
            return db.SaveChanges()>0;
        }
        public override bool DeleteUtente(string username, string passwordUsername)
        {
            if(GetUtente(username, passwordUsername) is Utente u)
              db.Utente.Remove(u);
            return db.SaveChanges() > 0;
        }
        public override Utente? GetUtente(string username, string passwordUsername)
        {
            return db.Utente.Include(x=>x.PasswordList).Where(x => x.UsernameUtente == username && x.PasswordUtente == passwordUsername).FirstOrDefault();
        }
        public override bool Save()
        {
            return db.SaveChanges()>0;
        }
    }
}
