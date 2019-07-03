using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankAccount : IAccount
    {
        public int AccountNumber { get; set; }
        public double Balance { get ; set ; }
        public string Type { get ; set ; }
        public List<ITransaction> AccountTransactions { get ; set ; }
        public List<ILoan> AccountLoans { get; set; }
        public ILoan OverDraftLoan { get ; set ; }
        public DateTime DateCreated { get ; set ; }
        public double InterestRate { get ; set; }
        public double OverDraftInterestRate { get; set ; }

        public BankAccount(int accountNumber, double balance, string type, List<ITransaction> accountTransactions, List<ILoan> accountLoans, ILoan overDraftLoan)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Type = type;
            AccountTransactions = accountTransactions;
            AccountLoans = accountLoans;
            OverDraftLoan = overDraftLoan;
            InterestRate = .02;
            OverDraftInterestRate = .05;
        }

        public BankAccount(int accountNumber, string type, DateTime dateCreated, double interestRate)
        {
            AccountNumber = accountNumber;
            Type = type;
            DateCreated = dateCreated;
            InterestRate = interestRate;
            AccountLoans = new List<ILoan>();
            AccountTransactions = new List<ITransaction>();
        }

        public BankAccount(int accountNumber, string type, DateTime dateCreated, double interestRate, double overDraftInterestRate) : this(accountNumber, type, dateCreated, interestRate)
        {
            OverDraftInterestRate = overDraftInterestRate;
        }

        public bool Deposit(ITransaction transaction)
        {
            if (OverDraftLoan!=null && OverDraftLoan.Amount>0)
            {
                if(OverDraftLoan.Amount > transaction.Amount){
                    OverDraftLoan.Amount -= transaction.Amount;
                    AccountTransactions.Add(transaction);
                    return true;
                }
                else
                {
                    Balance += transaction.Amount - OverDraftLoan.Amount;
                    OverDraftLoan.Amount = 0;
                    AccountTransactions.Add(transaction);
                    return true;
                }

            }
            Balance += transaction.Amount;
            AccountTransactions.Add(transaction);
            return true;
        }

        public bool Transfer(ITransaction transaction, IAccount destination)
        {
            transaction.Type = TypeFactory.TransferToTransaction + " Account Number " + destination.AccountNumber;
            bool status = Withdraw(transaction);
            if (status == true)
            {
                var transactionCopy = Copy(transaction);
                transactionCopy.Type = TypeFactory.TransferFromTransaction+" Account Number "+this.AccountNumber;
                transactionCopy.TransferAccountId = this.AccountNumber;
                destination.Deposit(transactionCopy);
                return true;
            }
            return false;
        }

        public bool Withdraw(ITransaction transaction)
        {
            if ((Balance - transaction.Amount) < 0 && Type == TypeFactory.CheckingAccount)
            {
                return false;
            }
            else if ((Balance - transaction.Amount) < 0 && Type == TypeFactory.BusinessAccount)
            {
                if(OverDraftLoan == null)
                {
                    OverDraftLoan = new BankLoan(.1, transaction.Amount - Balance, TypeFactory.GenerateLoanID(), TypeFactory.OverdraftLoan);
                    AccountLoans.Add(OverDraftLoan);
                    AccountTransactions.Add(transaction);
                    Balance = 0;
                }
                else
                {
                    OverDraftLoan.Amount += transaction.Amount;
                    AccountLoans.Add(OverDraftLoan);

                }
            }
            else
            {
                Balance -= transaction.Amount;
                AccountTransactions.Add(transaction);
            }
            return true;
        }

        private ITransaction Copy(ITransaction transaction)
        {
            var transactionCopy = new BankTransaction(transaction.Amount, transaction.TimeOfTransaction);
            return transactionCopy;
        }
    }
}
