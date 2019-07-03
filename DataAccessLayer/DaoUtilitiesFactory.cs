using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class DaoUtilitiesFactory
    {
        public static List<IBankCustomer> bankCustomers = new List<IBankCustomer>();

        public static ICustomerDao GetCustomerDao()
        {
            return new CustomerDao(bankCustomers);
        }

        public static ITransactionDao GetTransactionDao()
        {
            return new TransactionDao();
        }

        public static IAccountDao GetAccountDao()
        {
            return new AccountDao();
        }

        public static ILoanDao GetLoanDao()
        {
            return new LoanDao();
        }
        public static List<IBankCustomer> CreateListDatabase()
        {
            var temp = new BankCustomer()
            {
                CustomerId = TypeFactory.GenerateCustomerID(),
                FirstName = "William",
                LastName = "Ennin",
                Address = "5 Bayley Ave",
                City = "Yonker",
                State = "New York",
                ZipCode = 10705,
                Gender = "M",
                Email = "williame123@aol.com",
                UserName = "will",
                Password = "123",
                CustomerAccounts = new List<IAccount>(),
                CustomerLoans = new List<ILoan>(),
                CustomerTermDeposits = new List<ITermDeposit>()
        };
            var bAcc = new BankAccount(TypeFactory.GenerateAccountID(), 41256.00, TypeFactory.CheckingAccount, new List<ITransaction>(), new List<ILoan>(), null);
            bAcc.DateCreated = DateTime.Now.AddDays(-340);
            bAcc.AccountTransactions.Add(new BankTransaction(1234.45, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-300), TypeFactory.GenerateTransactionID()));
            bAcc.AccountTransactions.Add(new BankTransaction(5238.44, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-296), TypeFactory.GenerateTransactionID()));
            bAcc.AccountTransactions.Add(new BankTransaction(1856.12, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-284), TypeFactory.GenerateTransactionID()));
            bAcc.AccountTransactions.Add(new BankTransaction(9534.36, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-280), TypeFactory.GenerateTransactionID()));
            bAcc.AccountTransactions.Add(new BankTransaction(1758.81, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-176), TypeFactory.GenerateTransactionID()));
            bAcc.AccountTransactions.Add(new BankTransaction(1784.74, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-144), TypeFactory.GenerateTransactionID()));
            temp.CustomerAccounts.Add(bAcc);
            bankCustomers.Add(temp);

            var bAcc1 = new BankAccount(TypeFactory.GenerateAccountID(), 251256.14, TypeFactory.BusinessAccount, new List<ITransaction>(), new List<ILoan>(), null);
            bAcc1.OverDraftInterestRate = .05;
            bAcc1.DateCreated = DateTime.Now.AddDays(-1336);
            bAcc1.AccountTransactions.Add(new BankTransaction(1894.45, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-268), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(4538.44, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-255), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1894.45, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-238), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1898.12, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-192), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1234.45, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-184), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(5238.44, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-161), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1856.12, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-151), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(9534.36, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-141), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1758.81, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-132), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1784.74, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-128), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(9534.36, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-122), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(78956.81, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-87), TypeFactory.GenerateTransactionID()));
            bAcc1.AccountTransactions.Add(new BankTransaction(1784.74, TypeFactory.DepositTransaction, DateTime.Now.AddDays(-22), TypeFactory.GenerateTransactionID()));
            temp.CustomerAccounts.Add(bAcc1);
            bankCustomers.Add(temp);

            var loan = new BankLoan() {
                InterestRate = .1,
                Amount = 15000,
                LoanId = TypeFactory.GenerateLoanID(),
                Type = TypeFactory.PersonalLoan,
                Balance = 15000,
                LoanTransactions = new List<ITransaction>(),
                DateCreated = DateTime.Now.AddDays(-340)
            };

            loan.MakePayment(new BankTransaction(1894.45, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-268), TypeFactory.GenerateTransactionID()));
            loan.MakePayment(new BankTransaction(4538.44, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-255), TypeFactory.GenerateTransactionID()));
            loan.MakePayment(new BankTransaction(1894.45, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-238), TypeFactory.GenerateTransactionID()));
            loan.MakePayment(new BankTransaction(1898.12, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-192), TypeFactory.GenerateTransactionID()));

            var loan1 = new BankLoan()
            {
                InterestRate = .07,
                Amount = 24000,
                LoanId = TypeFactory.GenerateLoanID(),
                Type = TypeFactory.BusinessLoan,
                Balance = 24000,
                LoanTransactions = new List<ITransaction>(),
                DateCreated = DateTime.Now.AddDays(-360)
            };

            loan1.MakePayment(new BankTransaction(2894.54, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-278), TypeFactory.GenerateTransactionID()));
            loan1.MakePayment(new BankTransaction(538.14, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-245), TypeFactory.GenerateTransactionID()));
            loan1.MakePayment(new BankTransaction(1004.88, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-228), TypeFactory.GenerateTransactionID()));
            loan1.MakePayment(new BankTransaction(2298.42, TypeFactory.PaymentTransaction, DateTime.Now.AddDays(-12), TypeFactory.GenerateTransactionID()));

            var termDeposit = new TermDeposit()
            {
                AccountNumber = TypeFactory.GenerateTermDepositID(),
                Amount = 85000,
                Balance = 85000,
                Type = TypeFactory.TermDeposit,
                AccountTransactions = new List<ITransaction>(),
                DateCreated = DateTime.Now.AddDays(-300),
                DateOfMaturity = DateTime.Now.AddDays(+458),
                InterestRate = .08,
                PenaltyInterestRate = .12,
                TotalPenalty = 0
            };

            var termDeposit1 = new TermDeposit()
            {
                AccountNumber = TypeFactory.GenerateTermDepositID(),
                Amount = 85000,
                Balance = 85000,
                Type = TypeFactory.TermDeposit,
                AccountTransactions = new List<ITransaction>(),
                DateCreated = DateTime.Now.AddDays(-260),
                DateOfMaturity = DateTime.Now.AddDays(+418),
                InterestRate = .09,
                PenaltyInterestRate = .14,
                TotalPenalty = 0
            };

            termDeposit.Withdraw(new BankTransaction(1194.45, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-268), TypeFactory.GenerateTransactionID()));
            termDeposit.Withdraw(new BankTransaction(3438.44, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-255), TypeFactory.GenerateTransactionID()));
            termDeposit.Withdraw(new BankTransaction(1571.45, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-238), TypeFactory.GenerateTransactionID()));
            termDeposit.Withdraw(new BankTransaction(8448.12, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-192), TypeFactory.GenerateTransactionID()));

            termDeposit1.Withdraw(new BankTransaction(5248.11, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-268), TypeFactory.GenerateTransactionID()));
            termDeposit1.Withdraw(new BankTransaction(4826.78, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-255), TypeFactory.GenerateTransactionID()));
            termDeposit1.Withdraw(new BankTransaction(1691.45, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-238), TypeFactory.GenerateTransactionID()));
            termDeposit1.Withdraw(new BankTransaction(9248.25, TypeFactory.WithdrawalTransaction, DateTime.Now.AddDays(-192), TypeFactory.GenerateTransactionID()));

            temp.CustomerTermDeposits.Add(termDeposit);
            temp.CustomerTermDeposits.Add(termDeposit1);
            temp.CustomerLoans.Add(loan);
            temp.CustomerLoans.Add(loan1);
            return bankCustomers;
        }
    }
        
}
