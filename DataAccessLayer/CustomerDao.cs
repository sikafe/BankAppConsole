using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class CustomerDao : ICustomerDao
    {
        List<IBankCustomer> bankCustomers;

        public CustomerDao(List<IBankCustomer> bankCustomers)
        {
            this.bankCustomers = bankCustomers;
        }

        public void Add(IBankCustomer bankCustomer)
        {
            bankCustomers.Add(bankCustomer);
        }
        
        public void Delete(int id)
        {
            foreach (IBankCustomer bc in bankCustomers)
            {
                if(id == bc.CustomerId)
                {
                    bankCustomers.Remove(bc);
                }
            }
        }

        public IBankCustomer Get(int id)
        {
            foreach (IBankCustomer bc in bankCustomers)
            {
                if (id == bc.CustomerId)
                {
                    return bc;
                }
            }
            return null;
        }

        public IBankCustomer Get(string userName, string password)
        {

            foreach(IBankCustomer bc in bankCustomers)
            {
                if (userName == bc.UserName && password == bc.Password)
                {
                    return bc;
                }
            }
            return null;
        }

        public List<IBankCustomer> GetAll()
        {
            return bankCustomers;
        }

        public void Update(IBankCustomer bankCustomer)
        {
           
        }
    }
}
