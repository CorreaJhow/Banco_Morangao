﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Conta_Corrente : Conta
    {
        public int NumeroCC { get; set; }
        public double SaldoCC { get; set; }
        public double ChequeEspecial { get; set; }

        public Conta_Corrente()
        {

        }
   
    }
}
