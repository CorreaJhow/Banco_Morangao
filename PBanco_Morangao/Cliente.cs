using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Cliente : Pessoa
    {
        public double FaixaSalarial { get; set; }
       
        public Cliente()
        {

        }
        
        public double SolicitarAberturaConta()
        {
            Console.WriteLine("Informe sua Faixa Salarial para prosseguirmos e anarlisarmos seu tipo de conta e se ela será autorizada: ");
            FaixaSalarial = double.Parse(Console.ReadLine());
            Console.WriteLine("Pressione enter para iniciar o processo.");
            Console.ReadKey();
            return FaixaSalarial;
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("Insira de acordo com o orientado; \nNome: ");
            this.Nome = Console.ReadLine();
            Console.WriteLine("CPF (Cadastro de Pessoa Fisica) no modelo XXX-XXX-XXX-XX: ");
            this.Cpf = (Console.ReadLine());
            Console.WriteLine("Informe seu Email: ");
            this.Email = Console.ReadLine();
            Console.WriteLine("Informe seu telefone (pessoal): ");
            this.Telefone = long.Parse(Console.ReadLine());
            Console.WriteLine("Informe sua data de nascimento no modelo (dd/mm/aaaa): ");
            this.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Correto, agora sobre seu endereço: ");
            Console.WriteLine("Informe seu Bairro: ");
            this.Endereco.Bairro = Console.ReadLine();
            Console.WriteLine("Informe seu Logradouro: ");
            this.Endereco.Logradouro = Console.ReadLine();
            Console.WriteLine("Informe o Numero da Residencia: ");
            this.Endereco.Numero = Console.ReadLine();
            Console.WriteLine("Informe a Cidade: ");
            this.Endereco.Cidade =Console.ReadLine();
            Console.WriteLine("Informe seu Estado: ");
            this.Endereco.Estado = Console.ReadLine();
        }

        public override string ToString()
        {
            return "O Cadastro foi efetuado com ***SUCESSO***\nConfira alguns dos dados informados para cadastro do cliente " +this.Nome+ ", no caso foram: \nCPF: " + this.Cpf + 
                "\nEmail: " + this.Email + "\nTelefone: " + this.Telefone+ "\nCidade" +this.Endereco.Cidade+ "\nLogradouro: " + this.Endereco.Logradouro; 
        }



    }
}
