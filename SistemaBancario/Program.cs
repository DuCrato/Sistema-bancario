using System;
using System.Collections.Generic;
using SistemaBancario.src.Classes;
using SistemaBancario.src.Enum;

namespace SistemaBancario
{
    class Program
    {
        static List<Account> listAccount = new List<Account>();

        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        TransferMoney();
                        break;
                    case "4":
                        WithdrawMoney();
                        break;
                    case "5":
                        CashDeposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = getUserOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListAccounts()
        {
            Console.WriteLine("\nListar Contas");

            if (listAccount.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada.");

                return;
            }

            for (int cont = 0; cont < listAccount.Count; cont++)
            {
                Account accountItem = listAccount[cont];
                Console.Write("#{0} - ", cont);
                Console.WriteLine(accountItem);
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Física ou 2 para conta Juridica: ");
            int inputAccountType = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string inputName = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double inputBalance = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o credito: ");
            double inputCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType : (AccountType)inputAccountType,
                                             balance     : inputBalance,
                                             credit      : inputCredit,
                                             name        : inputName);
            
            listAccount.Add(newAccount);
        }

        private static void TransferMoney()
        {
            Console.Write("Digite o número da conta de origem: ");
            int originAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int destinationAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccount[originAccount].Transfer(transferValue, listAccount[destinationAccount]);
        }

        private static void WithdrawMoney()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double withdrawalAmount = double.Parse(Console.ReadLine());

            listAccount[accountIndex].ToWithdraw(withdrawalAmount);
        }

        private static void CashDeposit()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double depositedAmount = double.Parse(Console.ReadLine());

            listAccount[accountIndex].Deposit(depositedAmount);
        }

        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu dispor!!!\n");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("\n1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}
