using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> FindAll(int take, int skip);
        Task<IEnumerable<Funcionario>> FindAllByNome(string nome, int take, int skip);
        Task<IEnumerable<Funcionario>> FindAllByCargo(Guid cargoId, int take, int skip);
        Task<IEnumerable<Funcionario>> FindAllByDepartamento(Guid departamentoId, int take, int skip);
        Task<Funcionario?> FindOneById(Guid id);
        Task<Funcionario> Create(FuncionarioRequest funcionario);
        Task<Funcionario> Update(Guid id, FuncionarioRequest funcionario);
        Task Delete(Guid id);
    }
}
