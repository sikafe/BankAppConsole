using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICustomer
    { 
        int CustomerId { set; get; }
        string FirstName { set; get; }
        string Gender { set; get; }
        string Email { set; get; }
        string LastName { set; get; }
        string Address { set; get; }
        string City { get; set; }
        string State { get; set; }
        int ZipCode { get; set; }
        string MobilePhone {set; get;}
    }
}
