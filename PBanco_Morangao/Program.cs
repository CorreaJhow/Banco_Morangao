using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PBanco_Morangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            string tipoConta;
            bool saida = true;
            List<string> listaExtratoCC = new List<string>();
            List<string> listaExtratoP = new List<string>();

            while (escolha != 1 && escolha != 2 && escolha != 3)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
                Console.WriteLine("Escolha seu proximo passo: \n01.Se você ja for cliente \n02.Se você não for cliente \n03.Finalizar o programa");
                escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {
                    //função com duas etapas. 01- Buscar (de alguma maneira saber os clientes cadastrados) List ou Vetor. 
                    //02. Pedir validação do usuario.(CPF)
                }
                else if (escolha == 2)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Seja bem vindo novamente ao *BANCO MORANGAO* \nSiga o passo a passo e se cadastre em nossa rede: ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("***ATENÇÃO*** fique despreocupado, nosso sistema irá te direcionar, então apenas siga o passo a passo ***ATENÇÃO***");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    PressioneParaContinuar();
                    Console.Clear();

                    Agente_Bancario agente = new Agente_Bancario("Baratao", 1234); //agente bancario 
                    Gerente gerente = new Gerente("Tijolinho", 5050); //gerente bancario
                    Conta conta = new Conta(); //objeto de conta 
                    Conta_Poupanca contaPoupanca = new Conta_Poupanca();
                    Cartao_Credito cartaoCredito = new Cartao_Credito();
                    Cliente ClienteBanco = new Cliente(); //objeto de cliente 
                    Endereco PrimeiroEndereco = new Endereco(); //objeto de endereço 
                    ClienteBanco.Endereco = PrimeiroEndereco; //associação
                    
                    ClienteBanco.CadastrarCliente(); //realizar cadastro | COLOCAR EM UMA LISTAAAAAAAAAAAAAAAA
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
                        PressioneParaContinuar();

                        //**********************menu Conta Corrente***************************
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
                                conta.ConsultarSaldo(conta.SaldoContaCorrente, ClienteBanco.Nome);
                                Console.WriteLine("Pressione alguma tecla para voltar ao menu");
                                Console.ReadKey();

                            }
                            else if (escolhaAcao == 2) //saque 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Saque.");
                                Console.WriteLine("Insira o valor que deseja sacar: ");
                                float valorSaque = float.Parse(Console.ReadLine());
                                conta.SaldoContaCorrente = conta.Saque(conta.SaldoContaCorrente, valorSaque);
                                PressioneParaContinuar();
                                listaExtratoCC.Add("Saque de " + valorSaque + " Realizado");
                            }
                            else if (escolhaAcao == 3) //deposito 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Deposito.");
                                Console.WriteLine("Insira o valor que deseja depositar: ");
                                float valorDeposito = float.Parse(Console.ReadLine());
                                conta.SaldoContaCorrente = conta.Depositar(conta.SaldoContaCorrente, valorDeposito);
                                PressioneParaContinuar();
                                listaExtratoCC.Add("Deposito de " + valorDeposito + " Realizado");
                            }
                            else if (escolhaAcao == 4)//transferir 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Transferir.");
                                Console.WriteLine("O valor sera transferido de sua Conta corrente para Conta Poupança");
                                //listaExtratoCC.Add("Deposito de " + valorDeposito + " Realizado");
                            }
                            else if (escolhaAcao == 5) //solicitar emprestimo 
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Solicitar Emprestimo\nEntraremos em contato com o gerente: " + gerente.Nome + "para verificar tal situação.");
                                conta.SolicitarEmprestimo();
                                gerente.AutorizarEmprestimo(ClienteBanco.FaixaSalarial, gerente.Nome);
                                PressioneParaContinuar();
                            }
                            else if (escolhaAcao == 6)//consultar extrato
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Consultar Extrato.");
                                Console.WriteLine("As movimentações realizadas foram:");
                                listaExtratoCC.ForEach(i => Console.WriteLine(i));
                                PressioneParaContinuar();
                            }
                            else if (escolhaAcao == 7)//realizar pagamento
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: Realizar Pagamento.");
                                Console.WriteLine("Por favor, informe o numero da conta a ser paga: ");
                                int numeroConta = int.Parse(Console.ReadLine());
                                Console.WriteLine("Insira o valor da conta a ser pago: ");
                                int valorPagamento = int.Parse(Console.ReadLine());
                                conta.SaldoContaCorrente = conta.RealizarPagamento(conta.SaldoContaCorrente, valorPagamento);
                                PressioneParaContinuar();
                                listaExtratoCC.Add("Pagamento de " + valorPagamento + " Realizado");
                            }
                            else if (escolhaAcao == 8)//ver limite de cheque especial
                            {
                                Console.Clear();
                                Console.WriteLine("Voce escolheu a opção: ver limite de cheque especial.");
                                conta.VerLimiteChequeEspecial(ClienteBanco.FaixaSalarial);
                                PressioneParaContinuar();
                            }
                            else if (escolhaAcao == 9)//acessar cartao de credito 
                            {
                                //conta.AcessarCartaoCredito();
                            }
                            else if (escolhaAcao == 10)//acessar conta poupanca
                            {
                                MenuPoupanca(contaPoupanca.SaldoContaPoupanca, ClienteBanco, contaPoupanca, conta, listaExtratoP);
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

        public static void PressioneParaContinuar()
        {
            Console.WriteLine("Pressione alguma tecla para voltar ao menu");
            Console.ReadKey();
        }

        public static void MenuPoupanca(float saldoPoupanca, Cliente PrimeiroCliente, Conta_Poupanca contaPoupanca, Conta conta, List<string> listaExtratoP)
        {
            bool SaidaMenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("*****BANCO MORANGAO*****");
                Console.WriteLine("Conta poupança de: " + PrimeiroCliente.Nome);
                Console.WriteLine("Saldo atual: " + contaPoupanca.SaldoContaPoupanca);
                Console.WriteLine("Numero da Conta Poupança: " + (PrimeiroCliente.FaixaSalarial * 1428));
                Console.WriteLine("Operações possíveis a serem realizadas. \n1.Resgatar valor (enviar para conta corrente)" +
                    "\n2.Consultar Extrato \n3.Saque \n4.Deposito \n5.voltar ao menu geral");
                int escolhaAcao = int.Parse(Console.ReadLine());
                if (escolhaAcao == 1) //resgate
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Resgatar valor.");
                    Console.WriteLine("Digite um valor à ser resgatado para sua Conta Corrente: ");
                    float valoResgate = float.Parse(Console.ReadLine());
                    contaPoupanca.SaldoContaPoupanca = contaPoupanca.ResgatarPoupanca(contaPoupanca.SaldoContaPoupanca, valoResgate);
                    conta.SaldoContaCorrente = conta.SaldoContaCorrente + valoResgate;
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 2) //consultar extrato
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Consultar Extrato.\nAs movimenteações realizadas foram: ");
                    listaExtratoP.ForEach(i => Console.WriteLine(i));
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 3) //Saque
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Saque.");
                    Console.WriteLine("Informe o valor que deseja retirar: ");
                    float valorSaque = float.Parse(Console.ReadLine());
                    contaPoupanca.SaldoContaPoupanca = contaPoupanca.Saque(contaPoupanca.SaldoContaPoupanca, valorSaque);
                    listaExtratoP.Add("Saque de " + valorSaque + " Realizado");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 4) //Deposito 
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Deposito.");
                    Console.WriteLine("Insira o valor que deseja depositar: ");
                    float valorDeposito = float.Parse(Console.ReadLine());
                    conta.SaldoContaCorrente = contaPoupanca.Depositar(contaPoupanca.SaldoContaPoupanca, valorDeposito);
                    listaExtratoP.Add("Deposito de " + valorDeposito + " Realizado.");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 5) //voltar ao menu 
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: voltar ao menu geral.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Operação sendo realizada...");
                    SaidaMenu = false;
                }
            } while (SaidaMenu == true);
        }

    }
}

