using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankCustomer : IBankCustomer
    {
        public List<IAccount> CustomerAccounts { get ; set ; }
        public List<ILoan> CustomerLoans { get ; set ; }
        public string FirstName { get ; set; }
        public string LastName { get; set ; }
        public string Address { get ; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string MobilePhone { get ; set; }
        public int CustomerId { get; set; }
        public string Gender { get; set; }
        public string Email { get ; set; }
        public string UserName { get ; set; }
        public string Password { get ; set ; }
        public List<ITermDeposit> CustomerTermDeposits { get; set; }

        public BankCustomer()
        {
            CustomerAccounts = new List<IAccount>();
            CustomerLoans = new List<ILoan>();
            CustomerTermDeposits = new List<ITermDeposit>();
        }

        public BankCustomer(List<IAccount> customerAccounts, string firstName, string lastName, string address, string city, string state, int zipCode, string mobilePhone, int customerId, string gender, string email, string userName, string password)
        {
            CustomerAccounts = customerAccounts;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            MobilePhone = mobilePhone;
            CustomerId = customerId;
            Gender = gender;
            Email = email;
            UserName = userName;
            Password = password;
            CustomerLoans = new List<ILoan>();
        }

        public BankCustomer(string firstName, string lastName, string address, string city, string state, int zipCode, string mobilePhone, string gender, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            MobilePhone = mobilePhone;
            Gender = gender;
            Email = email;
            UserName = userName;
            Password = password;
            CustomerLoans = new List<ILoan>();
            CustomerAccounts = new List<IAccount>();
            CustomerTermDeposits = new List<ITermDeposit>();
        }
    }
}
