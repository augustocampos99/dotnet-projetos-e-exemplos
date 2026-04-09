using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.DTOs.Response
{
    public class FuncionarioResponse
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Departamento { get; set; }

        public string Cargo { get; set; }

        public StatusFuncionarioEnum Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public FuncionarioResponse Parser(Funcionario funcionario)
        {
            return new FuncionarioResponse()
            {
                Id = funcionario.Id,
                CPF = funcionario.CPF,
                Nome = funcionario.Nome,
                Departamento = funcionario.Departamento.Nome,
                Cargo = funcionario.Cargo.Nome,
                Status = funcionario.Status,
                DataCriacao = funcionario.DataCriacao,
                DataAtualizacao = funcionario.DataAtualizacao
            };
        }

        public IEnumerable<FuncionarioResponse> Parser(IEnumerable<Funcionario> funcionarios)
        {
            return funcionarios.Select(e => {
                return new FuncionarioResponse()
                {
                    Id = e.Id,
                    CPF = e.CPF,
                    Nome = e.Nome,
                    Departamento = e.Departamento.Nome,
                    Cargo = e.Cargo.Nome,
                    Status = e.Status,
                    DataCriacao = e.DataCriacao,
                    DataAtualizacao = e.DataAtualizacao
                };
            });
        }
    }
}
