using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBanco_Morangao
{
    internal class Conta
    {

        public float SaldoContaCorrente { get; set; }
        public int NumeroConta { get; set; }

        public String TipoConta { get; set; }

        public int Senha { get; set; }
        public float ValorChequeEspecial { get; set; }

        public Conta()
        {

        }

        public void SolicitarEmprestimo()
        {
            Console.WriteLine("Solicitação de emprestimo sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Solicitação enviada ao gerente!");
        }

        public void TransferirValor()
        {

        }

        public void ConsultarExtrato(List<string> ListaExtrato)
        {
            Console.Clear();
            Console.WriteLine("Voce escolheu a opção: Consultar Extrato.");
            Console.WriteLine("As movimentações realizadas foram:");
            ListaExtrato.ForEach(i => Console.WriteLine(i));
        }

        public float RealizarPagamento(float saldo, float valorPagamento)
        {

            float contaPaga = saldo - valorPagamento;
            Console.WriteLine("Pagamento de conta sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Pagamento Realizado com sucesso!");
            return contaPaga;
        }
        public float Saque(float saldoConta, float valorSaque)
        {
            Console.WriteLine("Operação de saque sendo realizada...");
            Thread.Sleep(2000);
            float resultadoSaque = saldoConta - valorSaque;
            Console.WriteLine("Operação de saque realizada com sucesso!");
            return resultadoSaque;
        }

        public float Depositar(float saldoConta, float valorDeposito)
        {
            Console.WriteLine("Operação de deposito sendo realizada...");
            Thread.Sleep(2000);
            float resultadoDeposito = saldoConta + valorDeposito;
            Console.WriteLine("Operação de deposito realizada com sucesso!");
            return resultadoDeposito;
        }
        public void ConsultarSaldo(float saldo, string nome, float chequeEspecial)
        {
            Console.WriteLine("Voce escolheu a opção: consultar saldo.");
            Console.WriteLine("Consulta de saldo sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Querido " + nome + ", no momento seu saldo é de R$" + saldo + " Moranguinhos.\nCom Cheque especial de: " + chequeEspecial + " moranguinhos");
        }
        public void VerLimiteChequeEspecial(double salario)
        {
            Console.WriteLine("O seu limite de cheque é especial é definido de acordo com seu salario.");
            Console.WriteLine("com o salario de RS$" + salario + " Moranguinhos.");
            Console.WriteLine("Consulta de Cheque especial sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("O valor do seu cheque especial é de: " + (salario * 0.25) + " Moranguinhos");
        }
        //public void menu();
    }
}

