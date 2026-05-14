using InternetBanking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetBanking.Application.DTOs.Request
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Cpf required")]
        [MaxLength(11, ErrorMessage = "Min length 11")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "email required")]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Required(ErrorMessage = "BirthDate required")]
        public DateTime BirthDate { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "MonthlyIncome required")]
        public decimal MonthlyIncome { get; set; } = 0;

        [Required(ErrorMessage = "Status required")]
        public UserStatusEnum Status { get; set; }
    }
}
