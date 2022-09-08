using System;


namespace PBanco_Morangao
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public String Cpf { get; set; }
        public String Email { get; set; }
        public long Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Endereco Endereco;

        public Pessoa()
        {


        }
        public Pessoa(string nome)
        {
            Nome = nome;
        }          
    }
}
