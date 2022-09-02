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
        public int NumeroConta { get; set; }

        public String TipoConta { get; set; }

        public int Senha { get; set; }

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

        public void ConsultarExtrato()
        {

        }
        public float RealizarPagamento(float saldo)
        {
            Console.WriteLine("Por favor, informe o numero da conta a ser paga: ");
            int numeroConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o valor da conta a ser pago: ");
            int valorPagamento = int.Parse(Console.ReadLine());
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
            float resultadoSaque = saldoConta + valorDeposito;
            Console.WriteLine("Operação de deposito realizada com sucesso!");
            return resultadoSaque;
        }
        public void ConsultarSaldo(float saldo, string nome)
        {
            Console.WriteLine("Voce escolheu a opção: consultar saldo.");
            Console.WriteLine("Consulta de saldo sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("Querido " + nome + ", no momento seu saldo é de R$" + saldo + " moranguinhos.");
        }
        public void VerLimiteChequeEspecial(double salario)
        {
            Console.WriteLine("O seu limite de cheque é especial é definido de acordo com seu salario.");
            Console.WriteLine("no caso de RS$" + salario + " moranguinhos.");
            Console.WriteLine("Consulta de Cheque especial sendo realizada...");
            Thread.Sleep(2000);
            Console.WriteLine("O valor do seu cheque especial é de: " + (salario * 0.25));
        }
    }
}
