﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Agencia
    {
        public int NumeroAgencia { get; set; }
        Endereco endereco;

        void TrocarAgencia()
        {
            Endereco endereco = new Endereco();
        }
        public int Random(int min, int max)
        {
            Random r = new Random();
            return r.Next(100, 999);
        }
    }
}
