using InternetBanking.Domain.Entities;
using InternetBanking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Application.DTOs.Response
{
    public class UserResponseDto
    {
        public long Id { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Address { get; set; }

        public decimal MonthlyIncome { get; set; } = 0;

        public UserStatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserResponseDto Parse(User user)
        {
            return  new UserResponseDto
            {
                Id = user.Id,
                Cpf = user.Cpf,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                BirthDate = user.BirthDate,
                Address = user.Address,
                MonthlyIncome = user.MonthlyIncome,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

        }

        public List<UserResponseDto> Parse(List<User> users)
        {
            return users.Select(x => new UserResponseDto
            {
                Id = x.Id,
                Cpf = x.Cpf,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                BirthDate = x.BirthDate,
                Address = x.Address,
                MonthlyIncome = x.MonthlyIncome,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

        }
    }
}
