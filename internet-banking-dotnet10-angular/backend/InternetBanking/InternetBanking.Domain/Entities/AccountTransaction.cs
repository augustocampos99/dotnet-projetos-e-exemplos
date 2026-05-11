using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Entities
{
    public class AccountTransaction
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long SourceAccountId { get; set; }

        public long? DestinationAccountId { get; set; }

        public decimal TransactionAmount { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }

        public Account? SourceAccount { get; set; }

        public Account? DestinationAccount { get; set; }
    }
}
