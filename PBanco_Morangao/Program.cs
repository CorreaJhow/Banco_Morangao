using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            float saldoContaCorrente = 0, saldoContaPoupanca = 0;
            string tipoConta;
            bool saida = true;

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
                    Console.WriteLine("");
                    Console.WriteLine("Seja bem vindo novamente ao *BANCO MORANGAO* \nSiga o passo a passo e se cadastre em nossa rede: ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("***ATENÇÃO*** fique despreocupado, nosso sistema irá te direcionar, então apenas siga o passo a passo ***ATENÇÃO***");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Aperte alguma tecla para inicar o processo...");
                    Console.ReadKey();
                    Console.Clear();

                    Agente_Bancario agente = new Agente_Bancario("David", 1234); //agente bancario 
                    Gerente gerente = new Gerente("Larissa", 5050); //gerente bancario
                    Conta conta = new Conta(); //objeto de conta 
                    Conta_Corrente contaCorrente = new Conta_Corrente();
                    Conta_Poupanca conta_Poupanca = new Conta_Poupanca();
                    Cliente ClienteBanco = new Cliente(); //objeto de cliente 
                    Endereco PrimeiroEndereco = new Endereco(); //objeto de endereço 
                    ClienteBanco.Endereco = PrimeiroEndereco; //associação

                    ClienteBanco.CadastrarCliente(); //realizar cadastro
                    Console.Clear();
                    Console.WriteLine("O cadastro foi realizado com SUCESSO! ");
                    Console.WriteLine(ClienteBanco.ToString()); //devolver valor.
                    Console.WriteLine("");
                    Console.WriteLine("O Senhor(a) " + ClienteBanco.Nome + " gostaria de Solicitar uma conta em nossa agencia do *Banco Morangao*\n01.Sim\n02.Nao");
                    int escolhaContinuacao = int.Parse(Console.ReadLine());
                    if (escolhaContinuacao == 1)
                    {
                        Console.WriteLine("Ok! Vamos seguir com a criação de conta em nosso banco!");
                        ClienteBanco.SolicitarAberturaConta();
                        Console.WriteLine("Nosso funcionario está analisando o tipo de conta...");
                        Thread.Sleep(2000);
                        tipoConta = agente.AvaliarTipoConta(ClienteBanco.FaixaSalarial);
                        Console.WriteLine("Pressione alguma tecla para prosseguir");
                        Console.ReadKey();
                        Console.WriteLine("O Gerente esta analisando a situação...");
                        Thread.Sleep(2500);
                        gerente.AutorizarAberturaConta(ClienteBanco.FaixaSalarial);
                        Console.WriteLine("Pressione alguma tecla para prosseguir");
                        Console.ReadKey();

                        //------------------------------------------------------------------menu conta principal//CC
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("*****BANCO MORANGAO*****");
                            Console.WriteLine(ClienteBanco.Nome + ", vai um morango? ");
                            Console.WriteLine("Numero da conta: " + ClienteBanco.Telefone * 2);
                            Console.WriteLine("Conta do tipo: " + tipoConta); //retornar tipo.
                            Console.WriteLine("Menu de ações: \n1.Consultar Saldo\n2.Saque\n3.Deposito\n4.Transferir Valor\n5.Solicitar Emprestimo\n6.Consultar Extrato\n7.Realizar Pagamentos\n8.Ver limite de Cheque Especial " +
                                "\n9.Acessar cartão de Credito\n10.Acessar Conta Poupança\n11.Voltar ao Menu Inicial.");
                            int escolhaAcao = int.Parse(Console.ReadLine());
                            if (escolhaAcao == 1) //consultar saldo 
                            {
                                Console.Clear();
                                conta.ConsultarSaldo(saldoContaCorrente, ClienteBanco.Nome);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 2) //saque 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Saque.");
                                Console.WriteLine("Insira o valor que deseja sacar: ");
                                float valorSaque = float.Parse(Console.ReadLine());
                                saldoContaCorrente = conta.Saque(saldoContaCorrente, valorSaque);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 3) //deposito 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Saque.");
                                Console.WriteLine("Insira o valor que deseja depositar: ");
                                float valorDeposito = float.Parse(Console.ReadLine());
                                saldoContaCorrente = conta.Depositar(saldoContaCorrente, valorDeposito);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 4)//transferir 
                            {
                                //transferir de conta corrente para conta poupanca.
                            }
                            else if (escolhaAcao == 5) //solicitar emprestimo 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Solicitar Emprestimo\nEntraremos em contato com o gerente: " + gerente.Nome + "para verificar tal situação.");
                                conta.SolicitarEmprestimo();
                                gerente.AutorizarEmprestimo(ClienteBanco.FaixaSalarial, gerente.Nome);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 6)//consultar extrato
                            {

                            }
                            else if (escolhaAcao == 7)//realizar pagamento
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Realizar Pagamento.");
                                saldoContaCorrente = conta.RealizarPagamento(saldoContaCorrente);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 8)//ver limite de cheque especial
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: ver limite de cheque especial.");
                                conta.VerLimiteChequeEspecial(ClienteBanco.FaixaSalarial);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();
                            }
                            else if (escolhaAcao == 9)//acessar cartao de credito 
                            {

                            }
                            else if (escolhaAcao == 10)//acessar conta poupanca
                            {
                                MenuPoupanca(saldoContaPoupanca, ClienteBanco);
                            }
                            else if (escolhaAcao == 11)//voltar ao menu inicial
                            {
                                Console.WriteLine("Você escolheu a opção: Voltar ao menu inicial;");
                                Console.WriteLine("Retornando ao menu inicial...");
                                Thread.Sleep(2000);
                                escolha = 4;
                                saida = false;
                            }
                        } while (saida == true);


                    }
                    else if (escolhaContinuacao == 2)
                    {
                        Console.WriteLine("Ok!! Vamos voltar ao menu inicial");
                        escolha = 4;
                    }
                }
                else if (escolha == 3)
                {
                    Console.WriteLine("Muito obrigado pela escolha do nosso banco, o programa sera finalizada, agradecemos a visita.");
                }
                else
                {
                    Console.WriteLine("Desculpa, mas o nosso sistema não reconhece essa opção :(\n");
                }
            }
        }

        private static void MenuPoupanca(double saldoPoupanca, Cliente PrimeiroCliente)
        {
            Console.Clear();
            Console.WriteLine("*****BANCO MORANGAO*****");
            Console.WriteLine("Conta poupança de: " + PrimeiroCliente.Nome);
            Console.WriteLine("Saldo atual: " + saldoPoupanca);
            Console.WriteLine("Numero da Conta Poupança: " + (PrimeiroCliente.FaixaSalarial * 1428));
            Console.WriteLine("Operações possíveis a serem realizadas. \n1.Resgatar valor (enviar para conta corrente)\n2.voltar ao menu geral");
            int escolhaAcao = int.Parse(Console.ReadLine());
            if (escolhaAcao == 1)
            {
                //chamar função de saque (em poupança) (substrair de poupança e somar em CC)
            }
            else if (escolhaAcao == 2)
            {
                //chamar função de menu total novamente.                          
            }
        }
    }
}
