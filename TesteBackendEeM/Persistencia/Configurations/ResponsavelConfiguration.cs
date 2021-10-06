using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Persistencia.Configurations
{
    public class ResponsavelConfiguration : EntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeConfiguration<Responsavel> builder)
        {
            builder.ToTable("RESPONSAVEIS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .IsRequired();

        }
    }
}

