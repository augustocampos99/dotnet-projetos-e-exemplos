using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Application.DTOs.Response
{
    public class BadRequestResponseDto
    {
        public int Code { get; set; }

        public string? Message { get; set; }
    }
}
