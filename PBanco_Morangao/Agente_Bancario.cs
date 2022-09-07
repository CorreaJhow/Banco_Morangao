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

        public string AvaliarTipoConta(double salario)
        {
            if (salario > 0 && salario <= 1500)
            {
                Console.WriteLine("de acordo com seu salario informado: '" + salario + "' o tipo de conta foi definido como ***CONTA UNIVERSITARIA***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (salario * 0.25) + " Moranguinhos");
                return "Universitaria";
            }
            else if (salario > 1500 && salario <= 5000)
            {
                Console.WriteLine("de acordo com seu salario informado: '" + salario + "' o tipo de conta foi definido como ***CONTA COMUM***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (salario * 0.25) + " Moranguinhos");
                return "Comum";
            }
            else 
            {
                Console.WriteLine("de acordo com seu salario informado: '" + salario + "' o tipo de conta foi definido como ***CONTA VIP***");
                Console.WriteLine("seguindo os padrões, com essa conta, seu cheque especial é R$" + (salario * 0.25) + " Moranguinhos");
                return "VIP";
            }          
        }
    }
}

