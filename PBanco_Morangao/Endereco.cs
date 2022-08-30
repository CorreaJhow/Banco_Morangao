using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Endereco
    {
        public String Bairro { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Cidade { get; set; }

        public Endereco(String bairro, String rua, String numero, String cidade)
        {
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
            this.Cidade = cidade;;
        }

        public Endereco()
        {
         
        }

        public override string ToString()
        {
            return "cidade: " + this.Cidade;
        }


    }
}
