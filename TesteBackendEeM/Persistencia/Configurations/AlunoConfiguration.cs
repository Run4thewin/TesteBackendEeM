using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Persistencia.Configurations
{
    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeConfiguration<Aluno> builder)
        {
            builder.ToTable("ALUNOS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .IsRequired();

        }
    }
}

