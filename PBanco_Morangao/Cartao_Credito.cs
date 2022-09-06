using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Cartao_Credito
    {
        public int LimiteCredito { get; set; }
        public int NumeroCartao { get; set; }
        public DateTime DataValidade { get; set; }
        public String Nome { get; set; }
        public bool EstadoDoCartao { get; set; }

        public Cartao_Credito()
        {

        }
        public void DesbloquearCartao()
        {

        }
    }
}
