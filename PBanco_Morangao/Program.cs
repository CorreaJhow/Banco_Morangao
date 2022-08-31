using System;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
            while (escolha != 3)
            {
                Console.WriteLine("Escolha seu proximo passo: \n01.Se você ja for cliente \n02.Se você não for cliente \n03.Finalizar o programa");
                escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {
                    Console.WriteLine("Mentira nao temos nenhum cliente ainda");
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("Seja bem vindo novamente ao *BANCO MORANGAO* \nSiga o passo a passo e se cadastre em nossa rede: ");

                
                }
                else if (escolha == 3)
                {
                    Console.WriteLine("Muito obrigado pela atenção, o programa sera finalizada, agradecemos a preferencia.");
                }
                else
                {
                    Console.WriteLine("Desculpa, mas o nosso sistema não reconhece essa opção :(\n");
                }
            }
        }
    }
}
