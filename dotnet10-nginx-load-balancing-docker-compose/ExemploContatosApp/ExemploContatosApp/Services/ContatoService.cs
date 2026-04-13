using ExemploContatosApp.Entities;
using ExemploContatosApp.Services.Interfaces;

namespace ExemploContatosApp.Services
{
    public class ContatoService : IContatoService
    {

        public List<Contato> FindAll()
        {
            var contatoList = new List<Contato>()
            {
                new Contato() { Id = Guid.Parse("a9a7cf49-7f71-4f76-92cb-315d7e290803"), Nome = "Pedro", Email = "pedro@gmail.com", Telefone = "11933447711" },
                new Contato() { Id = Guid.Parse("5ca899b0-0904-44ab-b6bb-800ecac9ce40"), Nome = "João", Email = "joao@gmail.com", Telefone = "11933447722"  },
                new Contato() { Id = Guid.Parse("cecbedd0-4a54-46b7-9f1a-d020fe81dcdc"), Nome = "Ana", Email = "ana@gmail.com", Telefone = "11933447733"  },
                new Contato() { Id = Guid.Parse("c4ab547b-ebd9-4086-b6fb-10567f21d787"), Nome = "Maria", Email = "maria@gmail.com", Telefone = "11933447744"  },
                new Contato() { Id = Guid.Parse("40447fe4-d60b-45f5-9a35-c63bc1eba4f3"), Nome = "José", Email = "jose@gmail.com", Telefone = "11933447755"  },
                new Contato() { Id = Guid.Parse("a628cdf8-4f27-4611-92bf-ae230dd3cebd"), Nome = "Thiago", Email = "thiago@gmail.com", Telefone = "11933447766"  },
                new Contato() { Id = Guid.Parse("aa7cf1f6-f3b7-47ba-b5e9-687c2855c8eb"), Nome = "Carlos", Email = "carlos@gmail.com", Telefone = "11933447777"  },
            };
            return contatoList;
        }

        public Contato? FindById(Guid id) 
        {
            return this.FindAll().Find(e => e.Id == id);
        }

        public Contato Create(Contato contato)
        {
            contato.Id = Guid.NewGuid();
            return contato;
        }

        public Contato Update(Guid id, Contato contato)
        {
            contato.Id = id;
            return contato;
        }

        public void Delete(Guid id)
        {
        }

    }
}
