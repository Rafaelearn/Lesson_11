using System;
using System.Collections.Generic;

namespace Lab_12
{
    public enum TypeTransaction
    {
        Withdraw = 1, 
        PutMoney,  
        PutMoneyFromAccount
    }
    public class BankTransaction
    {
        public readonly DateTime dateTime;
        public readonly decimal balance;
        public readonly TypeTransaction type;
        private List<BankTransaction> bankTransactions = new List<BankTransaction>();

        public BankTransaction this[int index]
        {
            get { return bankTransactions[index]; }
            set { bankTransactions[index] = value; }
        }

        public BankTransaction(decimal balance, TypeTransaction type)
        {
            this.type = type;
            this.balance = balance;
            dateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{dateTime.ToShortDateString()} {dateTime.ToLongTimeString()} {type} {balance}";
        }
    }
}
