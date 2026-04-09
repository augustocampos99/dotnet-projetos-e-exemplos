using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;
using EmpresaAppCleanArchitecture.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PostgreSQLContext _context;
        private readonly DbSet<T> _DBSet;

        public GenericRepository(PostgreSQLContext context)
        {
            _context = context;
            _DBSet = _context.Set<T>();            
        }

        public virtual async Task<IEnumerable<T>> FindAll(int take, int skip)
        {
            return await _DBSet
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            _DBSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _DBSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _DBSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
