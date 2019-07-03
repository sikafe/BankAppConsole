using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITermDeposit
    {
        int AccountNumber { set; get; }
        double Amount { set; get; }
        double Balance { set; get; }
        double TotalPenalty { set; get; }
        double InterestRate { set; get; }
        double PenaltyInterestRate { set; get; }
        string Type { set; get; }
        DateTime DateCreated { set; get; } 
        DateTime DateOfMaturity { set; get; }
        List<ITransaction> AccountTransactions { get; set; }

        bool Withdraw(ITransaction transaction);

    }
}
