using System;
using SistemaBancario.src.Enum;

namespace SistemaBancario.src.Classes
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double      Balance     { get; set; }
        private double      Credit      { get; set; }
        private string      Name        { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance     = balance;
            this.Credit      = credit;
            this.Name        = name;
        }

        public bool ToWithdraw(double toWithdrawValue)
        {
            if (this.Balance - toWithdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente!");

                return false;
            }
            this.Balance -= toWithdrawValue;

            Console.WriteLine("Saldo atual da conta {0} é: {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;

            Console.WriteLine("Saldo atual da conta {0} é: {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account destinationAccount)
        {
            if (this.ToWithdraw(transferValue))
            {
                destinationAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string textOfBank = "";

            textOfBank += "Tipo da Conta: " + this.AccountType;
            textOfBank += " Nome: "         + this.Name;
            textOfBank += " Saldo: "        + this.Balance;
            textOfBank += " Crédito: "      + this.Credit;

            return textOfBank;
        }
    }
}