using EmpresaAppCleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Domain.Entities
{
    public class Funcionario
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public Guid DepartamentoId { get; set; }

        public Guid CargoId { get; set; }

        public Departamento Departamento { get; set; }

        public Cargo Cargo { get; set; }

        public StatusFuncionarioEnum Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }

    }
}
