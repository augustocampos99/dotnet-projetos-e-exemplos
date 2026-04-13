using ExemploContatosApp.Entities;

namespace ExemploContatosApp.Services.Interfaces
{
    public interface IContatoService
    {
        List<Contato> FindAll();

        Contato? FindById(Guid id);

        Contato Create(Contato contato);

        Contato Update(Guid id, Contato contato);

        void Delete(Guid id);
    }
}
