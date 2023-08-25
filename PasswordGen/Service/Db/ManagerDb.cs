using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;
using PasswordGen.Data;
namespace PasswordGen.Service.Db
{
    public class ManagerDb : IManagerDb
    {
        public ManagerDb(Context db) : base(db)
        {
        }
        public async override Task<bool> NewUtente(Utente utente)
        {
            db.Utente.Add(utente);
            return await Save();
        }
        public async override Task<bool> DeleteUtente(string username, string passwordUsername)
        {
            if(await GetUtente(username, passwordUsername) is Utente u)
              db.Utente.Remove(u);
            return await Save();
        }
        public override async Task<Utente?> GetUtente(string username, string passwordUsername)
        {
            return await db.Utente.Where(x => x.UsernameUtente == username && x.PasswordUtente == passwordUsername).FirstOrDefaultAsync();
        }
        public override async Task<Utente?> GetUtenteWithPassword(string username, string passwordUsername)
        {
            return await db.Utente.Include(x=>x.PasswordList).Where(x => x.UsernameUtente == username && x.PasswordUtente == passwordUsername).FirstOrDefaultAsync();
        }
        public override async Task<bool> Save()
        {
            return (await db.SaveChangesAsync())>0;
        }
    }
}
