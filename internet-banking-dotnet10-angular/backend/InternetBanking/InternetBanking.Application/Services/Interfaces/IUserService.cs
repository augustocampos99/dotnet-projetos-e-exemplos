using InternetBanking.Application.DTOs.Request;
using InternetBanking.Application.DTOs.Response;
using InternetBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> FindAll(int skip, int take);
        Task<UserResponseDto?> FindById(long id);
        Task<UserResponseDto> Create(UserRequestDto request);
        Task<UserResponseDto> Update(long id, UserRequestDto response);
        Task Delete(long id);

    }
}
