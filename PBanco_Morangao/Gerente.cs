using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Gerente:Funcionario
    {
        public Gerente(string nome, int numeroRegistro) : base(nome, numeroRegistro)
        {

        }

        public void AutorizarAberturaConta(double salary)
        {
            if (salary < 500)
            {
                Console.WriteLine("Sua renda não atingiu a renda minima aceita, a abertura da conta foi negada!");
            } else
                Console.WriteLine("Sua conta foi aceita e criada em nosso banco");         
        }

        public void AutorizarEmprestimo(double salario, string gerente)
        {
            Console.WriteLine("Olá, sou o gerente " + gerente + " irei averiguar a sua solicitação de emprestimo...");
            Thread.Sleep(2000);
            Console.WriteLine("De acordo com seus dados, historico e faixa salarial o seu emprestimo foi autorizado!!");
            Console.WriteLine("O valor sera equivalente ao seu salario RS" + salario + " moranguinhos x 15, no caso, R$" +(salario * 15) + " moranguinhos, parcelados em 36 vezes. Parabens!");
        }
    }
}
