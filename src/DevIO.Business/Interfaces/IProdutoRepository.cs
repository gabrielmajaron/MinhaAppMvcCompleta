using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        // retorna todos os produtos de um fornecedor
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        
        // obtem uma lista de fornecedores e seus respectivos produtos
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        
        // obtem o produto e seu fornecedor, de acordo com o id do produto 
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
