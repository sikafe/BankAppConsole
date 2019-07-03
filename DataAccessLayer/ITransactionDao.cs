using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface ITransactionDao
    {
        void Add(ITransaction transaction);
        void Delete(int id);
        void Update(ITransaction transaction);
        ITransaction Get(int id);
        List<ITransaction> GetAll(string type);

    }
}
