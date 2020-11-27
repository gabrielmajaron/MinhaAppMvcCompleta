using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.Models
{  
    public class Endereco : Entity
    {
        // é um fornecedor que possui um endereço
        // porém esse ID do fornecedor na classe endereço
        // só existe para aque o entity fw funcione
        // O E.F. entende que essa aqui é a F.K.
        public Guid FornecedorId { get; set; }
        public string Logradouro { get; set; }
        
        public string Numero { get; set; }
                       
        public string Complemento { get; set; }
      
        public string Cep { get; set; }
        
        public string Bairro { get; set; }
    
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /* Relacionamentos E.F. */
        // um endereço pertence a 1 fornec. apenas

        public Fornecedor Fornecedor { get; set; }
    }
}
