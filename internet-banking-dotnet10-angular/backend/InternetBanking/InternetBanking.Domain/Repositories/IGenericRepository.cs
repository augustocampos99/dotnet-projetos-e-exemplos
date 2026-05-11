using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll(int skip, int take);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
