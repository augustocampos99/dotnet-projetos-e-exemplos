using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Address { get; set; }

        public decimal MonthlyIncome { get; set; } = 0;

        public string? Password { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
