using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IAccount
    {
        int AccountNumber { set; get; }
        double Balance { set; get; }
        double InterestRate { set; get; }
        double OverDraftInterestRate { set; get; }
        string Type { set; get; }
        ILoan OverDraftLoan { set; get; }
        DateTime DateCreated { set; get; }
        List<ILoan> AccountLoans { set; get; }
        List<ITransaction> AccountTransactions { get; set; }

        bool Deposit(ITransaction transaction);
        bool Withdraw(ITransaction transaction);
        bool Transfer(ITransaction transaction, IAccount destination);
    }
}
