using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(MeuDBContext context) : base(context) { }

        // procura pelo fornecedor de um determinado produto. Retorna o objeto Produto com o fornecedor já dentro dele
        /*
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }*/

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            // retorna todos os produtos com todos seus fornecedores
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
            // ordenado pelo nome do produto
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);

            /* se nao existisse a busca implementada... talvez seria assim?
                return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor.Id == fornecedorId)
                .ToListAsync();*/
        }


        
        public void Detach(object obj)
        {
            Db.ChangeTracker.AcceptAllChanges();
            
            //foreach (EntityEntry dbEntityEntry in Db.ChangeTracker.Entries())
            //{
            //    if (dbEntityEntry.Entity != null)
            //    {
            //        Db.Entry(dbEntityEntry).State = EntityState.Detached;
            //    }
            //}
            //EntityEntry e = Db.Entry(obj);

            Db.Entry(obj).State = EntityState.Detached;
            Db.SaveChanges();
        }
    }
}
