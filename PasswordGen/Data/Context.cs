using Microsoft.EntityFrameworkCore;
using PasswordGen.Model;
using PasswordGen.Model.Configurator;
using System.Reflection.Metadata;

namespace PasswordGen.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions opt) : base(opt) { }
        public DbSet<Utente> Utente { get; set; }
        public DbSet<PasswordModel> PasswordList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Conf).Assembly);

        }

    }
}
