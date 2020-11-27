using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            // property é para setar obrigatoridades
            // e o tipo de uma coluna da tabela
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // hasone, hasmany, withone, withmany
            // são usados para definir relacionamentos
            // e F.K.

            // 1:1 => Fornecedor : Endereco 
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            // 1:n => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");

            // o schema padrao é DBO
            //builder.ToTable("Produtos", "ExemploOutroSchema");
        }
    }
}
