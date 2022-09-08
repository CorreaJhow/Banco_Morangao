using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Conta_Poupanca : Conta
    {
        public String Numero { get; set; }
        public float SaldoContaPoupanca { get; set; }

        public Conta_Poupanca()
        {

        }
        public float ResgatarPoupanca(float saldoPoupanca, float valoResgate)
        {        
            float ResultadoPoupanca = saldoPoupanca - valoResgate;
            Console.WriteLine("Operação de resgate sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Operação realizada com sucesso!");
            return ResultadoPoupanca;
        }
    }
}
