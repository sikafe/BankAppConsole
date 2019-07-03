using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{ 
    public class BankTransaction : ITransaction
    {
        public double Amount {set; get;}
        public string Type { set; get ; }
        public DateTime TimeOfTransaction { set; get; }
        public int TransactionId { get ; set ; }
        public int TransferAccountId { get ; set ; }

        public BankTransaction(double amount, string type, DateTime timeOfTransaction, int transactionId)
        {
            Amount = amount;
            Type = type;
            TimeOfTransaction = timeOfTransaction;
            TransactionId = transactionId;
        }

        public BankTransaction(double amount, DateTime timeOfTransaction, int transactionId) : this(amount, timeOfTransaction)
        {
            TransactionId = transactionId;
        }

        public BankTransaction(double amount, DateTime timeOfTransaction)
        {
            Amount = amount;
            TimeOfTransaction = timeOfTransaction;
        }
    }
}
