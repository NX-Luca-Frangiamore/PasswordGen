using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;
using PasswordGen.Data;

namespace PasswordGen.Repository
{
    public class ManagerDb : IManagerDb
    {
        public ManagerDb(Context db) : base(db)
        {
        }
        public override Task<bool> NewUtente(Utente utente)
        {
            db.Utente.Add(utente);
            return Save();
        }
        public async override Task<bool> DeleteUtente(int? id)
        {
            if ((await GetUtente(id)) is Utente u)
                db.Utente.Remove(u);
            return await Save();
        }
        public override Task<Utente?> GetUtente(string username, string passwordUsername)
        {
            return db.Utente.Where(x=>x.UsernameUtente==username && x.PasswordUtente==passwordUsername).FirstOrDefaultAsync();
        }
        public override ValueTask<Utente?> GetUtente(int? id)
        {
            return db.Utente.FindAsync(id);
        }

        public override async Task<bool> Save()
        {
            return await db.SaveChangesAsync() > 0;
        }
        

    }
}
