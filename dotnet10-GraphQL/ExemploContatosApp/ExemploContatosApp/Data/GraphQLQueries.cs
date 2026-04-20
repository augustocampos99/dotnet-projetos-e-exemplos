using ExemploContatosApp.Entities;

namespace ExemploContatosApp.Data
{
    public class GraphQLQueries
    {

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Contato> GetContatos([Service] PostgreSQLContext context)
        {
            return context.Contatos;
        }


        // Apenas com essa classe e as annotations acima disponibilizamos as consultas no formato GraphQL
        // Para cada novo DataSet precisamos criar o nome do metodo no padrão GetNomeDaEntidade para que ele fique disponível nas consultas
        //---------------------------------------------------------
        // Exemplo de query GraphQL para buscar os contatos do metodo acima
        //query {
        //    contatos (order: { nome: ASC }) {
        //        nome,
        //        telefone
        //    }
        //}         

    }
}
