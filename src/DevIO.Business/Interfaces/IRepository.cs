using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
        // essa função não retorna nada (void)
        Task Adicionar(TEntity entity);

        // essa função retorna um objeto do tipo TEntity
        // TEntity é um tipo generico. Se eu herdar essa interface com um tipo 
        // Produto, por exempo, então TEntity será do tipo Produto
        Task<TEntity> ObterPorId(Guid id);
        // essa função retorna uma lista de TEntity
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);

        // essa função recebe por parâmetro uma função lambda
        // que busca qualquer entidade por qualquer parametro
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    
    }
}
