using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;

namespace EmpresaAppCleanArchitecture.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ICargoRepository _cargoRepository;

        public FuncionarioService(
            IFuncionarioRepository funcionarioRepository, 
            IDepartamentoRepository departamentoRepository, 
            ICargoRepository cargoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _departamentoRepository = departamentoRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<Funcionario>> FindAll(int take, int skip)
        {
            return await _funcionarioRepository.FindAll(take, skip);
        }

        public async Task<IEnumerable<Funcionario>> FindAllByNome(string nome, int take, int skip)
        {
            return await _funcionarioRepository.FindAllByNome(nome, take, skip);
        }

        public async Task<IEnumerable<Funcionario>> FindAllByCargo(Guid cargoId, int take, int skip)
        {
            var cargo = await _cargoRepository.FindOneById(cargoId);
            if (cargo == null)
            {
                throw new BadRequestException("Cargo não encontrado");
            }

            return await _funcionarioRepository.FindAllByCargo(cargoId, take, skip);
        }

        public async Task<IEnumerable<Funcionario>> FindAllByDepartamento(Guid departamentoId, int take, int skip)
        {
            var departamento = await _departamentoRepository.FindOneById(departamentoId);
            if (departamento == null)
            {
                throw new BadRequestException("Departamento não encontrado");
            }

            return await _funcionarioRepository.FindAllByDepartamento(departamentoId, take, skip);
        }

        public async Task<Funcionario> FindOneById(Guid id)
        {
            var funcionario = await _funcionarioRepository.FindOneById(id);

            if (funcionario == null)
            {
                throw new NotFoundException("Funcionario não encontrado");
            }

            return funcionario;
        }

        public async Task<Funcionario> Create(FuncionarioRequest funcionarioRequest)
        {
            // Verificando departamento
            var departamento = await _departamentoRepository.FindOneById(funcionarioRequest.DepartamentoId);
            if (departamento == null)
            {
                throw new BadRequestException("Departamento não encontrado");
            }

            // Validando cargo
            var cargo = await _cargoRepository.FindOneById(funcionarioRequest.CargoId);
            if (cargo == null)
            {
                throw new BadRequestException("Cargo não encontrado");
            }

            var funcionario = new Funcionario
            {
                CPF = funcionarioRequest.CPF,
                Nome = funcionarioRequest.Nome,
                CargoId = funcionarioRequest.CargoId,
                DepartamentoId = funcionarioRequest.DepartamentoId,
                Status = funcionarioRequest.Status,
                DataCriacao = DateTime.UtcNow,
                DataAtualizacao = DateTime.UtcNow,
            };

            return await _funcionarioRepository.Create(funcionario);            
        }

        public async Task<Funcionario> Update(Guid id, FuncionarioRequest funcionarioRequest)
        {
            // Validando cargo
            var cargo = await _cargoRepository.FindOneById(funcionarioRequest.CargoId);
            if (cargo == null)
            {
                throw new BadRequestException("Cargo não encontrado");
            }

            // Verificando departamento
            var departamento = await _departamentoRepository.FindOneById(funcionarioRequest.DepartamentoId);
            if (departamento == null)
            {
                throw new BadRequestException("Departamento não encontrado");
            }

            var funcionario = await _funcionarioRepository.FindOneById(id);

            if (funcionario == null)
            {
                throw new NotFoundException("Funcionario não encontrado");
            }


            funcionario.CPF = funcionarioRequest.CPF;
            funcionario.Nome = funcionarioRequest.Nome;
            funcionario.DepartamentoId = funcionarioRequest.DepartamentoId;
            funcionario.CargoId = funcionarioRequest.CargoId;
            funcionario.Status = funcionarioRequest.Status;
            funcionario.DataCriacao = funcionario.DataCriacao.ToUniversalTime();
            funcionario.DataAtualizacao = DateTime.UtcNow;
            return await _funcionarioRepository.Update(funcionario);
        }

        public async Task Delete(Guid id)
        {
            var funcionario = await _funcionarioRepository.FindOneById(id);

            if (funcionario == null)
            {
                throw new NotFoundException("Funcionario não encontrado");
            }

            await _funcionarioRepository.Delete(funcionario);
        }

    }
}
