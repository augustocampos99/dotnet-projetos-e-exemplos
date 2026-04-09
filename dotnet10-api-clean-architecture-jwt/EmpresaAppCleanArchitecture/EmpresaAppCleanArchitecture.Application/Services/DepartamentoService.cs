using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;

namespace EmpresaAppCleanArchitecture.Application.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;            
        }

        public async Task<IEnumerable<Departamento>> FindAll(int take, int skip)
        {
            return await _departamentoRepository.FindAll(take, skip);
        }

        public async Task<Departamento> Create(DepartamentoRequest departamentoRequest)
        {
            var departamento = new Departamento
            {
                Nome = departamentoRequest.Nome
            };

            return await _departamentoRepository.Create(departamento);
            
        }

        public async Task<Departamento> Update(Guid id, DepartamentoRequest departamentoRequest)
        {
            var departamento = await _departamentoRepository.FindOneById(id);

            if (departamento == null)
            {
                throw new NotFoundException("Departamento não encontrado");
            }

            departamento.Nome = departamentoRequest.Nome;
            return await _departamentoRepository.Update(departamento);
        }

        public async Task Delete(Guid id)
        {
            var departamento = await _departamentoRepository.FindOneById(id);

            if (departamento == null)
            {
                throw new NotFoundException("Departamento não encontrado");
            }

            await _departamentoRepository.Delete(departamento);
        }

    }
}
