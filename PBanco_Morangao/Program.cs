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
            bool saida = true;
            List<string> listaExtratoCC = new List<string>();
            List<string> listaExtratoP = new List<string>();
            List<Cliente> listaClientes = new List<Cliente>();
            Agente_Bancario agente = new Agente_Bancario("Baratao", 1234);
            Gerente gerente = new Gerente("Tijolinho", 5050);
            Conta_Poupanca contaPoupanca = new Conta_Poupanca();
            while (escolha == 0 || escolha > 3)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema do Banco Morangão");
                Console.WriteLine("Escolha seu proximo passo: \n[1] Se você ja for cliente \n[2] Se você não for cliente \n[3] Finalizar o programa");
                escolha = int.Parse(Console.ReadLine());
                while (escolha < 1 && escolha > 3)
                {
                    Console.WriteLine("Opção inválida informada, insira outro valor!");
                    Console.WriteLine("Escolha seu proximo passo: \n[1] Se você ja for cliente \n[2] Se você não for cliente \n[3] Finalizar o programa");
                    escolha = int.Parse(Console.ReadLine());
                }
                if (escolha == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Opção: 'Já sou Cliente' ");
                        Console.WriteLine("Informe seu CPF para procurarmos em nosso Banco de Dados: ");
                        string documentoValidacao = Console.ReadLine();
                        Cliente buscaCliente = null;
                        foreach (Cliente cliente in listaClientes)
                        {
                            if (documentoValidacao == cliente.Cpf)
                            {
                                buscaCliente = cliente;
                            }
                        }
                        if (buscaCliente == null)
                        {
                            Console.WriteLine("A conta nao foi encontrada");
                            PressioneParaContinuar();
                            escolha = 4;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(buscaCliente.Nome + "Voce gostaria de: \n[1] Acessar sua conta \n[2] Excluir sua conta");
                            int acaoCliente = int.Parse(Console.ReadLine());
                            while (acaoCliente < 1 && acaoCliente > 2)
                            {
                                Console.Clear();
                                Console.WriteLine("O valor informado é inválido, informe novamente. ");
                                Console.WriteLine("");
                                Console.WriteLine(buscaCliente.Nome + "Voce gostaria de: \n[1] Acessar sua conta \n[2] Excluir sua conta");
                                acaoCliente = int.Parse(Console.ReadLine());
                            }
                            if (acaoCliente == 1)
                            {
                                MenuContaCorrente(ref escolha, ref saida, listaExtratoCC, listaExtratoP, gerente, contaPoupanca, buscaCliente);
                            }
                            else if (acaoCliente == 2)
                            {
                                Console.WriteLine("Voce tem certeza que deseja EXCLUIR SUA CONTA?! \n[1] Sim, odeio o banco moranguinho :( \n[2] não, to de zoas");
                                int opc = int.Parse(Console.ReadLine());
                                while (opc < 1 && opc > 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("O valor informado é inválido, informe novamente.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Voce tem certeza que deseja EXCLUIR SUA CONTA?! [1] Sim, odeio o banco moranguinho :( [2] não, to de zoas");
                                    opc = int.Parse(Console.ReadLine());
                                }
                                if (opc == 1)
                                {
                                    listaClientes.Remove(buscaCliente);
                                    Console.WriteLine("Sua conta foi removida com sucesso, obrigado pela atenção!");
                                    PressioneParaContinuar();
                                    escolha = 4;
                                    break;
                                }
                                else if (opc == 2)
                                {
                                    Console.WriteLine("Dessa vez foi quase ein rsrs");
                                    PressioneParaContinuar();
                                    escolha = 4;
                                    break;
                                }
                            }
                        }
                    } while (true);
                }
                else if (escolha == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Seja bem vindo ao *BANCO MORANGAO* \nSiga o passo a passo e se cadastre em nossa rede: ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("***ATENÇÃO*** fique despreocupado, nosso sistema irá te direcionar, então apenas siga o passo a passo ***ATENÇÃO***");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    PressioneParaContinuar();
                    Console.Clear();


                    Cliente ClienteBanco = new Cliente();
                    ClienteBanco.Endereco = new Endereco();
                    ClienteBanco.CadastrarCliente();
                    listaClientes.Add(ClienteBanco);
                    Console.Clear();
                    Console.WriteLine("Os dados foram recebidos com SUCESSO! ");
                    Console.WriteLine("alguns dados obtidos no cadastro foram: ");
                    Console.WriteLine(ClienteBanco.ToString());
                    ClienteBanco.Conta = new Conta();
                    Console.Clear();
                    Console.WriteLine("Vamos seguir com o sistema");                 
                    Console.WriteLine("O Gerente esta analisando a situação...");
                    Thread.Sleep(2500);
                    Agencia agencia = new Agencia();
                    agencia.NumeroAgencia = 100;
                    bool verificarAutorizacao = gerente.AutorizarAberturaConta(ClienteBanco.FaixaSalarial, agencia.NumeroAgencia); ;
                    ClienteBanco.Conta.LimiteChequeEspecial = (ClienteBanco.FaixaSalarial / 4);

                    if (verificarAutorizacao)
                    {
                        ClienteBanco.SolicitarAberturaConta();
                        Console.WriteLine("Nosso funcionario " + agente.Nome + " está analisando o tipo de conta...");
                        Thread.Sleep(2000);
                        ClienteBanco.Conta.TipoConta = agente.AvaliarTipoConta(ClienteBanco.FaixaSalarial);
                        PressioneParaContinuar();
                        MenuContaCorrente(ref escolha, ref saida, listaExtratoCC, listaExtratoP, gerente, contaPoupanca, ClienteBanco);
                    }
                    else
                    {
                        Console.WriteLine("O banco agradece, o programa sera reiniciado. ");
                        escolha = 4;
                        PressioneParaContinuar();
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

        private static void MenuContaCorrente(ref int escolha, ref bool saida, List<string> listaExtratoCC, List<string> listaExtratoP, Gerente gerente, Conta_Poupanca contaPoupanca, Cliente ClienteBanco)
        {
            do
            {
                Console.Clear();
                MargemContaCorrente();
                Console.WriteLine(ClienteBanco.Nome + ", vai um morango? ");
                Console.WriteLine("Numero da conta: " + ClienteBanco.Telefone * 2);
                Console.WriteLine("Conta do tipo: " + ClienteBanco.Conta.TipoConta);
                Console.WriteLine("Menu de ações: \n[1] Consultar Saldo\n[2] Saque\n[3] Deposito\n[4] Transferir Valor\n[5] Solicitar Emprestimo\n[6] Consultar Extrato\n[7] Realizar Pagamentos\n[8] Ver limite de Cheque Especial " +
                    "\n[9] Acessar cartão de Credito\n[10] Acessar Conta Poupança\n[11] Voltar ao Menu Inicial.");
                int escolhaAcao = int.Parse(Console.ReadLine());
                while (escolhaAcao <= 0 || escolhaAcao > 12)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Menu de ações: \n[1] Consultar Saldo\n[2] Saque\n[3] Deposito\n[4] Transferir Valor\n[5] Solicitar Emprestimo\n[6] Consultar Extrato\n[7] Realizar Pagamentos\n[8] Ver limite de Cheque Especial " +
                    "\n[9] Acessar cartão de Credito\n[10] Acessar Conta Poupança\n[11] Voltar ao Menu Inicial.");
                    escolhaAcao = int.Parse(Console.ReadLine());
                }
                if (escolhaAcao == 1)
                {
                    Console.Clear();
                    ClienteBanco.Conta.ConsultarSaldo(ClienteBanco.Conta.SaldoContaCorrente, ClienteBanco.Nome);
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Saque.\nSeu saldo atual é de: " + ClienteBanco.Conta.SaldoContaCorrente + " moranguinhos, e cheque especial de: " + ClienteBanco.Conta.LimiteChequeEspecial + " Moranguinhos.");
                    Console.WriteLine("Insira o valor que deseja sacar: ");
                    float valorSaque = float.Parse(Console.ReadLine());
                    while (valorSaque <= 0)
                    {
                        Console.WriteLine("Insira um valor positivo!");
                        Console.WriteLine("");
                        Console.WriteLine("Insira o valor que deseja sacar: ");
                        valorSaque = float.Parse(Console.ReadLine());
                    }
                    if (ClienteBanco.Conta.SaldoContaCorrente - valorSaque < (ClienteBanco.Conta.LimiteChequeEspecial * -1))
                    {
                        Console.WriteLine("O seu saldo é insuficiente para esta operacao!!");
                        PressioneParaContinuar();
                    }
                    else
                    {
                        ClienteBanco.Conta.SaldoContaCorrente = ClienteBanco.Conta.Saque(ClienteBanco.Conta.SaldoContaCorrente, valorSaque);
                        PressioneParaContinuar();
                        listaExtratoCC.Add("Saque de " + valorSaque + " moranguinhos realizado!");
                    }
                }
                else if (escolhaAcao == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Deposito.");
                    Console.WriteLine("Insira o valor que deseja depositar: ");
                    float valorDeposito = float.Parse(Console.ReadLine());
                    while (valorDeposito <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Opçao escolhida inválida!");
                        Console.WriteLine("");
                        Console.WriteLine("Insira novamente o valor que deseja depositar: ");
                        valorDeposito = float.Parse(Console.ReadLine());
                    }
                    ClienteBanco.Conta.SaldoContaCorrente = ClienteBanco.Conta.Depositar(ClienteBanco.Conta.SaldoContaCorrente, valorDeposito);
                    PressioneParaContinuar();
                    listaExtratoCC.Add("Deposito de " + valorDeposito + " Realizado");
                }
                else if (escolhaAcao == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Esta opção indisponivel no momento, o banco esta em desenvolvimento!");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Solicitar Emprestimo\nEntraremos em contato com o gerente: " + gerente.Nome + " para verificar tal situação.");
                    ClienteBanco.Conta.SolicitarEmprestimo();
                    float valorEmprestimo = gerente.AutorizarEmprestimo(ClienteBanco.FaixaSalarial, gerente.Nome);
                    Console.WriteLine("Voce gostaria de realizar o emprestimo? pensem bem. \n[1] Sim, eu amo emprestimos \n[2] Nao, odeio morangos");
                    int opc = int.Parse(Console.ReadLine());
                    while (opc != 1 && opc != 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Valor inválido inserido!");
                        Console.WriteLine("");
                        Console.WriteLine("Voce gostaria de realizar o emprestimo? pensem bem. \n[1] Sim, eu amo emprestimos \n[2] Nao, odeio morangos");
                        opc = int.Parse(Console.ReadLine());
                    }
                    if (opc == 1)
                    {
                        ClienteBanco.Conta.SaldoContaCorrente = ClienteBanco.Conta.SaldoContaCorrente + valorEmprestimo;
                        PressioneParaContinuar();
                    }
                    else if (opc == 2)
                    {
                        Console.WriteLine("Obrigado, volte quando for necessario!");
                        PressioneParaContinuar();
                    }
                }
                else if (escolhaAcao == 6)
                {
                    ClienteBanco.Conta.ConsultarExtrato(listaExtratoCC, ClienteBanco.Conta.SaldoContaCorrente, ClienteBanco.Conta.LimiteChequeEspecial);
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Realizar Pagamento.");
                    Console.WriteLine("Por favor, informe o numero da conta a ser paga: ");
                    int numeroConta = int.Parse(Console.ReadLine());
                    while (numeroConta < 0)
                    {
                        Console.WriteLine("Valor inválido de conta inserido, informe novamente! ");
                        Console.WriteLine("");
                        Console.WriteLine("Por favor, informe o numero da conta a ser paga: ");
                        numeroConta = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Insira o valor da conta a ser pago: ");
                    int valorPagamento = int.Parse(Console.ReadLine());
                    while (valorPagamento < 0)
                    {
                        Console.WriteLine("Valor inválido inserido, insira um valor positivo!");
                        Console.WriteLine("");
                        Console.WriteLine("Insira o valor da conta a ser pago: ");
                        valorPagamento = int.Parse(Console.ReadLine());
                    }
                    if (ClienteBanco.Conta.SaldoContaCorrente - valorPagamento < (ClienteBanco.Conta.LimiteChequeEspecial * -1))
                    {
                        Console.WriteLine("Impossivel realizar pagamento, saldo insuficiente!");
                        PressioneParaContinuar();
                    }
                    else
                    {
                        ClienteBanco.Conta.SaldoContaCorrente = ClienteBanco.Conta.RealizarPagamento(ClienteBanco.Conta.SaldoContaCorrente, valorPagamento);
                        PressioneParaContinuar();
                        listaExtratoCC.Add("Pagamento de " + valorPagamento + " Realizado");
                    }
                }
                else if (escolhaAcao == 8)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: ver limite de cheque especial.");
                    ClienteBanco.Conta.VerLimiteChequeEspecial(ClienteBanco.FaixaSalarial);
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 9)
                {
                    Console.Clear();
                    Console.WriteLine("Função em desenvolvimento ainda, retornará em breve! ");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 10)
                {
                    MenuPoupanca(contaPoupanca.SaldoContaPoupanca, ClienteBanco, contaPoupanca, ClienteBanco.Conta, listaExtratoP);
                }
                else if (escolhaAcao == 11)
                {
                    Console.WriteLine("Você escolheu a opção: Voltar ao menu inicial;");
                    Console.WriteLine("Retornando ao menu inicial...");
                    Thread.Sleep(2000);
                    escolha = 4;
                    saida = false;
                }
            } while (saida);
        }

        private static void MargemContaCorrente()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                      BANCO MORANGAO - Conta Corrente                                            |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
        }

        public static void PressioneParaContinuar()
        {
            Console.WriteLine("Pressione alguma tecla para prosseguir...");
            Console.ReadKey();
        }

        public static void MenuPoupanca(float saldoPoupanca, Cliente PrimeiroCliente, Conta_Poupanca contaPoupanca, Conta conta, List<string> listaExtratoP)
        {
            bool SaidaMenu = true;
            do
            {
                Console.Clear();
                MargemContaPoupanca();
                Console.WriteLine("Numero da Conta Poupança: " + (PrimeiroCliente.FaixaSalarial * 1428));
                Console.WriteLine("Conta poupança de: " + PrimeiroCliente.Nome);
                Console.WriteLine("Saldo atual: " + contaPoupanca.SaldoContaPoupanca);
                Console.WriteLine("Operações possíveis a serem realizadas. \n[1] Resgatar valor (enviar para conta corrente)" +
                    "\n[2] Consultar Extrato \n[3] Saque \n[4] Depósito \n[5] Voltar ao menu da Conta Corrente");
                int escolhaAcao = int.Parse(Console.ReadLine());
                while (escolhaAcao <= 0 && escolhaAcao > 5)
                {
                    Console.WriteLine("Opção invalida de escolha, insira um valor valido!");
                    escolhaAcao = int.Parse(Console.ReadLine());
                }
                if (escolhaAcao == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Resgatar valor.");
                    Console.WriteLine("Digite um valor à ser resgatado para sua Conta Corrente: ");
                    float valoResgate = float.Parse(Console.ReadLine());
                    while (valoResgate <= 0)
                    {
                        Console.WriteLine("Valor inválido de Resgate, informe um valor positivo!");
                        valoResgate = float.Parse(Console.ReadLine());

                    }
                    if (contaPoupanca.SaldoContaPoupanca - valoResgate < 0)
                    {
                        Console.WriteLine("Impossivel realizar tal operação, saldo insuficiente");
                        PressioneParaContinuar();
                    }
                    else
                    {
                        contaPoupanca.SaldoContaPoupanca = contaPoupanca.ResgatarPoupanca(contaPoupanca.SaldoContaPoupanca, valoResgate);
                        conta.SaldoContaCorrente = conta.SaldoContaCorrente + valoResgate;
                        listaExtratoP.Add("Resgate de " + valoResgate + " Realizado");
                        PressioneParaContinuar();
                    }
                }
                else if (escolhaAcao == 2)
                {
                    conta.ConsultarExtrato(listaExtratoP, contaPoupanca.SaldoContaPoupanca, contaPoupanca.LimiteChequeEspecial);
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Saque.");
                    Console.WriteLine("Informe o valor que deseja retirar: ");
                    float valorSaque = float.Parse(Console.ReadLine());
                    while (valorSaque <= 0)
                    {
                        Console.WriteLine("Valor inválido de saque, informe um valor positivo!");
                        valorSaque = float.Parse(Console.ReadLine());
                    }
                    if (contaPoupanca.SaldoContaPoupanca - valorSaque < 0)
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
                else if (escolhaAcao == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: Depósito.");
                    Console.WriteLine("Insira o valor que deseja depositar: ");
                    float valorDeposito = float.Parse(Console.ReadLine());
                    while (valorDeposito <= 0)
                    {
                        Console.WriteLine("Valor inválido de depósito, insira um valor positivo! ");
                        valorDeposito = float.Parse(Console.ReadLine());
                    }
                    contaPoupanca.SaldoContaPoupanca = contaPoupanca.Depositar(contaPoupanca.SaldoContaPoupanca, valorDeposito);
                    listaExtratoP.Add("Deposito de " + valorDeposito + " Realizado.");
                    PressioneParaContinuar();
                }
                else if (escolhaAcao == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Voce escolheu a opção: voltar ao Menu da Conta Corrente.");
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

