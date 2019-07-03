using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IBankCustomer:ICustomer
    {
        string UserName { set; get; }
        string Password { set; get; }
        List<IAccount> CustomerAccounts { set; get; }
        List<ILoan> CustomerLoans { set; get; }
        List<ITermDeposit> CustomerTermDeposits { set; get; }
    }
}
