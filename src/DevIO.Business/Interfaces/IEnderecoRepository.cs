using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        // obtem o endereço de um fornecedor
        Task<Endereco> ObtemEnderecoPorFornecedor(Guid fornecedorId);
    }
}
