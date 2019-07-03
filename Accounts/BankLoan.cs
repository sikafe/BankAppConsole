using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankLoan : ILoan
    {
        public double InterestRate { get ; set ; }
        public double Amount { get ; set ; }
        public List<ITransaction> LoanTransactions { get ; set ; }
        public int LoanId { get ; set ; }
        public string Type { get ; set ; }
        public double Balance { get ; set ; }
        public double Credit { get ; set; }
        public DateTime DateCreated { get ; set ; }

        public BankLoan()
        {
            LoanTransactions = new List<ITransaction>();
            DateCreated = DateTime.Now;
            Credit = 0;
        }

        public BankLoan(double interestRate, double amount, int loanId, string type)
        {
            InterestRate = interestRate;
            Amount = amount;
            LoanId = loanId;
            Type = type;
            Balance = amount;
            LoanTransactions = new List<ITransaction>();
            Credit = 0;
        }

        public void MakePayment(ITransaction payment)
        {
            if ((Balance-payment.Amount) > 0)
            {
                Balance -= payment.Amount;
                LoanTransactions.Add(payment);
            }
            else
            {
                Credit += payment.Amount - Balance;
                LoanTransactions.Add(payment);
                Balance = 0;
            }
        }


    }
}
