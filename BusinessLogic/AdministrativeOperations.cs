using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;

namespace BusinessLogic
{
    public static class AdministrativeOperations
    {
        private static ICustomerDao customerDao = DaoUtilitiesFactory.GetCustomerDao();

        //Adds a new BankCustomer object to the list of IBankCustomers
        public static void Register(IBankCustomer bankCustomer)
        {
            customerDao.Add(bankCustomer);
        }

        //adds a new BankAccount object to the bankCustomer list of IAccounts
        public static IAccount OpenAccount(IBankCustomer bankCustomer, string type)
        {
            if (type.Equals("checking account", StringComparison.InvariantCultureIgnoreCase))
            {
                IAccount account = new BankAccount(TypeFactory.GenerateAccountID(), TypeFactory.CheckingAccount, DateTime.Now, .02);
                bankCustomer.CustomerAccounts.Add(account);
                return account;
            }
            if (type.Equals("business account", StringComparison.InvariantCultureIgnoreCase))
            {
                IAccount account = new BankAccount(TypeFactory.GenerateAccountID(), TypeFactory.BusinessAccount, DateTime.Now, .02);
                account.OverDraftInterestRate = .07;
                bankCustomer.CustomerAccounts.Add(account);
                return account;
            }
            return null;
        }
        //adds a new BankLoan object to the bankCustomer list of ILoans
        public static ILoan RequestLoan(IBankCustomer bankCustomer, double amount, string type)
        {
            if (type.Equals("business loan", StringComparison.InvariantCultureIgnoreCase))
            {
                ILoan loan = new BankLoan()
                {
                    Type = TypeFactory.BusinessLoan,
                    Amount = amount,
                    Balance=amount,
                    DateCreated = DateTime.Now,
                    InterestRate = .056,
                    LoanTransactions = new List<ITransaction>(),
                    LoanId = TypeFactory.GenerateLoanID()
                };
                bankCustomer.CustomerLoans.Add(loan);
                return loan;
            }
            if (type.Equals("personal loan", StringComparison.InvariantCultureIgnoreCase))
            {

                ILoan loan = new BankLoan()
                {
                    Type = TypeFactory.PersonalLoan,
                    Amount = amount,
                    Balance = amount,
                    DateCreated = DateTime.Now,
                    InterestRate = .075,
                    LoanTransactions = new List<ITransaction>(),
                    LoanId = TypeFactory.GenerateLoanID()
                };
                bankCustomer.CustomerLoans.Add(loan);
                return loan;
            }
            return null;
        }

        //adds a new TermDeposit object to the bankCustomer list of ITermDeposits
        public static ITermDeposit OpenTermDeposit(IBankCustomer bankCustomer, double amount)
        {
            ITermDeposit termDeposit = new TermDeposit()
            {
                Type = TypeFactory.TermDeposit,
                Amount = amount,
                Balance = amount,
                TotalPenalty = 0,
                PenaltyInterestRate = .125,
                DateCreated = DateTime.Now,
                DateOfMaturity = DateTime.Now.AddDays(1500),
                InterestRate = .082,
                AccountTransactions = new List<ITransaction>(),
                AccountNumber = TypeFactory.GenerateTermDepositID()
            };
            bankCustomer.CustomerTermDeposits.Add(termDeposit);
            return termDeposit;
        }
        //Removes the given IAccount object from the bankCustomer list of IAccounts
        public static int CloseAccount(IBankCustomer bankCustomer, IAccount account)
        {
            bankCustomer.CustomerAccounts.Remove(account);
            return account.AccountNumber;
        }

        //Validates Sign in info
        public static IBankCustomer SignIn(string userName, string password)
        {
            return customerDao.Get(userName,password);
        }

    }
}
