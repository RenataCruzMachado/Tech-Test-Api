using tech_test_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace tech_test_api.Mappings
{
    public class AlunoMap: IEntityTypeConfiguration<Aluno>
    {
       public void Configure(EntityTypeBuilder<Aluno> builder){
            builder.ToTable("Aluno");
            builder.Property(p => p.NomeAluno)
                .HasColumnType("varchar(200)")
                .IsRequired();
             builder.Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired(); 
             builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired(); 
            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(50)")
                .IsRequired(); 
            builder.HasMany(a => a.Matriculas)
                .WithOne(m => m.Aluno)
                .HasForeignKey(m => m.AlunoId);
        }
    }
}