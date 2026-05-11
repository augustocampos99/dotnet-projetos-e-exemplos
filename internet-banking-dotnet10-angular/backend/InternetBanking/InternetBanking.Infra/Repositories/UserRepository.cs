using InternetBanking.Domain.Entities;
using InternetBanking.Domain.Repositories;
using InternetBanking.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PostgreSQLContext _context;

        public UserRepository(PostgreSQLContext context) : base(context)
        {
            _context = context;
        }

    }
}
