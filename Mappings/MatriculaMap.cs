using tech_test_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace tech_test_api.Mappings
{
    public class MatriculaMap: IEntityTypeConfiguration<Matricula>
    {
       public void Configure(EntityTypeBuilder<Matricula> builder){
            builder.ToTable("Matricula");
        
            builder.HasKey(m => new { m.AlunoId, m.TurmaId }); // Chave composta
        
            builder.HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
        
            builder.HasOne(m => m.Turma)
                .WithMany(t => t.Matriculas)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}