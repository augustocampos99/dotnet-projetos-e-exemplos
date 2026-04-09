using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.DTOs.Request
{
    public class DepartamentoRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Minimo 2")]
        public string Nome { get; set; }
    }
}
