using EmpresaAppCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IGenericRepository<Funcionario>
    {
        Task<IEnumerable<Funcionario>> FindAllByNome(string nome, int take, int skip);
        Task<IEnumerable<Funcionario>> FindAllByCargo(Guid cargoId, int take, int skip);
        Task<IEnumerable<Funcionario>> FindAllByDepartamento(Guid departamentoId, int take, int skip);
        Task<Funcionario?> FindOneById(Guid id);

    }
}
