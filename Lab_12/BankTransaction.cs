using System;
using System.Collections.Generic;

namespace Lab_12
{
    public class BankTransaction
    {
        public readonly DateTime dateTime;
        public readonly decimal balance;
        List<BankTransaction> bankTransactions = new List<BankTransaction>();

        public BankTransaction this[int index]
        {
            get { return bankTransactions[index]; }
            set { bankTransactions[index] = value; }
        }

        public BankTransaction(decimal balance)
        {
            this.balance = balance;
            dateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{dateTime.ToShortDateString()} {dateTime.ToLongTimeString()} {balance}";
        }
    }
}
