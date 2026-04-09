using EmpresaAppCleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.DTOs.Request
{
    public class FuncionarioRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(11, ErrorMessage = "Deve ter 11 digitos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Minimo 2")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "DepartamentoId é obrigatório")]
        public Guid DepartamentoId { get; set; }

        [Required(ErrorMessage = "CargoId é obrigatório")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public StatusFuncionarioEnum Status { get; set; }
    }
}
