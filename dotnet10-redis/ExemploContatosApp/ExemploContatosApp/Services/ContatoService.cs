using ExemploContatosApp.Data;
using ExemploContatosApp.Entities;
using ExemploContatosApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using System.Text.Json;

namespace ExemploContatosApp.Services
{
    public class ContatoService : IContatoService
    {

        private readonly PostgreSQLContext _DBContext;
        private readonly IDatabase _cache;

        public ContatoService(PostgreSQLContext postgreSQLContext)
        {
            _DBContext = postgreSQLContext;

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cache = redis.GetDatabase();
        }

        public async Task<List<Contato>> FindAll()
        {
            string keyList = "contato_list";
            var contatoCacheList = await _cache.ListRangeAsync(keyList);
            if(contatoCacheList != null && contatoCacheList.Length > 0)
            {
                return contatoCacheList
                   .Select(e => JsonSerializer.Deserialize<Contato>(e.ToString()))
                   .ToList();
            }

            var contatoResultList = await _DBContext
                                        .Contatos
                                        .ToListAsync();

            foreach (var contato in contatoResultList)
            {
                contato.Origem = "REDIS";
                await _cache.ListLeftPushAsync(keyList, JsonSerializer.Serialize(contato));
                contato.Origem = "PostgreSQL";
            }

            return contatoResultList;
        }

        public async Task<Contato?> FindById(Guid id) 
        {
            string key = id.ToString();
            var contatoCache = await _cache.StringGetAsync(key);

            // Se tiver no REDIS retorna
            if (contatoCache.HasValue)
            {
                var contatoRedis = JsonSerializer.Deserialize<Contato>(contatoCache.ToString());
                contatoRedis.Origem = "REDIS";
                return contatoRedis;
            }

            var contatoResult = await _DBContext
                .Contatos
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (contatoResult != null) 
            {
                // Criando registro no REDIS
                contatoResult.Origem = "REDIS";
                await _cache.StringSetAsync(contatoResult.Id.ToString(), JsonSerializer.Serialize(contatoResult));
                contatoResult.Origem = "PostgreSQL";
            }

            return contatoResult;
        }

        public async Task<Contato> Create(Contato contato)
        {
            _DBContext.Contatos.Add(contato);
            await _DBContext.SaveChangesAsync();

            // Criando registro no REDIS
            contato.Origem = "REDIS";
            await _cache.StringSetAsync(contato.Id.ToString(), JsonSerializer.Serialize(contato));
            // Limpando a lista no REDIS
            await _cache.KeyDeleteAsync("contato_list");

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

            // Limpando a lista no REDIS
            await _cache.KeyDeleteAsync("contato_list");

            // Atualizando REDIS
            await _cache.StringSetAsync(contatoResult.Id.ToString(), JsonSerializer.Serialize(contatoResult));

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

                // Removendo item do REDIS e Limpando a lista
                await _cache.KeyDeleteAsync(id.ToString());
                await _cache.KeyDeleteAsync("contato_list");
            }

        }

    }
}
