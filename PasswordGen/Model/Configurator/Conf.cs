using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace PasswordGen.Model.Configurator
{
    public class Conf : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.OwnsMany(x => x.PasswordList, s => {
                s.Property<int>("id").ValueGeneratedOnAdd();
                s.HasKey("id");
            }) ;                                            
        }
    }
}