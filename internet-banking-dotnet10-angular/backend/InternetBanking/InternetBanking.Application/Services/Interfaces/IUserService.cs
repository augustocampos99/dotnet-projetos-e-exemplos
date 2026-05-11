using InternetBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> FindAll(int skip, int take);
    }
}
