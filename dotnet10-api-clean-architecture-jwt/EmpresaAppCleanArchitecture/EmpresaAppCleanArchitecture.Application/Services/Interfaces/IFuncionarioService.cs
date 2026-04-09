using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.DTOs.Response;
using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioResponse>> FindAll(int take, int skip);
        Task<IEnumerable<FuncionarioResponse>> FindAllByNome(string nome, int take, int skip);
        Task<IEnumerable<FuncionarioResponse>> FindAllByCargo(Guid cargoId, int take, int skip);
        Task<IEnumerable<FuncionarioResponse>> FindAllByDepartamento(Guid departamentoId, int take, int skip);
        Task<Funcionario?> FindOneById(Guid id);
        Task<FuncionarioResponse> Create(FuncionarioRequest funcionario);
        Task<FuncionarioResponse> Update(Guid id, FuncionarioRequest funcionario);
        Task Delete(Guid id);
    }
}
