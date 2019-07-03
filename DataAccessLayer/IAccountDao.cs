using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IAccountDao
    {
        void Add(IAccount account);
        void Delete(int id);
        void Close(int id);
        void Update(IAccount account);
        IAccount Get(int id);
        List<IAccount> GetAll();
        List<IAccount> GetAll(int customerId);
        List<IAccount> GetAll(String type);
    }
}
