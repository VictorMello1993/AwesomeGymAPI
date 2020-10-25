using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new UnidadeConfiguration());
        }      
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("AwesomeGymDb");

            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root;password=xxxxxxxx;database=awesomegym")
                .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole().AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
