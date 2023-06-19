using tech_test_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace tech_test_api.Mappings
{
    public class TurmaMap: IEntityTypeConfiguration<Turma>
    {
       public void Configure(EntityTypeBuilder<Turma> builder){
            builder.ToTable("Turma");
            builder.Property(p => p.NomeTurma)
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(p => p.AnoLetivo)
                .HasColumnType("int")
                .IsRequired(); 
            builder.Property(p => p.QtdMaximaAlunos)
                .HasColumnType("int")
                .IsRequired();
            builder.HasMany(a => a.Matriculas)
            .WithOne(m => m.Turma)
            .HasForeignKey(m => m.TurmaId);
        }
    }
}