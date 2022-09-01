using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void AutorizarEmprestimo()
        {

        }
    }
}
