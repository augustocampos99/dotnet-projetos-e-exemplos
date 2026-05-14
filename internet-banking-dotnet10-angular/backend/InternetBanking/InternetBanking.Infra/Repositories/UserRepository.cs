using InternetBanking.Domain.Entities;
using InternetBanking.Domain.Repositories;
using InternetBanking.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PostgreSQLContext _context;

        public UserRepository(PostgreSQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> FindById(long id)
        {
            return await _context.Users
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
