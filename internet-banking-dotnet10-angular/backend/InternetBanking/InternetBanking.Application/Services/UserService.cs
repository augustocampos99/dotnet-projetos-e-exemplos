using InternetBanking.Application.Services.Interfaces;
using InternetBanking.Domain.Entities;
using InternetBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        public async Task<List<User>> FindAll(int skip, int take)
        {
            var result = await _userRepository.FindAll(skip, take);
            return result.ToList();
        }
    }
}
