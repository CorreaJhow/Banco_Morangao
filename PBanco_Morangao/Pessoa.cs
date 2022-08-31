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
        public String Nome
        {
            get
            {
                return Nome;
            }
            set
            {
                Console.WriteLine("Digite algum nome: ");
                Nome = Console.ReadLine();
            }
        }
        public long Cpf
        {
            get
            {
                return Cpf;
            }
            set
            {
                Console.WriteLine("Digite um numero de CPF: ");
                Cpf = (long.Parse(Console.ReadLine()));
            }
        }
        public String Email
        {
            get
            {
                return Email;
            }
            set
            {
                Console.WriteLine("Digite seu email: ");
            }
        }
        public long Telefone
        {
            get
            {
                return Telefone;
            }
            set
            {
                Console.WriteLine("Digite seu numero de telefone: ");
                Telefone = (long.Parse(Console.ReadLine()));    
            }
        }
        public DateTime DataNascimento
        {
            get
            {
                return DataNascimento;
            }
            set
            {
                Console.WriteLine("Digite sua data de nascimento: ");
                DataNascimento = (DateTime.Parse(Console.ReadLine()));
            }
        }
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
