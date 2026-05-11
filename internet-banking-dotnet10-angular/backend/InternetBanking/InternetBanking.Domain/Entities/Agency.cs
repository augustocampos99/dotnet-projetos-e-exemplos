using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Domain.Entities
{
    public class Agency
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
