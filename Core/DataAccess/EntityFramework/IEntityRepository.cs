
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T Entity);
        void delete(T Entity);
        void update(T Entity);
        T Get(Expression<Func<T,bool>> filter=null);
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        

    }
}
