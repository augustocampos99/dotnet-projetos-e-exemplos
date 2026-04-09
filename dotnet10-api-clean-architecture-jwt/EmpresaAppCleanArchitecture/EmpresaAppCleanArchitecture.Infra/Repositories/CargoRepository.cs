using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;
using EmpresaAppCleanArchitecture.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly PostgreSQLContext _context;

        public CargoRepository(PostgreSQLContext context) : base(context)
        {
            _context = context;            
        }

        public async Task<Cargo?> FindOneById(Guid id)
        {
            return await _context
                .Cargos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
