using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GorilaXamDemoApi.Services
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Insert(TEntity entityToInsert);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity>Get(Expression<Func<TEntity,bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
            string includeProperties="");

        TEntity GetById(object id);
        void Delete(object entityToDelete);
            

    }
}
