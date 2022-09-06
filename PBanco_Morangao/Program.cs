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
            List<Cliente> listaClientes = new List<Cliente>();

            Agente_Bancario agente = new Agente_Bancario("Baratao", 1234); //agente bancario 
            Gerente gerente = new Gerente("Tijolinho", 5050); //gerente bancario
            Conta conta = new Conta(); //objeto de conta 
            Conta_Poupanca contaPoupanca = new Conta_Poupanca(); //objeto da classe poupanca 
            Cartao_Credito cartaoCredito = new Cartao_Credito(); //objeto da classe cartao 
            Cliente ClienteBanco = new Cliente(); //objeto de cliente 
            Endereco PrimeiroEndereco = new Endereco(); //objeto de endereço 
            ClienteBanco.Endereco = PrimeiroEndereco; //associação

            while (escolha != 1 && escolha != 2 && escolha != 3)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
                Console.WriteLine("Escolha seu proximo passo: \n1.Se você ja for cliente \n2.Se você não for cliente \n3.Finalizar o programa");
                escolha = int.Parse(Console.ReadLine());
                while(escolha <= 0 && escolha < 4)
                {
                    Console.WriteLine("o valor inserido não consta nas possibilidades de escolha!");
                    Console.WriteLine("Escolha seu proximo passo: \n1.Se você ja for cliente \n2.Se você não for cliente \n3.Finalizar o programa");
                    escolha = int.Parse(Console.ReadLine());
                }
                if (escolha == 1)
                {
                    Console.WriteLine("Digite um CPF para acessar sua conta: ");
                    //função com duas etapas. 01- Buscar (de alguma maneira saber os clientes cadastrados) List ou Vetor. 
                    //02. Pedir validação do usuario.(CPF)
                }
                else if (escolha == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Seja bem vindo novamente ao *BANCO MORANGAO* \nSiga o passo a passo e se cadastre em nossa rede: ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("***ATENÇÃO*** fique despreocupado, nosso sistema irá te direcionar, então apenas siga o passo a passo ***ATENÇÃO***");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    PressioneParaContinuar();
                    Console.Clear();

                    ClienteBanco.CadastrarCliente(); //realizar cadastro | COLOCAR EM UMA LISTAAAAAAAAAAAAAAAA
                    listaClientes.Add(ClienteBanco);
                    Console.Clear();
                    Console.WriteLine("O cadastro foi realizado com SUCESSO! ");
                    Console.WriteLine("alguns dados obtidos no cadastro foram: ");
                    Console.WriteLine(ClienteBanco.ToString()); //devolver valor.
                    Console.WriteLine("");
                    Console.WriteLine("O Senhor(a) " + ClienteBanco.Nome + " gostaria de continuar e seguir para conta em nossa agencia do *Banco Morangao*\n01.Sim\n02.Nao");
                    int escolhaContinuacao = int.Parse(Console.ReadLine());
                    while(escolhaContinuacao != 1 || escolhaContinuacao != 2)
                    {
                        Console.WriteLine("A opção informada é invalida!");
                        Console.WriteLine("O Senhor(a) " + ClienteBanco.Nome + " gostaria de continuar e seguir para conta em nossa agencia do *Banco Morangao*\n01.Sim\n02.Nao");
                        escolhaContinuacao = int.Parse(Console.ReadLine());
                    }
                    if (escolhaContinuacao == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ok! Vamos seguir com o sistema");
                        ClienteBanco.SolicitarAberturaConta();
                        Console.WriteLine("Nosso funcionario está analisando o tipo de conta...");
                        Thread.Sleep(2000);
                        tipoConta = agente.AvaliarTipoConta(ClienteBanco.FaixaSalarial);
                        Console.WriteLine("Pressione alguma tecla para prosseguir");
                        Console.ReadKey();
                        Console.WriteLine("O Gerente esta analisando a situação...");
                        Thread.Sleep(2500);
                        bool verificarAutorizacao = gerente.AutorizarAberturaConta(ClienteBanco.FaixaSalarial);

                        if (verificarAutorizacao == true)
                        {
                            PressioneParaContinuar();
                            //**********************Menu Conta Corrente***************************
                                float LimiteCartao = ClienteBanco.FaixaSalarial * 2;
                                float LimiteChequeEspecial = (ClienteBanco.FaixaSalarial / 4);
                            do
                            {
                                Console.Clear();
                                MargemContaCorrente();
                                Console.WriteLine(ClienteBanco.Nome + ", vai um morango? ");
                                Console.WriteLine("Numero da conta: " + ClienteBanco.Telefone * 2);
                                Console.WriteLine("Conta do tipo: " + tipoConta); //retornar tipo.
                                Console.WriteLine("Menu de ações: \n1.Consultar Saldo\n2.Saque\n3.Deposito\n4.Transferir Valor\n5.Solicitar Emprestimo\n6.Consultar Extrato\n7.Realizar Pagamentos\n8.Ver limite de Cheque Especial " +
                                    "\n9.Acessar cartão de Credito\n10.Acessar Conta Poupança\n11.Voltar ao Menu Inicial.");
                                int escolhaAcao = int.Parse(Console.ReadLine());
                                while(escolhaAcao <= 0 || escolhaAcao > 12)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Menu de ações: \n1.Consultar Saldo\n2.Saque\n3.Deposito\n4.Transferir Valor\n5.Solicitar Emprestimo\n6.Consultar Extrato\n7.Realizar Pagamentos\n8.Ver limite de Cheque Especial " +
                                   "\n9.Acessar cartão de Credito\n10.Acessar Conta Poupança\n11.Voltar ao Menu Inicial.");
                                    escolhaAcao = int.Parse(Console.ReadLine());
                                }
                                if (escolhaAcao == 1) //consultar saldo 
                                {
                                    Console.Clear();
                                    conta.ConsultarSaldo(conta.SaldoContaCorrente, ClienteBanco.Nome, LimiteChequeEspecial);
                                    PressioneParaContinuar();
                                }
                                else if (escolhaAcao == 2) //saque 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Voce escolheu a opção: Saque.\nSeu saldo atual é de: " + conta.SaldoContaCorrente + " moranguinhos, e cheque especial de: " + LimiteChequeEspecial + " moranguinhos.");
                                    Console.WriteLine("Insira o valor que deseja sacar: ");
                                    float valorSaque = float.Parse(Console.ReadLine());
                                    if (conta.SaldoContaCorrente - valorSaque < (LimiteChequeEspecial*-1))
                                    {
                                        Console.WriteLine("O seu saldo é insuficiente para esta operacao!!");
                                        PressioneParaContinuar();
                                    }
                                    else
                                    {
                                        conta.SaldoContaCorrente = conta.Saque(conta.SaldoContaCorrente, valorSaque);
                                        PressioneParaContinuar();
                                        listaExtratoCC.Add("Saque de " + valorSaque + " moranguinhos realizado!");
                                    }
                                }
                                else if (escolhaAcao == 3) //deposito 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Voce escolheu a opção: Deposito.");
                                    Console.WriteLine("Insira o valor que deseja depositar: ");
                                    float valorDeposito = float.Parse(Console.ReadLine());
                                    while(valorDeposito < 0)
                                    {
                                        Console.WriteLine("Opçao escolhida inválida!");
                                        Console.WriteLine("Insira novamente o valor que deseja depositar: ");
                                        valorDeposito = float.Parse(Console.ReadLine());
                                    }
                                    conta.SaldoContaCorrente = conta.Depositar(conta.SaldoContaCorrente, valorDeposito);
                                    PressioneParaContinuar();
                                    listaExtratoCC.Add("Deposito de " + valorDeposito + " Realizado");
                                }
                                else if (escolhaAcao == 4)//transferir 
                                {
                                    Console.Clear();
                                    Console.WriteLine("FUNÇÃO NAO DSENVOLVIDA");
                                    //listaExtratoCC.Add("Deposito de " + valorDeposito + " Realizado");
                                }
                                else if (escolhaAcao == 5) //solicitar emprestimo 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Voce escolheu a opção: Solicitar Emprestimo\nEntraremos em contato com o gerente: " + gerente.Nome + " para verificar tal situação.");
                                    conta.SolicitarEmprestimo();
                                    float valorEmprestimo = gerente.AutorizarEmprestimo(ClienteBanco.FaixaSalarial, gerente.Nome);
                                    Console.WriteLine("Voce gostaria de realizar o emprestimo? pensem bem. \n1. Sim, eu amo emprestimos \n2. nao, odeio morangos");
                                    int opc = int.Parse(Console.ReadLine());
                                    if (opc == 1)
                                    {
                                        conta.SaldoContaCorrente = conta.SaldoContaCorrente + valorEmprestimo;
                                        PressioneParaContinuar();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Obrigado, volte quando for necessario!");
                                        PressioneParaContinuar();
                                    }
                                }
                                else if (escolhaAcao == 6)//consultar extrato
                                {
                                    conta.ConsultarExtrato(listaExtratoCC);
                                    PressioneParaContinuar();
                                }
                                else if (escolhaAcao == 7)//realizar pagamento de alguma conta
                                {
                                    Console.Clear();
                                    Console.WriteLine("Voce escolheu a opção: Realizar Pagamento.");
                                    Console.WriteLine("Por favor, informe o numero da conta a ser paga: ");
                                    int numeroConta = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Insira o valor da conta a ser pago: ");
                                    int valorPagamento = int.Parse(Console.ReadLine());
                                    if (conta.SaldoContaCorrente - valorPagamento > (LimiteChequeEspecial * -1))
                                    {
                                        Console.WriteLine("Impossivel realizar pagamento, saldo insuficiente!");
                                        PressioneParaContinuar();
                                    }
                                    else
                                    {
                                    conta.SaldoContaCorrente = conta.RealizarPagamento(conta.SaldoContaCorrente, valorPagamento);
                                    PressioneParaContinuar();
                                    listaExtratoCC.Add("Pagamento de " + valorPagamento + " Realizado");
                                    }
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
                        else
                        {
                            Console.WriteLine("O banco agradece, o programa sera encerrado. ");
                            Thread.Sleep(2000);
                        }
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

        private static void MargemContaCorrente()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                      BANCO MORANGAO - Conta Corrente                                            |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
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
                MargemContaPoupanca();
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
                    listaExtratoP.Add("Resgate de " + valoResgate + " Realizado");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 2) //consultar extrato
                {
                    conta.ConsultarExtrato(listaExtratoP);
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 3) //Saque
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Saque.");
                    Console.WriteLine("Informe o valor que deseja retirar: ");
                    float valorSaque = float.Parse(Console.ReadLine());
                    if (contaPoupanca.SaldoContaPoupanca - valorSaque <= 0)
                    {
                        Console.WriteLine("Impossivel realizar tal operação, saldo insuficiente");
                        PressioneParaContinuar();
                    }
                    else
                    {
                        contaPoupanca.SaldoContaPoupanca = contaPoupanca.Saque(contaPoupanca.SaldoContaPoupanca, valorSaque);
                        listaExtratoP.Add("Saque de " + valorSaque + " Realizado");
                        PressioneParaContinuar();
                    }
                }
                else if (escolhaAcao == 4) //Deposito 
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Deposito.");
                    Console.WriteLine("Insira o valor que deseja depositar: ");
                    float valorDeposito = float.Parse(Console.ReadLine());
                    contaPoupanca.SaldoContaPoupanca = contaPoupanca.Depositar(contaPoupanca.SaldoContaPoupanca, valorDeposito);
                    listaExtratoP.Add("Deposito de " + valorDeposito + " Realizado.");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 5) //voltar ao menu 
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: voltar ao menu geral.");
                    Thread.Sleep(2000);
                    SaidaMenu = false;
                }
            } while (SaidaMenu == true);
        }
        private static void MargemContaPoupanca()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                      BANCO MORANGAO - Conta Poupanca                                            |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
        }
    }
}

