using InternetBanking.Application.DTOs.Request;
using InternetBanking.Application.DTOs.Response;
using InternetBanking.Application.Exceptions;
using InternetBanking.Application.Services.Interfaces;
using InternetBanking.Domain.Entities;
using InternetBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace InternetBanking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        public async Task<List<UserResponseDto>> FindAll(int skip, int take)
        {
            var result = await _userRepository.FindAll(skip, take);
            return new UserResponseDto().Parse(result.ToList());
        }

        public async Task<UserResponseDto?> FindById(long id)
        {
            var result = await _userRepository.FindById(id);
            if(result == null)
            {
                throw new NotFoundException();
            }

            return new UserResponseDto().Parse(result);
        }

        public async Task<UserResponseDto> Create(UserRequestDto request)
        {
            var user = new User
            {
                Cpf = request.Cpf,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                Address = request.Address,
                MonthlyIncome = request.MonthlyIncome,
                Status = request.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _userRepository.Create(user);

            return new UserResponseDto().Parse(user);
        }

        public async Task<UserResponseDto> Update(long id, UserRequestDto request)
        {
            var userResult = await _userRepository.FindById(id);
            if (userResult == null)
            {
                throw new NotFoundException();
            }

            userResult.Cpf = request.Cpf;
            userResult.Name = request.Name;
            userResult.Email = request.Email;
            userResult.Phone = request.Phone;
            userResult.BirthDate = request.BirthDate;
            userResult.Address = request.Address;
            userResult.MonthlyIncome = request.MonthlyIncome;
            userResult.Status = request.Status;
            userResult.CreatedAt = userResult.CreatedAt.ToUniversalTime();
            userResult.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Update(userResult);

            return new UserResponseDto().Parse(userResult);
        }

        public async Task Delete(long id)
        {
            var userResult = await _userRepository.FindById(id);
            if (userResult == null)
            {
                throw new NotFoundException();
            }

            await _userRepository.Delete(userResult);
        }

    }
}
