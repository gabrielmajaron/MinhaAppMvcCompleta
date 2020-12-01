using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDBContext context) : base(context) {     }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(p => p.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(_id => _id.Id == id);
        }
        
        public void Detach(List<Fornecedor> f)
        {
            Db.ChangeTracker.AcceptAllChanges();
            
            //foreach (EntityEntry dbEntityEntry in Db.ChangeTracker.Entries())
            //{
                //if (dbEntityEntry.Entity != null)
                //{
                    //Db.Entry(dbEntityEntry).State = EntityState.Detached;
                //}
            //}
            //EntityEntry e = Db.Entry(obj);

            foreach(Fornecedor _f in f)
            {
                Db.Entry(_f).State = EntityState.Detached;
            }

            Db.SaveChanges();
        }
    }
}
