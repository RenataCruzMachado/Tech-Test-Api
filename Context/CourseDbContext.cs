using Microsoft.EntityFrameworkCore;
using tech_test_api.Models;
using tech_test_api.Mappings;


namespace tech_test_api.Context
{
    public class CourseDbContext:DbContext{
        public CourseDbContext(DbContextOptions<CourseDbContext> options): base(options){

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
           modelBuilder.ApplyConfiguration(new AlunoMap());
           modelBuilder.ApplyConfiguration(new TurmaMap());
           modelBuilder.ApplyConfiguration(new MatriculaMap());
        }    
    }
}