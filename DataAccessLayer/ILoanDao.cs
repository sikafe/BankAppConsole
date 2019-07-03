using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface ILoanDao
    {
        void Add(ILoan loan);
        void Delete(int id);
        void Update(ILoan loan);
        ILoan Get(int id);
        List<ILoan> GetAll();
    }
}
