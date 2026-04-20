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
        // Paga cada novo DataSet precisamos criar no padrão GetNomeDaEntidade para que ele fique disponível nas consultas
        //---------------------------------------------------------
        // Exemplo de QUERY GraphQL
        //query {
        //    contatos (order: { nome: ASC }) {
        //        nome,
        //        telefone
        //    }
        //}         

    }
}
