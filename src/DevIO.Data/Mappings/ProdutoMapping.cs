using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        // Obs. caso alguma propriedade da entidade seja esquecida de ser mapeada
        // entao ela é mapeada como varchar max (tamanho maximo possivel)
        // MAS dentro de MeuDbContext é possivel configurar este default
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");


            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            //nao precisamos mapear nada decimal, datetime e boleano

            // node da tabela, sempre no plural
            builder.ToTable("Produtos");

            // o schema padrao é DBO
            //builder.ToTable("Produtos", "ExemploOutroSchema");
        }
    }
}
