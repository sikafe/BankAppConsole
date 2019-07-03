using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ILoan
    {
        int LoanId { set; get; }
        double InterestRate { set; get; }
        double Amount { set; get; }
        double Credit { set; get; }
        double Balance { set; get; }
        string Type { get; set; }
        DateTime DateCreated { set; get; }
        List<ITransaction> LoanTransactions { set; get; }
        void MakePayment(ITransaction payment);
    }
}
