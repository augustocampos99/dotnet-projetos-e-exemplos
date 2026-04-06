using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;
using EmpresaAppCleanArchitecture.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Repositories
{
    public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly PostgreSQLContext _context;

        public FuncionarioRepository(PostgreSQLContext context) : base(context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<Funcionario>> FindAllByCargo(Guid cargoId, int take, int skip)
        {
            return await _context.Funcionarios
                .Where(e => e.CargoId == cargoId)
                .Take(take)
                .Skip(skip)
                .ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> FindAllByDepartamento(Guid departamentoId, int take, int skip)
        {
            return await _context.Funcionarios
                .Where(e => e.DepartamentoId == departamentoId)
                .Take(take)
                .Skip(skip)
                .ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> FindAllByNome(string nome, int take, int skip)
        {
            return await _context.Funcionarios
                .Where(e => e.Nome.ToLower().Contains(nome.ToLower()))
                .Take(take)
                .Skip(skip)
                .ToListAsync();
        }

        public async Task<Funcionario?> FindOneById(Guid id)
        {
            return await _context
                .Funcionarios
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
