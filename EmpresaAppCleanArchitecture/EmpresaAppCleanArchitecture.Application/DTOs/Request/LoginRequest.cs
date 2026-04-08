using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.DTOs.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email é obrigatóri")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }
    }
}
