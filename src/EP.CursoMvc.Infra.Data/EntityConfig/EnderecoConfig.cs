﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);
            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);
            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);
            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();
            Property(e => e.Complemento)
                .HasMaxLength(100);
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos"); 
        }
    }
}
