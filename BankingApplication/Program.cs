using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLogic;
using DataAccessLayer;

namespace BankApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DaoUtilitiesFactory.CreateListDatabase();
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine("║                                         ║");
                    Console.WriteLine("║ Enter 1) Register  2) Sign in  3) Exit  ║");
                    Console.WriteLine("║                                         ║");
                    Console.WriteLine("===========================================\n\n");
                    Console.Write("Enter Option: ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        Register();
                    }
                    else if (option == 2)
                    {
                        SingIn();
                    }
                    else if (option == 3)
                    {
                       Environment.Exit(0);
                    }
                    else
                    {
                        ErrorHandler();
                    }


                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static void SingIn()
        {
            string userName, password;
            IBankCustomer customer;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================================================================");
                Console.WriteLine("║                                                                                    ║");
                Console.WriteLine("║                                 ENTER LOGIN INFORMATION                            ║");
                Console.WriteLine("║                                                                                    ║");
                Console.WriteLine("======================================================================================\n\n");
                Console.Write(" Enter User Name: ");
                userName = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Write(" Enter Password: ");
                password = Console.ReadLine();

                customer = AdministrativeOperations.SignIn(userName, password);
                if (customer != null)
                {
                    CustomerMenu(customer);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nTHE USER NAME AND/OR PASSWORD YOU ENTERED IS INVALID!\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.WriteLine("Press ENTER to return to the Main Menu...");
                    Console.ReadKey();
                    break;
                }
            }

        }

        private static void Register()
        {
            int zip;
            IBankCustomer customer;

            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine("║                                                                                ║");
            Console.WriteLine("║                        FILL OUT REGISTRATION INFORMATION                       ║");
            Console.WriteLine("║                                                                                ║");
            Console.WriteLine("==================================================================================\n\n");
            Console.Write(" Enter First Name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter Last Name: ");
            string lName = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter User Name: ");
            string uName = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter Email Address: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter Home Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter City: ");
            string city = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter State: ");
            string state = Console.ReadLine();
            Console.WriteLine("\n");
            while(true){
                try
                {
                    Console.Write(" Enter ZIPCODE(must be a number): ");
                    string zipcode = Console.ReadLine();
                    zip = Convert.ToInt32(zipcode);
                    break;
                }
                catch(Exception e)
                {
                    CatchHandler(e);
                }
            }
            Console.WriteLine("\n");
            Console.Write(" Enter Gender(M/F): ");
            string gender = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write(" Enter Mobile Phone Number((xxx) xxx xxxx): ");
            string phone = Console.ReadLine();

            customer = new BankCustomer() {
                FirstName = fName,
                LastName = lName,
                UserName = uName,
                Password = password,
                Email = email,
                Address = address,
                City = city,
                State = state,
                ZipCode = zip,
                Gender  =gender,
                MobilePhone = phone
            };

            AdministrativeOperations.Register(customer);
            Console.WriteLine("\nThanks for registering with us! Press Enter to continue\n");
            Console.ReadKey();
            MainMenu();
        }

        private static void CustomerMenu(IBankCustomer customer)
        {   
            while (true)
            {   
                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + customer.FirstName + " " + customer.LastName + "\n");
                    Console.WriteLine("==========================================================================================================");
                    Console.WriteLine("║                                                                                                        ║");
                    Console.WriteLine("║                                    PICK AN OPTION FROM THE MAIN MENU                                   ║");
                    Console.WriteLine("║                                                                                                        ║");
                    Console.WriteLine("==========================================================================================================\n");
                    Console.WriteLine("1) Open New Account  2) Existing Bank Accounts  3) Term Deposit  4) Loans 5) Close Account 6) Back 7) Logout\n\n");
                    Console.Write("Enter:");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        OpenNewAccount(customer);
                    }
                    else if (option == 2)
                    {
                        AccountMenu(customer);
                    }
                    else if (option == 3)
                    {
                        TermDepositMenu(customer);
                    }
                    else if (option == 4)
                    {
                       LoanMenu(customer);
                    }
                    else if (option == 5)
                    {
                       CLoseAccount(customer);
                    }
                    else if (option == 6)
                    {
                       break;
                    }
                    else if (option == 7)
                    {
                       Logout();
                    }
                    else
                    {
                       ErrorHandler();
                    }

                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }
        private static void AccountMenu(IBankCustomer bankCustomer)
        {
            IAccount account = AccountSelectionMenu(bankCustomer);
            if (account == null)
            {
                Console.WriteLine("\nYOU HAVE NO OPEN ACCOUNTS AT THIS TIME.\n\nPress ENTER to continue...");
                Console.ReadKey();
                return;
            }

            int option=0;
            
            while (option!=5)
            {
                Console.Clear();
                Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
                Console.WriteLine("===================================================================================");
                Console.WriteLine("║                                                                                 ║");
                Console.WriteLine("║                    PICK AN OPTION FROM THE BANK ACCOUNT MENU                    ║");
                Console.WriteLine("║                                                                                 ║");
                Console.WriteLine("===================================================================================\n");
                Console.WriteLine("1) Deposit   2) Withdrawal  3) Transfer  4) Transactions 5 ) Back 6 ) Logout\n\n");
                Console.WriteLine(account.Type + "\nAccount number: " + account.AccountNumber+ "\n" + "Interest Rate: "+account.InterestRate*100+"% APR\n" + "Balance: $ " + String.Format("{0:n}", account.Balance));
                if (account.OverDraftLoan!=null && account.OverDraftLoan.Amount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOverdraft Amount: $ " + String.Format("{0:n}", account.OverDraftLoan.Amount) +"\nInterest Rate on Overdraft is: "+account.OverDraftInterestRate*100+"% APR");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("\n\n");
                try
                { 
                    Console.Write("Enter:");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        Deposit(account);
                    }
                    else if (option == 2)
                    {
                        Withdraw(account);
                    }
                    else if (option == 3)
                    {
                        Transfer(bankCustomer, account);
                    }
                    else if (option == 4)
                    {
                        AccountTransactionList(account);
                    }
                    else if (option == 5)
                    {
                        break;
                    }
                    else if (option == 6)
                    {
                        Logout();
                    }
                    else
                    {
                        ErrorHandler();
                    }

                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static void OpenNewAccount(IBankCustomer bankCustomer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
                    Console.WriteLine("==========================================================================================");
                    Console.WriteLine("║                                                                                        ║");
                    Console.WriteLine("║                       PICK AN OPTION FROM THE NEW ACOUNTS MENU                         ║");
                    Console.WriteLine("║                                                                                        ║");
                    Console.WriteLine("==========================================================================================\n");
                    Console.WriteLine("1) Open Checking Account  2) Open Business Account 3) Request Loan  4) Open Term Deposit 5) back  6) Logout\n\n");
                    Console.Write("Enter:");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        IAccount account = AdministrativeOperations.OpenAccount(bankCustomer,"Checking Account");
                        if (account != null)
                        {
                            Console.WriteLine("CHECKING ACCOUNT WITH ACCOUNT NUMBER " + account.AccountNumber + " WAS SUCCESSFULLY CREATED!\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("CHECKING ACCOUNT CREATION FAILED!!!\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (option == 2)
                    {
                        IAccount account = AdministrativeOperations.OpenAccount(bankCustomer, "Business Account");
                        if (account != null)
                        {
                            Console.WriteLine("BUSINESS ACCOUNT WITH ACCOUNT NUMBER " + account.AccountNumber + " WAS SUCCESSFULLY CREATED!\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("BUSINESS ACCOUNT CREATION FAILED!!!\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (option == 3)
                    {
                        ILoan loan = null;
                        while (true)
                        {
                            try
                            {
                                Console.Write("1) Personal Loan\n2) Business loan");
                                Console.Write("\n\nEnter Choice:");
                                int value = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n\nEnter loan amount (must be greater zero):");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                if (value==1 && amount>0)
                                {
                                    loan = AdministrativeOperations.RequestLoan(bankCustomer, amount, "personal loan");
                                    break;
                                }
                                else if (value == 2 && amount > 0)
                                {
                                    loan = AdministrativeOperations.RequestLoan(bankCustomer, amount, "business loan");
                                    break;
                                }
                                else
                                {
                                    ErrorHandler();   
                                }
                            }
                            catch (Exception e)
                            {
                                CatchHandler(e);
                            }
                        }
                        
                        if (loan != null)
                        {
                            Console.WriteLine("\nLOAN REQUEST FOR $"+loan.Amount+" WAS APPROVED!\nTHE INTEREST RATE ON THE LOAN IS :"+(loan.InterestRate*100)+ "% APR\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("LOAN REQUEST FAILED!!!\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (option == 4)
                    {
                        double amount = 0;
                        try
                        {
                            Console.Write("\n\nEnter Term Deposit amount:");
                            amount = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            CatchHandler(e);
                        }
                        ITermDeposit termDeposit = AdministrativeOperations.OpenTermDeposit(bankCustomer, amount);
                        if (termDeposit != null)
                        {
                            Console.WriteLine("\nTERM DEPOSIT OF $"+String.Format("{0:n}", amount) + " WAS APPROVED!\nTHE YIELD ON THE ACCOUNT IS "+(termDeposit.InterestRate*100)+ "% APR\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("TERM DEPOSIT REQUEST FAILED!!!\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else if (option == 5)
                    {
                        break;
                    }
                    else if (option == 6)
                    {
                        Logout();
                    }
                    else
                    {
                        ErrorHandler();
                    }

                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static void TermDepositMenu(IBankCustomer bankCustomer)
        {
            ITermDeposit termDeposit = TermDepositSelectionMenu(bankCustomer);
            if (termDeposit == null)
            {
                Console.WriteLine("\nYOU HAVE NO TREM DEPOSITS AT THIS TIME.\n\nPress ENTER to continue...");
                Console.ReadKey();
                return;
            }
            int option = 0;

            while (option != 5)
            {
                Console.Clear();
                Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
                Console.WriteLine("==================================================================================================");
                Console.WriteLine("║                                                                                                ║");
                Console.WriteLine("║                            PICK AN OPTION FROM THE TERM DEOPSIT MENU                           ║");
                Console.WriteLine("║                                                                                                ║");
                Console.WriteLine("==================================================================================================\n");
                Console.WriteLine("1) Widthdraw  2) Transactions 3 ) Back 4) Logout\n\n");
                Console.WriteLine(termDeposit.Type + "\nTerm Deposit issued on: " + termDeposit.DateCreated.ToString("F") 
                    + "\nTerm Deposit matures on: " + termDeposit.DateOfMaturity.ToString("F")
                    + "\nAccount number: " + termDeposit.AccountNumber + "\n" + "TermDeposit: $ " + String.Format("{0:n}", termDeposit.Amount) +
                    "\nMaturity Interest Rate: " + termDeposit.InterestRate * 100 + "% APR\n"+ "Penalty Rate is: " 
                    + termDeposit.PenaltyInterestRate * 100 + "% of Withdrawal Amount\n" + "Balance: $ " + String.Format("{0:n}", termDeposit.Balance));
                if (termDeposit.TotalPenalty > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nTotal Penalty Amount: $ " + String.Format("{0:n}", termDeposit.TotalPenalty));
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("\n\n");
                try
                {
                    Console.Write("Enter:");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        TermDepositWithdraw(termDeposit);
                    }
                    else if (option == 2)
                    {
                        TermDepositTransactionList(termDeposit);
                    }
                    else if (option == 3)
                    {
                        break;
                    }
                    else if (option == 4)
                    {
                        Logout();
                    }
                    else
                    {
                        ErrorHandler();
                    }

                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static ITermDeposit TermDepositSelectionMenu(IBankCustomer bankCustomer)
        {
            int option = 0;
            var termDeposits = bankCustomer.CustomerTermDeposits;
            if (termDeposits.Count == 0)
            {
                return null;
            }
            Console.Clear();
            Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("║                                                                                                ║");
            Console.WriteLine("║                                       PICK AN OPTION FROM THE MENU                             ║");
            Console.WriteLine("║                                                                                                ║");
            Console.WriteLine("===================================================================================================\n");

            for (int i = 0; i < termDeposits.Count; i++)
            {
                Console.WriteLine((i + 1) + ")" + " " + termDeposits[i].Type + " with Account Number: " + termDeposits[i].AccountNumber);
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter:");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option > 0 && option <= termDeposits.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        ErrorHandler();
                    }
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
            return termDeposits[option - 1];
        }

            private static void LoanMenu(IBankCustomer bankCustomer)
        {
            ILoan loan = LoanSelectionMenu(bankCustomer);
            if(loan == null)
            {
                Console.WriteLine("\nYOU HAVE NO LOANS AT THIS TIME.\n\nPress ENTER to continue...");
                Console.ReadKey();
                return;
            }
            int option = 0;

            while (option != 5)
            {
                Console.Clear();
                Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
                Console.WriteLine("===========================================");
                Console.WriteLine("║                                         ║");
                Console.WriteLine("║   PICK AN OPTION FROM THE LOAN MENU     ║");
                Console.WriteLine("║                                         ║");
                Console.WriteLine("===========================================\n");
                Console.WriteLine("1) Payment  2) Transactions 3 ) Back 4 ) Logout\n\n");
                Console.WriteLine(loan.Type + "\nLoan issued on: "+loan.DateCreated.ToString("F")+"\nAccount number: " + loan.LoanId + "\n" + "Amount Borrowed: $ "+ String.Format("{0:n}", loan.Amount) +
                    "\nInterest Rate: " + loan.InterestRate * 100 + "% APR\n" + "Balance: $ " + String.Format("{0:n}", loan.Balance));
                if (loan.Credit > 0)
                {
                    Console.WriteLine("Credit: $ "+ String.Format("{0:n}", loan.Credit));
                }
                Console.WriteLine("\n\n");
                try
                {
                    Console.Write("Enter:");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        LoanPayment(loan);
                    }
                    else if (option == 2)
                    {
                        LoanTransactionList(loan);
                    }
                    else if (option == 3)
                    {
                        break;
                    }
                    else if (option == 4)
                    {
                        Logout();
                    }
                    else
                    {
                        ErrorHandler();
                    }

                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static ILoan LoanSelectionMenu(IBankCustomer bankCustomer)
        {
            int option = 0;
            var loans = bankCustomer.CustomerLoans;
            if (loans.Count == 0)
            {
                return null;
            }
            Console.Clear();
            Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
            Console.WriteLine("===========================================");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║   PICK AN OPTION FROM THE MENU          ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("===========================================\n");
           
            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine((i + 1) + ")" + " " + loans[i].Type + " with Account Number: " + loans[i].LoanId);
            }
            while (true)
            {
                    try
                    {
                        Console.Write("Enter:");
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option > 0 && option <= loans.Count + 1)
                        {
                            break;
                        }
                        else
                        {
                            ErrorHandler();
                        }
                    }
                    catch (Exception e)
                    {
                        CatchHandler(e);
                    }
            }
            return loans[option - 1];
            
        }
        private static IAccount AccountSelectionMenu(IBankCustomer bankCustomer)
        {
            int option = 0;
            var accounts = bankCustomer.CustomerAccounts;
            if (accounts.Count == 0)
            {
                return null;
            }
            Console.Clear();
            Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
            Console.WriteLine("===========================================");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║   PICK AN OPTION FROM THE MENU          ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("===========================================\n");
          
            
           for (int i=0; i< accounts.Count; i++)
           {
                Console.WriteLine((i+1)+")"+ " "+accounts[i].Type+" with Account Number: "+accounts[i].AccountNumber);
           }
           while (true)
           {
                try
                {
                    Console.Write("\nEnter:");
                    option = Convert.ToInt32(Console.ReadLine());
                    if(option>0 && option<= accounts.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        ErrorHandler();
                    }
               }
               catch(Exception e)
              {
                CatchHandler(e);
              }
         }
         return accounts[option-1];
           
        }

        private static void TermDepositTransactionList(ITermDeposit termDeposit)
        {
            var transactions = termDeposit.AccountTransactions;
            if (transactions.Count == 0)
            {
                Console.WriteLine("\n\nTHERE HAVE BEEN NO TRANSACTIONS MADE ON THIS ACCOUNT.");
            }
            foreach (ITransaction t in transactions)
            {
                Console.WriteLine();
                Console.WriteLine(t.Type + "\n" + "$ " + String.Format("{0:n}", t.Amount) + "\n" + t.TimeOfTransaction.ToString("F") + "\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private static void LoanTransactionList(ILoan loan)
        {
            var transactions = loan.LoanTransactions;
            if (transactions.Count == 0)
            {
                Console.WriteLine("\n\nTHERE HAVE BEEN NO TRANSACTIONS MADE ON THIS ACCOUNT.");
            }
            foreach (ITransaction t in transactions)
            {
                Console.WriteLine();
                Console.WriteLine(t.Type + "\n" + "$ " + String.Format("{0:n}", t.Amount) + "\n" + t.TimeOfTransaction.ToString("F") + "\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void LoanPayment(ILoan loan)
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nEnter installment amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    FinancialOperations.LoanInstallment(loan, amount);
                    Console.WriteLine("INSTALLMENT WAS SUCCESSFUL!!\n\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }
        private static void AccountTransactionList(IAccount account)
        {
            var transactions = account.AccountTransactions;
            if (transactions.Count ==0)
            {
                Console.WriteLine("\n\nTHERE HAVE BEEN NO TRANSACTIONS MADE ON THIS ACCOUNT.");
            }
            foreach (ITransaction t in transactions)
            {
                Console.WriteLine();
                Console.WriteLine(t.Type+"\n"+"$ "+ String.Format("{0:n}", t.Amount) + "\n"+t.TimeOfTransaction.ToString("F")+"\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void TermDepositWithdraw(ITermDeposit termDeposit)
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nEnter withdrawal amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    bool status = FinancialOperations.Withdraw(termDeposit, amount);
                    if (status == true)
                    {
                        Console.WriteLine("WITHDRAWAL WAS SUCCESSFUL!!\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWITHDRAWAL WAS UNSUCCESSFUL! THE WITHDRAWAL AMOUNT EXCEEDS THE ACCOUNT BALANCE");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }
        private static void Deposit(IAccount account)
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nEnter deposit amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    FinancialOperations.Deposit(account, amount);
                    Console.WriteLine("DEPOSIT WAS SUCCESSFUL!!\n\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }
        private static void Withdraw(IAccount account)
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nEnter withdrawal amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    bool status = FinancialOperations.Withdraw(account, amount);
                    if (status == true)
                    {
                        Console.WriteLine("WITHDRAWAL WAS SUCCESSFUL!!\n\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWITHDRAWAL WAS UNSUCCESSFUL! THE WITHDRAWAL AMOUNT EXCEEDS THE ACCOUNT BALANCE");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static void Transfer(IBankCustomer bankCustomer, IAccount account)
        {
            while (true)
            {
                try
                {
                    bool success = false;
                    bool accountExists = false;
                    Console.Write("\n\nEnter transfer amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\n\nEnter destination account number: ");
                    int destinationAccountNumber = Convert.ToInt32(Console.ReadLine());

                    foreach(IAccount a in bankCustomer.CustomerAccounts)
                    {
                        if (destinationAccountNumber == a.AccountNumber)
                        {
                            success = FinancialOperations.Transfer(account, a,amount);
                            accountExists = true;
                        }
                    }
                    if (accountExists == true)
                    {
                        if (success == true)
                        {
                            Console.WriteLine("TRANSFER WAS SUCCESSFUL!\n\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nTRANSFER WAS UNSUCCESSFUL! THE TRANSFER AMOUNT EXCEEDS THE ACCOUNT BALANCE\n\nPress ENTER to continue...");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTHE ACCOUNT NUMBER YOU ENTERED IS INVALID\n\nPress ENTER to continue...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        continue;
                    }
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
        }

        private static void CLoseAccount(IBankCustomer bankCustomer)
        {
            int option = 0;
            var accounts = bankCustomer.CustomerAccounts;
            if (accounts.Count == 0)
            {
                Console.Write("\nYOU HAVE NO OPEN BANK ACCOUNTS AT THIS TIME!\nPress ENTER to continue...");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            Console.WriteLine("   " + bankCustomer.FirstName + " " + bankCustomer.LastName + "\n");
            Console.WriteLine("===========================================");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║   PICK AN OPTION FROM THE MENU          ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("===========================================\n");


            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine((i + 1) + ")" + " " + accounts[i].Type + " with Account Number: " + accounts[i].AccountNumber);
            }
            while (true)
            {
                try
                {
                    Console.Write("\nWhich Account would you like to close?: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option > 0 && option <= accounts.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        ErrorHandler();
                    }
                }
                catch (Exception e)
                {
                    CatchHandler(e);
                }
            }
            Console.WriteLine("\n");
            Console.Write(accounts[option - 1].Type.ToUpper()+" "+ accounts[option - 1].AccountNumber + " WAS SUCCESSFULLY CLOSED!\nPress ENTER to continue..");
            AdministrativeOperations.CloseAccount(bankCustomer, accounts[option - 1]);
            Console.ReadKey();
        }
        private static void Logout()
        {
            MainMenu();
        }
        private static void CatchHandler(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + e.Message.ToUpper() + "!!!\n");
            Console.WriteLine("YOU MUST ENTER A NUMBER.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void ErrorHandler()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTHE NUMER YOU ENTERED IS INVALID!!!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
