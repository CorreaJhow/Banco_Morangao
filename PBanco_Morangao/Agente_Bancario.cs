using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Agente_Bancario : Funcionario
    {
        public Agente_Bancario(string nome, int numeroRegistro) : base(nome, numeroRegistro)
        {
            this.Nome = nome;
            this.NumeroRegistro = numeroRegistro;
        }

        public void AvaliarTipoConta(double Salary)
        { 
            if (Salary > 0 && Salary <= 1500)
            {
                Console.WriteLine("O seu tipo de conta foi definido como ***CONTA UNIVERSITARIO***");
            }
            else if (Salary > 1500 && Salary <= 5000)
            {
                Console.WriteLine("O seu tipo de conta foi definido como ***CONTA NORMAL***");            
            }
            else if (Salary > 5000)
            {
                Console.WriteLine("O seu tipo de conta foi definido como ***CONTA VIP***");              
            }
        }
    }
}
