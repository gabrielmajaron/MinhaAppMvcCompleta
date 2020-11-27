using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{
    public class Produto : Entity
    {     
        public Guid FornecedorId { get; set; }        
        public string Nome { get; set; }        
        public string Descricao { get; set; }        
        public string Imagem { get; set; }        
        public decimal Valor { get; set; }        
        public DateTime DataCadastro { get; set; }       
        public bool Ativo { get; set; }

        /* Relacionamentos E.F. */
        // Informa ao E.F. que o produto possui so um fornec.
        public Fornecedor Fornecedor { get; set; }
        // /\ conhecido como propriedade de navegação para o E.F.
    }
}
