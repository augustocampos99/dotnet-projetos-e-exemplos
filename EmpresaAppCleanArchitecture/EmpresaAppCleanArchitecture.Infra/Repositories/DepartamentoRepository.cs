using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;
using EmpresaAppCleanArchitecture.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Repositories
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        private readonly PostgreSQLContext _context;

        public DepartamentoRepository(PostgreSQLContext context) : base(context)
        {
            _context = context;            
        }

        public async Task<Departamento?> FindOneById(Guid id)
        {
            return await _context
                .Departamentos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
