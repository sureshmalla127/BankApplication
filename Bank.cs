using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class Account
    {
       // public delegate void EventHandler(double amount);
        public event EventHandler UnderBalance;
        //public delegate void EventHandler2();
        public event EventHandler ZeroBalance;
        public int AccountNumber {get; set;}
        public string CustomerName{get; set;}
        public double Balance{get; set;}
        public Account(int accountNumber, string customerName,int balance)
        {
            this.AccountNumber = accountNumber;
            this.CustomerName = customerName;
            this.Balance = balance;

        }
         public void Deposit(double amount)
        {
            Balance+=amount;
            Console.WriteLine($"Deposited {amount} successfully \nTotal balence is :{Balance}");

        }
        public void Withdraw(double amount)
        {
            if(Balance>=amount)
            {
                Balance-=amount;
                Console.WriteLine($"Withdrawn {amount} successfully \nRemaining balence is :{Balance}");

            if(Balance<100&&Balance!=0)
            {
                UnderBalance?.Invoke(this,EventArgs.Empty);
                //UnderBalance?.Invoke(Balance);
            }
            if(Balance==0)
            {
                ZeroBalance?.Invoke(this, EventArgs.Empty);
                //UnderBalance?.Invoke();
            }
            }
            else 
            {
                Console.WriteLine("Insufficient Balance");
                Console.WriteLine("Current balence : "+Balance);
            }
            
        }

        
        
        

        
    }
}