using EnglishForLife.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnglishForLife.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
              : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aluno>()
                    .HasOne(t => t.Turma)
                    .WithMany(a => a.Alunos)
                    .HasForeignKey(a => a.TurmaId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluno>()
                        .HasIndex(a => a.Cpf)
                        .IsUnique();

            modelBuilder.Entity<Aluno>()
                        .HasIndex(a => a.Email)
                        .IsUnique();

            modelBuilder.Entity<Turma>()
                        .HasIndex(a => a.NomeTurma)
                        .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
