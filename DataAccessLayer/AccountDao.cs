using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    class AccountDao : IAccountDao
    {
        private readonly List<IAccount> bankAccounts;

        public AccountDao()
        {
            bankAccounts = new List<IAccount>();
        }

        public void Add(IAccount account)
        {
            bankAccounts.Add(account);
        }

        public void Close(int id)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public IAccount Get(int id)
        {
            foreach (IAccount a in bankAccounts)
            {
                if (id == a.AccountNumber)
                {
                    return a;
                }
            }
            return null;
        }

        public List<IAccount> GetAll()
        {
            return bankAccounts;
        }

        public List<IAccount> GetAll(string type)
        {
            List<IAccount> acc = new List<IAccount>();
            foreach (IAccount a in bankAccounts)
            {
                if (type == a.Type)
                {
                    acc.Add(a);
                }
            }
            return acc;
        }

        public List<IAccount> GetAll(int customerId)
        {
            List<IAccount> customerAccounts = DaoUtilitiesFactory.GetCustomerDao().Get(customerId).CustomerAccounts;
            
            return customerAccounts;
        }

        public void Update(IAccount account)
        {
           
        }
    }
}
