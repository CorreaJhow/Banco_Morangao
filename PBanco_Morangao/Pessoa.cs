using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Pessoa
    {
        public String Nome { get; set; }
        public long Cpf { get; set; }
        public String Email { get; set; }
        public long Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Endereco Endereco;

        public Pessoa()
        {

        }

        public Pessoa(string nome, long cpf, string email, long telefone, DateTime DataNascimento)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Telefone = telefone;
            this.DataNascimento = DataNascimento;
            Endereco endereco = new Endereco();
        }
    }
}
