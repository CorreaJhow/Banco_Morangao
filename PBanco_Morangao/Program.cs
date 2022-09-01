using System;
using System.Runtime.CompilerServices;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
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

                    Agente_Bancario agente = new Agente_Bancario("David",1234); //agente bancario 
                    Gerente gerente = new Gerente("Larissa", 5050); //gerente bancario

                    Cliente PrimeiroCliente = new Cliente(); //objeto de cliente 
                    Endereco PrimeiroEndereco = new Endereco(); //objeto de endereço 
                    PrimeiroCliente.Endereco = PrimeiroEndereco; //associação

                    PrimeiroCliente.CadastrarCliente(); //realizar cadastro 
                    Console.WriteLine("");
                    Console.WriteLine(PrimeiroCliente.ToString()); //devolver valor.

                    Console.WriteLine("O Senhor(a) " + PrimeiroCliente.Nome + " gostaria de Solicitar uma conta em nossa agencia do *Banco Morangao*\n01.Sim\n02.Nao");
                    int escolhaContinuacao = int.Parse(Console.ReadLine());
                    if (escolhaContinuacao == 1)
                    {
                        Console.WriteLine("Ok! Vamos seguir com a criação de conta em nosso banco!");                     
                        PrimeiroCliente.SolicitarAberturaConta();
                        agente.AvaliarTipoConta(PrimeiroCliente.FaixaSalarial);
                        gerente.AutorizarAberturaConta(PrimeiroCliente.FaixaSalarial);

                        //ir pro menu do banco.
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
