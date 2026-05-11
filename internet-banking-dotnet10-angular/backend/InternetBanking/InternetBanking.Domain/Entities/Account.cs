using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Entities
{
    public class Account
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long AgencyId { get; set; }

        public string AccountType { get; set; } = string.Empty;

        public decimal Balance { get; set; } = 0;

        public string Status { get; set; } = "ACTIVE";

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public User? User { get; set; }

        public Agency? Agency { get; set; }
    }
}
