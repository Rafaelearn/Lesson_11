using System;
using System.Collections.Generic;

namespace Lab_12
{
    public class Account
    {
        Random random = new Random();
        static ulong lastNumber = 4364_2868_4768_0000;
        private List<BankTransaction> transactions = new List<BankTransaction>();
        public BankTransaction this[int index]
        {
            get {
                if (index < 0 || index >= transactions.Count)
                {
                    throw new ArgumentOutOfRangeException($"Not exist {index} - element");
                }
                return transactions[index]; 
            }
            set {
                if (index < 0 || index >= transactions.Count)
                {
                    throw new ArgumentOutOfRangeException($"Not exist {index} - element");
                }
                transactions[index] = value; 
            }
        }
        public ulong Number { get;}
        public TypeAccount Type { get;}
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Баланс не может быть отрицательным. Баланс: 0$");
                }
                else
                {
                    balance = value;
                }
            }
        }

        internal Account(TypeAccount type, decimal balance)
        {
            Type = type;
            Balance = balance;
            Number += lastNumber + (ulong)random.Next(1, 10);
            lastNumber = Number;
        }
        internal Account(TypeAccount type) : this(type, 0)
        {
        }
        internal Account(decimal balance) : this(TypeAccount.accountCurrent, balance)
        {
        }
        internal Account() : this(TypeAccount.accountCurrent, 0)
        {
        }

        public bool Withdraw(decimal money)
        {
            if (money > Balance)
            {
                return false;
            }
            else
            {
                Balance -= money;
                transactions.Add(new BankTransaction(money, TypeTransaction.Withdraw));
                return true;
            }
        }
        public void PutMoney(decimal money)
        {
            if (money <= 0)
            {
                Console.WriteLine("Операцию произвести невозможно! Сумма должна быть больше 0");
                transactions.Add(new BankTransaction(money, TypeTransaction.PutMoney));
                return;
            }
            Balance += money;
        }
        public bool PutMoneyFromAccount(Account account, decimal money)
        {
            if (!account.Withdraw(money))
            {
                return false;
            }
            else
            {
                Balance += money;
                transactions.Add(new BankTransaction(money, TypeTransaction.PutMoneyFromAccount));
                return true;
            }
        }
        public void Display()
        {
            Console.WriteLine("Информация о счете:\n" + $"{Type}\t{Number}\t{balance}$");
        }
        public override string ToString()
        {
            return $"{Type}\t{Number}\t{balance}$";
        }
    }
}
