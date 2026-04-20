using ExemploContatosApp.Entities;

namespace ExemploContatosApp.Services.Interfaces
{
    public interface IContatoService
    {
        Task<List<Contato>> FindAll();

        Task<Contato?> FindById(Guid id);

        Task<Contato> Create(Contato contato);

        Task<Contato?> Update(Guid id, Contato contato);

        Task Delete(Guid id);
    }
}
