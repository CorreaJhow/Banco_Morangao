# Projeto Banco Morangao #

## Banco desenvolvido em C# utilizando conceitos aprendidos no estágio, como: POO, Lista, entre outros. 

### Proposta Inicial do Banco: (Definida com o grupo) 
- Cadastrar Clientes 
- Entrar na conta (caso já existisse) 
- Remover Clientes
- Interação de cliente e funcionarios (Gerente e Agente Bancario)
- Funções triviais do Banco (Consultar Saldo, Saque, Deposito)

### Projeto entregue com:
- Cadastrar Clientes 
- Entrar na conta (caso já existisse) 
- Remover Clientes
- Interação de cliente e funcionarios (Gerente e Agente Bancario)
- Funções do Banco (Consultar Saldo, Saque, Deposito, Consultar Extrato, Realizar Pagamento de Conta, Ver Limite do Cheque Especial, Emprestimo, Acessar Conta Poupança, Resgate)
- Funções em desenvolvimento ainda: Acessar Cartão de Credito, Transferencia.

## Descrição de Métodos:

### Consultar Saldo: 
- Imprimi o valor (em "Moranguinhos", a moeda do banco), devolvendo o valor possível. Podendo ser negativo, desde que nao ultrapasse o valor do cheque especial. 
- Exemplo:
- Saldo == -10 Moranguinhos e Cheque Especial == 100
- Ele não decrementa diretamente do valor do cheque, mas com o valor do cheque estabelece um "limite negativo" a se sacar!

### Saque:
- Pede a inserção de um valor, fazendo a verificação se não ultrapassará o limite negativo (Cheque Especial), assim, dependendo da condição de ultrapassar ou não o cheque especial 
ele decrementa o valor da sua conta. 

### Deposito:
- Incrementa um valor em saldo da conta, só fazendo verificação se o valor inserido não é negativo. 

### Realizar Pagamento de Conta:
- Pede o numero da conta (a ser efetuada o pagamento), após receber o numero da cnota, recebe o valor da conta a ser pago e debita o valor do saldo da sua conta.

### Ver Limite do Cheque Especial:
- Demonstra como é efetuado o calculo do Cheque especial (baseado no salario do cliente) e mostra o valor do cheque. 

### Solicitar Emprestimo:
- Primeiro o cliente avalia a situação do cliente perante ao banco, se autorizado, demonstra o valor que pode ser retirado (emprestimo) e pergunta se voce deseja fazer o 
emprestimo ou não, se sim o valor é depositado em sua conta, se não apenas retorna ao menu. Se não autorizado apenas volta ao menu. 

### Acessar Conta Poupança:
- Acessa o menu da conta poupança, onde demonstra o o saldo do cliente em poupança e permite realizar as operações Resgate, Saque, Deposito, Consultar Extrato. O Saque, Deposito, Consultar Extrato
sendo herdados da outra conta (corrente), realizam os mesmo metodos, porém com verificações que nao incluem o valor negativo do cheque especial (mesmo que no extrato mostre o valor do cheque).

### Resgate (Conta Poupança):
- Realiza um debito da Conta poupança (é verificado se a quantidade esta disponivel no saldo da conta poupança) e esse mesmo valor é incrementado na Conta corrente.





