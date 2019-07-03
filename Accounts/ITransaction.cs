using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITransaction
    {   
        int TransactionId { set; get; }
        int TransferAccountId { get; set; }
        double Amount { set; get; }
        string Type { set; get; }

        DateTime TimeOfTransaction {set; get;}
    }
}
