using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace PasswordGen.Model.Configurator
{
    public class ConfUtente : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            
            builder.OwnsMany(x => x.PasswordList,a=>a.HasKey("Name"));

        }
    }
}
