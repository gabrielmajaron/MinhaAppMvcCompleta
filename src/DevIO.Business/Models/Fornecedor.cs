using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor{ get; set; }
        public Endereco Endereco { get; set; }
        
        public bool Ativo { get; set; }

        /* Relacionamento do E.F. */
        // Informa ao E.F. que o fornecedor tem uma relação de 
        // 1 para muitos com o produto
        public IEnumerable<Produto> Produtos { get; set; }
    }    
}
