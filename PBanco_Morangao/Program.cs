using System;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
            while (escolha != 1 && escolha != 2 && escolha != 3)
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
                    Console.WriteLine("");
                    Console.WriteLine("***ATENÇÃO*** Realizar um cadastro não necessariamente é abrir uma conta, então fique despreocupado, nosso sistema irá te direcionar, então apenas siga o passo a passo.");
                    Console.WriteLine("Aperte alguma tecla para inicar o processo...");
                    Console.ReadKey();
                    Console.Clear();
                    Cliente PrimeiroCliente = new Cliente();
                    Endereco PrimeiroEndereco = new Endereco();
                    PrimeiroCliente.Endereco = PrimeiroEndereco;
                    PrimeiroCliente.CadastrarCliente();
                    Console.WriteLine("");
                    Console.WriteLine(PrimeiroCliente.ToString());

                    Console.WriteLine("O Senhor " + PrimeiroCliente.Nome + " gostaria de Solicitar uma conta com nossa agencia do *Banco Morangao*\n01.Sim\n02.Nao");
                    int escolhaContinuacao = int.Parse(Console.ReadLine());
                    if (escolhaContinuacao == 1)
                    {
                        Console.WriteLine("Ok! Vamos seguir com o cadastro em nosso banco!");                     
                        double valorSalario = PrimeiroCliente.SolicitarAberturaConta();

                    }
                    else if (escolhaContinuacao == 2)
                    {
                        Console.WriteLine("Ok!! Vamos voltar ao menu inicial");
                        escolha = 4;
                    }



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
