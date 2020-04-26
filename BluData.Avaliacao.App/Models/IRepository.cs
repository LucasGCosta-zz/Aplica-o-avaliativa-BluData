using BluData.Avaliacao.Database.DAL;
using System;
using System.Collections.Generic;

namespace BluData.Avaliacao.App.Models
{
    public interface IRepository<TEntity> : IDisposable
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity Find(int id);

        public TEntity Insert(TEntity entity);

        public bool Update(int id, TEntity entity);

        public (bool success, TEntity entity) Delete(int id);
    }
}
