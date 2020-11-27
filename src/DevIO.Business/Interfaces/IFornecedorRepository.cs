using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        // Obtem o fornecedor com o seu respectivo endereço
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);

        // Obtem o fornecedor, endereço e a sua lista de produtos
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
