using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    // classe abstract só pode ser herdada, nao pode ser instanciada
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() // "new()" permite o uso do new para o tipo TEntity (é usado na função remover)
    {
        // protect: tanto o repository quanto quem herdar dele
        // terão acesso ao DBContext
        protected readonly MeuDBContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDBContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        /*
        public void DetachLocal(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Detached;
        }*/

        // virtual: permite que as classes filhas deêm override nos metodos, caso precise
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            // Tracking: Toda vez que se é colocado algo na memória
            // O Asp começa a rastrear (tracking) esse objeto para fazer verificacoes (mudanças de estado por exemplo)
            // E consome processamento e tempo
            // Com o AsNoTracking o processamento fica mais rápido

            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            // uma forma de fazer sem a variavel DbSet: Db.Set<TEntity>().Add(entity);
            // com o "atalho" DbSet: DbSet.Add(entity);
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {            
            DbSet.Update(entity);
            await SaveChanges();
        }
       
        public virtual async Task Remover(Guid id)
        {
            // A vantagem de usar o Id dentro da classe basica Entity
            // Permite acessarmos o atributo Id conforme abaixo
            // Já que todos os que herdam de Entity obrigatoriamente vao possuir um Id
            DbSet.Remove(new TEntity { Id = id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

