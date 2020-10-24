using AwesomeGym.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGym.API.Persistence.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.Id);

            //Relacionamento Professor x Alunos (1 - N)
            builder.HasMany(p => p.Alunos)
                   .WithOne(a => a.Professor)
                   .HasForeignKey(a => a.IdProfessor)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
