using System;
using System.Threading;


namespace PBanco_Morangao
{
    internal class Gerente : Funcionario
    {
        public Gerente(string nome, int numeroRegistro) : base(nome, numeroRegistro)
        {

        }
        public bool AutorizarAberturaConta(double salary, int numeroAgencia)
        {
            if (salary < 500)
            {
                Console.WriteLine("Sua renda não atingiu a renda minima aceita, a abertura da conta foi negada!");
                return false;
            }
            else
            {
                Console.WriteLine("Sua conta foi aceita e criada em nosso banco!!!");
                Thread.Sleep(1000);
                Console.WriteLine("Sua agencia foi definida como agencia de Araraquara n°: " + numeroAgencia);
                return true;
            }
        }
        public float AutorizarEmprestimo(float salario, string gerente)
        {
            Console.WriteLine("Olá, sou o gerente " + gerente + " irei averiguar a sua solicitação de emprestimo...");
            Thread.Sleep(2000);
            Console.WriteLine("De acordo com seus dados, historico e faixa salarial o seu emprestimo foi autorizado!!");
            Console.WriteLine("O valor do nosso emprestimo é fixo e equivalente ao seu salario x 15, no caso, o salario informado foi: R$" + salario * 15 + " moranguinhos\n esse valor será parcelado em 36 vezes. Parabens!!");
            float valorEmprestimo = salario * 15;
            return valorEmprestimo;
        }
    }
}
