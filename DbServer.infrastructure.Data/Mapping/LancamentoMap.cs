using DbServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Data.Mapping
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IDContaOrigem)
                .IsRequired();
            builder.Property(c => c.IDContaDestino)
               .IsRequired();
            builder.Property(c => c.Valor)
               .IsRequired();
        }
    }
}
