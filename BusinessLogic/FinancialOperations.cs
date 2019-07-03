using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;

namespace BusinessLogic
{
    public static class FinancialOperations
    {

        public static void Deposit(int accountId, double amount)
        {
            IAccount account = DaoUtilitiesFactory.GetAccountDao().Get(accountId);
            if (account != null)
            {
                account.Deposit(new BankTransaction(amount,DateTime.Now));
            }
        }

        public static void Deposit(IAccount account, double amount)
        {
            ITransaction transaction = new BankTransaction(amount, TypeFactory.DepositTransaction, DateTime.Now, TypeFactory.GenerateTransactionID());
            account.Deposit(transaction);
        }

        public static bool Withdraw(IAccount account, double amount)
        {
            bool status;
            ITransaction transaction = new BankTransaction(amount, TypeFactory.WithdrawalTransaction, DateTime.Now, TypeFactory.GenerateTransactionID());
            status = account.Withdraw(transaction);
            return status;
        }

        public static bool Withdraw(ITermDeposit termDeposit, double amount)
        {
            bool status;
            ITransaction transaction = new BankTransaction(amount, TypeFactory.WithdrawalTransaction, DateTime.Now, TypeFactory.GenerateTransactionID());
            status = termDeposit.Withdraw(transaction);
            return status;
        }
        public static bool Transfer(IAccount originAccount, IAccount destinationAccount, double amount)
        {

            ITransaction transaction = new BankTransaction(amount, TypeFactory.TransferToTransaction, DateTime.Now, TypeFactory.GenerateTransactionID());
            bool status = originAccount.Transfer(transaction, destinationAccount);
            return status;
        }

        public static void LoanInstallment(ILoan loan, double amount)
        {
            ITransaction transaction = new BankTransaction(amount, TypeFactory.PaymentTransaction, DateTime.Now, TypeFactory.GenerateLoanID());
            loan.MakePayment(transaction);
        }
    }
}
