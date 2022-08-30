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
        String Bairro;
        String Rua;
        String Numero;
        String Cidade;
        int Cep;

        public Endereco(String bairro, String rua, String numero, String cidade, int cep)
        {
            this.Bairro = bairro;
            this.Rua = rua;
            this.Numero = numero;
            this.Cidade = cidade;
            this.Cep = cep;
        }

        public Endereco(String cidade)
        {
            this.Cidade = cidade;
        }


    }
}
