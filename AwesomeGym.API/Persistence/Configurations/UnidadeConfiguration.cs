﻿using AwesomeGym.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGym.API.Persistence.Configurations
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.HasKey(u => u.Id);

            //Relacionamento Unidade x Alunos (1 - N)
            builder.HasMany(u => u.Alunos)
                   .WithOne(a => a.Unidade)
                   .HasForeignKey(a => a.IdUnidade)
                   .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento Unidade x Professores (1 - N)
            builder.HasMany(u => u.Professores)
                   .WithOne(a => a.Unidade)
                   .HasForeignKey(a => a.IdUnidade)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
