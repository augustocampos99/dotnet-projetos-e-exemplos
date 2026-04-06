using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        Task<Cargo?> FindOneById(Guid id);
    }
}
