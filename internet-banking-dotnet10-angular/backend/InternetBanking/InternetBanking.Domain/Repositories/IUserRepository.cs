using InternetBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> FindById(long id);
    }
}
