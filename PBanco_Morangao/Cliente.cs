using System;


namespace PBanco_Morangao
{
    internal class Cliente : Pessoa
    {
        public float FaixaSalarial { get; set; }
        public Conta Conta { get; set; }
        public Cliente() { }
        public Agencia agencia { get; set; }

        public void SolicitarAberturaConta()
        {
            Console.WriteLine("De acordo com sua faixa salarial vamos prosseguir e analisar seu tipo de conta;");
            Console.WriteLine("Pressione enter para iniciar o processo.");
            Console.ReadKey();
        }
        public void CadastrarCliente(string nome, string cpf, string email, long telefone, string endereco, string logradouro)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco.Cidade = endereco;
            this.Endereco.Logradouro = logradouro;
        }
        public void CadastrarCliente()
        {
            Console.WriteLine("Informe seus: ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|       Dados Pessoais      |");
            Console.WriteLine("-----------------------------");
            Console.Write("Nome: ");
            this.Nome = Console.ReadLine();
            Console.Write("CPF (Cadastro de Pessoa Fisica) no modelo XXX-XXX-XXX-XX: ");
            this.Cpf = (Console.ReadLine());
            Console.Write("Informe seu Email: ");
            this.Email = Console.ReadLine();
            Console.Write("Informe seu telefone (pessoal): ");
            this.Telefone = long.Parse(Console.ReadLine());
            while(this.Telefone <= 0)
            {
                Console.Write("Telefone inválido, informe novamente: ");
                this.Telefone = long.Parse(Console.ReadLine());
            }
            Console.Write("Informe sua data de nascimento no modelo (dd/mm/aaaa): ");
            this.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("informe sua Faixa Salarial: ");
            this.FaixaSalarial = float.Parse(Console.ReadLine());
            while(this.FaixaSalarial < 0)
            {
                Console.Write("Valor informado invalido, informe seu salario novamente: ");
                this.FaixaSalarial = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|          Endereço:        |");
            Console.WriteLine("-----------------------------");
            Console.Write("Informe seu Bairro: ");
            this.Endereco.Bairro = Console.ReadLine();
            Console.Write("Informe sua rua ou avenida: ");
            this.Endereco.Logradouro = Console.ReadLine();
            Console.Write("Informe o Numero da Residencia: ");
            this.Endereco.Numero = Console.ReadLine();
            Console.Write("Informe a Cidade: ");
            this.Endereco.Cidade =Console.ReadLine();
            Console.Write("Informe seu Estado: ");
            this.Endereco.Estado = Console.ReadLine();
        }
        public override string ToString()
        {
            return "Nome: " +this.Nome+ "\nCPF: " + this.Cpf + 
                "\nEmail: " + this.Email + "\nTelefone: " + this.Telefone+ "\nCidade: " +this.Endereco.Cidade+ "\nBairro: " + this.Endereco.Bairro; 
        }
    }
}
