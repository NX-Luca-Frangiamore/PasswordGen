using Microsoft.EntityFrameworkCore;

namespace PasswordGen.Model
{
    public class Context :DbContext
    {
        public Context(DbContextOptions opt) : base(opt) { }
        public DbSet<Utente> utente { get; set; }
        public DbSet<Password> passwords { get; set; }

    }
}
