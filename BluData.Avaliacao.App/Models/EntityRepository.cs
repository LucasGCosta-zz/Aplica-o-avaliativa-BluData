using BluData.Avaliacao.Database.DAL;
using BluData.Avaliacao.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluData.Avaliacao.App.Models
{
    /// <summary>
    /// Classe generica para interção com o banco de dados
    /// </summary>
    /// <typeparam name="TEntity">Entidade do banco de dados</typeparam>
    public abstract class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly BluDataContext _context;

        public EntityRepository(BluDataContext context) => _context = context;

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual TEntity Find(int id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);

            return entity;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>()
                    .Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public virtual bool Update(int id, TEntity entity)
        {
            if (id != entity.Id)
                return false;

            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public virtual (bool success, TEntity entity) Delete(int id)
        {
            TEntity entity = _context.Set<TEntity>()
                                      .Find(id);

            if (entity is null)
                return (false, entity);

            _context.Set<TEntity>()
                    .Remove(entity);

            _context.SaveChanges();

            return (true, entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
