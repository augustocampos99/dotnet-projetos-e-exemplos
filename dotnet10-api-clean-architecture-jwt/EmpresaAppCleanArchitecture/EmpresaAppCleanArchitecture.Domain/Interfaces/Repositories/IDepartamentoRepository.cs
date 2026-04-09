using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository : IGenericRepository<Departamento>
    {
        Task<Departamento?> FindOneById(Guid id);
    }
}
