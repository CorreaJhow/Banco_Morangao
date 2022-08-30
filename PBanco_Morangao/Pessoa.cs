using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Pessoa
    {
        String Nome;
        long Cpf;
        String Email;
        long Telefone;
        DateTime DataNascimento;
        Endereco Endereco;

        public Pessoa(string nome, long cpf, string email, long telefone, DateTime DataNascimento,Endereco endereco)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Telefone = telefone;
            this.DataNascimento = DataNascimento;
            this.Endereco = endereco;
        }
    }
}
