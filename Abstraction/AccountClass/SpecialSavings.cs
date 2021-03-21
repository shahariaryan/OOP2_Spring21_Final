using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClass
{
    class SpecialSavings : Account
    {
        public SpecialSavings() { }
        public SpecialSavings(string accName, string accNo, double balance) : base(accName, accNo, balance)
        {
        }
        public override void Withdraw(double amount)
        {
            if (Balance - amount >= Balance * 0.2)
            {
                Balance -= amount;
                Console.WriteLine("Your acc is debited by {0} to self", amount);
            }
            else
            {
                Console.WriteLine("You Need minumum 20% of your Opening Balance");
            }
        }
        public override void Transfer(Account a, double amount)
        {
            if (Balance - amount >= 500)
            {
                Balance -= amount;
                a.Balance += amount;
                Console.WriteLine("You account is debited by {0} to acc: {1} ({2})", amount, a.AccName, a.AccNo);
            }
            else
            {
                Console.WriteLine("insufficient balance");
            }
        }

    }
}