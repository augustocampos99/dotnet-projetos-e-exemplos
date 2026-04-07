using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services.Interfaces
{
    public interface ICargoService
    {
        Task<IEnumerable<Cargo>> FindAll(int take, int skip);
        Task<Cargo> Create(CargoRequest cargo);
        Task<Cargo> Update(Guid id, CargoRequest cargo);
        Task Delete(Guid id);
    }
}
