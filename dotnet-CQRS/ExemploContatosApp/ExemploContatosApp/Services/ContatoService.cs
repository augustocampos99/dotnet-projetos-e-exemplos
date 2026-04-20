using ExemploContatosApp.Data;
using ExemploContatosApp.Entities;
using ExemploContatosApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExemploContatosApp.Services
{
    public class ContatoService : IContatoService
    {

        private readonly PostgreSQLContext _DBContext;

        public ContatoService(PostgreSQLContext postgreSQLContext)
        {
            _DBContext = postgreSQLContext;
        }

        public async Task<List<Contato>> FindAll()
        {
            return await _DBContext
                .Contatos
                .ToListAsync();
        }

        public async Task<Contato?> FindById(Guid id) 
        {
            var contatoResult = await _DBContext
                .Contatos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            return contatoResult;
        }

        public async Task<Contato> Create(Contato contato)
        {
            _DBContext.Contatos.Add(contato);
            await _DBContext.SaveChangesAsync();
            return contato;
        }

        public async Task<Contato?> Update(Guid id, Contato contato)
        {
            var contatoResult = await _DBContext
                .Contatos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if(contatoResult == null)
            {
                return null;
            }

            contatoResult.Nome = contato.Nome;
            contatoResult.Email = contato.Email;
            contatoResult.Telefone = contato.Telefone;

            _DBContext.Contatos.Update(contatoResult);
            await _DBContext.SaveChangesAsync();
            return contatoResult;
        }

        public async Task Delete(Guid id)
        {
            var contatoResult = await _DBContext
                .Contatos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (contatoResult != null)
            {
                _DBContext.Contatos.Remove(contatoResult);
                await _DBContext.SaveChangesAsync();
            }

        }

    }
}
