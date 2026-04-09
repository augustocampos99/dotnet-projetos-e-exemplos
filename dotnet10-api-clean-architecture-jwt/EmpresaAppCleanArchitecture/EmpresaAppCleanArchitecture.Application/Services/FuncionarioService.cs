using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.DTOs.Response;
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

        public async Task<IEnumerable<FuncionarioResponse>> FindAll(int take, int skip)
        {
            var result = await _funcionarioRepository.FindAll(take, skip);
            return new FuncionarioResponse().Parser(result);
        }

        public async Task<IEnumerable<FuncionarioResponse>> FindAllByNome(string nome, int take, int skip)
        {
            var result = await _funcionarioRepository.FindAllByNome(nome, take, skip);
            return new FuncionarioResponse().Parser(result);
        }

        public async Task<IEnumerable<FuncionarioResponse>> FindAllByCargo(Guid cargoId, int take, int skip)
        {
            var cargo = await _cargoRepository.FindOneById(cargoId);
            if (cargo == null)
            {
                throw new BadRequestException("Cargo não encontrado");
            }

            var result = await _funcionarioRepository.FindAllByCargo(cargoId, take, skip);
            return new FuncionarioResponse().Parser(result);
        }

        public async Task<IEnumerable<FuncionarioResponse>> FindAllByDepartamento(Guid departamentoId, int take, int skip)
        {
            var departamento = await _departamentoRepository.FindOneById(departamentoId);
            if (departamento == null)
            {
                throw new BadRequestException("Departamento não encontrado");
            }

            var result = await _funcionarioRepository.FindAllByDepartamento(departamentoId, take, skip);
            return new FuncionarioResponse().Parser(result);
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

        public async Task<FuncionarioResponse> Create(FuncionarioRequest funcionarioRequest)
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

            var result =  await _funcionarioRepository.Create(funcionario);
            return new FuncionarioResponse().Parser(result);
        }

        public async Task<FuncionarioResponse> Update(Guid id, FuncionarioRequest funcionarioRequest)
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
            var result = await _funcionarioRepository.Update(funcionario);
            return new FuncionarioResponse().Parser(result);
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
