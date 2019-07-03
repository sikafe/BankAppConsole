using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface ICustomerDao
    {
        void Add(IBankCustomer bankCustomer);
        void Delete(int id);
        void Update(IBankCustomer bankCustomer);
        IBankCustomer Get(int id);
        IBankCustomer Get(string userName, string password);
        List<IBankCustomer> GetAll();
    }
}
