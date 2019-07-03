using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TypeFactory
    {
        public static string DepositTransaction = "Deposit";
        public static string WithdrawalTransaction = "Withdrawal";
        public static string TransferToTransaction = "Transfer To";
        public static string TransferFromTransaction = "Transfer From";
        public static string PaymentTransaction = "Payment";
        public static string CheckingAccount = "Checking Account";
        public static string SavingsAccount = "Savings Account";
        public static string BusinessAccount = "Business Account";
        public static string PersonalLoan = "Personal Loan";
        public static string BusinessLoan = "Business Loan";
        public static string OverdraftLoan = "Overdraft Loan";
        public static string TermDeposit = "Term Deposit";

        private static int newTransactionId = 1011;
        private static int newCustomerId = 10121;
        private static int newAccountId = 1501;
        private static int newLoanId = 2601;
        private static int newTermDepositId = 2601;


        public static int GenerateTransactionID()
        {
            return ++newTransactionId;
        }

        public static int GenerateCustomerID()
        {
            return ++newCustomerId;
        }

        public static int GenerateAccountID()
        {
            return ++newAccountId;
        }

        public static int GenerateLoanID()
        {
            return ++newLoanId;
        }

        public static int GenerateTermDepositID()
        {
            return ++newTermDepositId;
        }
    }
   
}
