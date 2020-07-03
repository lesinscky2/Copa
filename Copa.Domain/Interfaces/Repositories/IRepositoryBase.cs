using System;
using System.Collections.Generic;

namespace Copa.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        bool Edit(T obj);
        bool Remove(T obj);
        bool Add(T obj);
        List<T> Get();
        IEnumerable<T> Get(Func<T, bool> expression);


    }
}