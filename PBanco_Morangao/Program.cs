using System;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
            Console.WriteLine("Digite a opção que deseja seguir abaixo: \n 1 - Se você ja for cliente \n 2 - Se você não for cliente \n 0 -  Finalizar o programa");
            opc = int.Parse(Console.ReadLine());
            do
            {
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Você selecionou 'Ja sou cliente'\n acessar conta");
                        break;
                    case 2:
                        Console.WriteLine("Você selecionou 'cadastrar cliente");
                        break;
                }
                Console.WriteLine("");
                Console.ReadKey();
                Console.WriteLine("0 - Sair");
                opc = int.Parse(Console.ReadLine());
            } while (opc != 0);
            Console.WriteLine("Programa Finalizado");
            // Console.WriteLine(pessoa.endereco);
        }
    }
}
