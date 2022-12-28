﻿using System.Linq.Expressions;

namespace Authorization.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool TrackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
