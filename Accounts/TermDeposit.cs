using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TermDeposit : ITermDeposit
    {
        public int AccountNumber { get ; set ; }
        public double Amount { get ; set ; }
        public double Balance { get; set; }
        public string Type { get; set; }
        public List<ITransaction> AccountTransactions { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfMaturity { get; set; }
        public double InterestRate { get; set; }
        public double PenaltyInterestRate { get; set; }
        public double TotalPenalty { get ; set ; }

        public TermDeposit()
        {
        }

        public TermDeposit(int accountNumber, double amount, double balance, string type, List<ITransaction> accountTransactions, DateTime dateCreated, DateTime dateOfMaturity, double interestRate, double penaltyInterestRate, double totalPenalty)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Balance = balance;
            Type = type;
            AccountTransactions = accountTransactions;
            DateCreated = dateCreated;
            DateOfMaturity = dateOfMaturity;
            InterestRate = interestRate;
            PenaltyInterestRate = penaltyInterestRate;
            TotalPenalty = totalPenalty;
        }

        public bool Withdraw(ITransaction transaction)
        {
            if ((Balance - transaction.Amount) < 0 )
            {
                return false;
            }
            else if ((Balance - transaction.Amount) > 0 && (DateTime.Now < DateOfMaturity))
            {

                if (((transaction.Amount * PenaltyInterestRate)+transaction.Amount)>Balance)
                {
                    TotalPenalty = transaction.Amount * PenaltyInterestRate;
                    transaction.Amount = Balance - transaction.Amount * PenaltyInterestRate;
                    Balance = 0;
                    AccountTransactions.Add(transaction);
                }
                else
                {
                    Balance -= (transaction.Amount * PenaltyInterestRate) + transaction.Amount;
                    TotalPenalty += transaction.Amount * PenaltyInterestRate;
                    AccountTransactions.Add(transaction);
                }
            }
            else
            {
                Balance -= transaction.Amount;
                AccountTransactions.Add(transaction);
            }
            return true;
        }
    }
}
