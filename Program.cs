namespace BankingApplication
{
    public delegate void Credit(double amount);
    public delegate void Debit(double amount);
    public class Program{
        public static void Main(string[] args)
        {
            
            Account a=new Account(12345,"suresh",1000);
            Console.WriteLine("current balance = "+ a.Balance);
            a.UnderBalance+=(object sender,EventArgs e)=>Console.WriteLine("Balance is below 100{balance}");
            a.ZeroBalance+=(object sender,EventArgs e)=>Console.WriteLine("Balance has reached zero") ;
           // a.UnderBalance += (balance) => Console.WriteLine($"Balance is below 100.\nCurrent balance: {balance}");
           // a.ZeroBalance += () => Console.WriteLine("Balance reached to zero!");
            Credit c=a.Deposit;
            Debit d=new Debit(a.Withdraw);
            c(1000);
            d(2000);
            c(1000);
           // a.Withdraw(2000);
            d(2000);
            d(1000);
        }
        
    }
}