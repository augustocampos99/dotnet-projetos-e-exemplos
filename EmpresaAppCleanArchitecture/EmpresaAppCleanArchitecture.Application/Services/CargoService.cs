using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;

namespace EmpresaAppCleanArchitecture.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;            
        }

        public async Task<IEnumerable<Cargo>> FindAll(int take, int skip)
        {
            return await _cargoRepository.FindAll(take, skip);
        }

        public async Task<Cargo> Create(CargoRequest cargoRequest)
        {
            var cargo = new Cargo
            {
                Nome = cargoRequest.Nome
            };

            return await _cargoRepository.Create(cargo);
            
        }

        public async Task<Cargo> Update(Guid id, CargoRequest cargoRequest)
        {
            var cargo = await _cargoRepository.FindOneById(id);

            if (cargo == null)
            {
                throw new NotFoundException("Cargo não encontrado");
            }

            cargo.Nome = cargoRequest.Nome;
            return await _cargoRepository.Update(cargo);
        }

        public async Task Delete(Guid id)
        {
            var cargo = await _cargoRepository.FindOneById(id);

            if (cargo == null)
            {
                throw new NotFoundException("Cargo não encontrado");
            }

            await _cargoRepository.Delete(cargo);
        }

    }
}
