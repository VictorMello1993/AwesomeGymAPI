using AwesomeGym.API.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Persistence
{
    public class AwesomeGymDbContext : DbContext
    {
        public AwesomeGymDbContext(DbContextOptions<AwesomeGymDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.Entity<Professor>().HasKey(p => p.Id);
            modelBuilder.Entity<Unidade>().HasKey(u => u.Id);

            //Relacionamento Professor x Alunos (1 - N)
            modelBuilder.Entity<Professor>()
                  .HasMany(p => p.Alunos)
                  .WithOne(a => a.Professor)
                  .HasForeignKey(a => a.IdProfessor)
                  .OnDelete(DeleteBehavior.Restrict);


            //Relacionamento Unidade x Alunos (1 - N)
            modelBuilder.Entity<Unidade>()
                  .HasMany(u => u.Alunos)
                  .WithOne(a => a.Unidade)
                  .HasForeignKey(a => a.IdUnidade)
                  .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento Unidade x Professores (1 - N)
            modelBuilder.Entity<Unidade>()
                  .HasMany(u => u.Professores)
                  .WithOne(a => a.Unidade)
                  .HasForeignKey(a => a.IdUnidade)
                  .OnDelete(DeleteBehavior.Restrict);

        }      
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AwesomeGymDb");
        }
    }
}
