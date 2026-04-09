using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> FindAll(int take, int skip);
        Task<Departamento> Create(DepartamentoRequest departamento);
        Task<Departamento> Update(Guid id, DepartamentoRequest departamento);
        Task Delete(Guid id);
    }
}
