using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);
            //HasKey(c => new {c.ClienteId, c.Cpf});
            Property(c => c.Nome)
                .IsRequired()
                .HasColumnOrder(1)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .HasColumnName("str_Nome");

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                     new IndexAttribute()
                     {
                        IsUnique  = true
                         
                     }));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Clientes");

        }
    }
}
