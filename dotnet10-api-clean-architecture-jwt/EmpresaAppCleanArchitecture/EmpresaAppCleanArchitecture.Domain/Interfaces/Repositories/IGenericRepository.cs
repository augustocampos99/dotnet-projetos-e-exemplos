using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll(int take, int skip);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
