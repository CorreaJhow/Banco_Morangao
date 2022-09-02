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

        public string AvaliarTipoConta(double Salary)
        {
            if (Salary > 0 && Salary <= 1500)
            {
                Console.WriteLine("de acordo com seu salario informado: '" + Salary + "' o tipo de conta foi definido como ***CONTA UNIVERSITARIO***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (Salary * 0.25) + " moranguinhos, e seu limite (cartao de credito) é R$" + (Salary * 2) + " moranguinhos");
                return "Universitaria";
            }
            else if (Salary > 1500 && Salary <= 5000)
            {
                Console.WriteLine("de acordo com seu salario informado: '" + Salary + "' o tipo de conta foi definido como ***CONTA COMUM***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (Salary * 0.25) + " moranguinhos, e seu limite (cartao de credito) é R$" + (Salary * 2) + " moranguinhos");
                return "Comum";
            }
            else //if (Salary > 5000)
            {
                Console.WriteLine("de acordo com seu salario informado: '" + Salary + "' o tipo de conta foi definido como ***CONTA VIP***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (Salary * 0.25) + " moranguinhos, e seu limite (cartao de credito) é R$" + (Salary * 2) + " moranguinhos");
                return "VIP";
            }          
        }
    }
}

