using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountClass

{
    class OverDraft : Account

    {
        int limit = 5000;
        public OverDraft(string name, string accNo, double balance) : base(name, accNo, balance)
        {
        }
        override public void Withdraw(double amount)
        {
            if (limit > Balance)
            {

                Console.WriteLine("cannot be OverDrafted");
            }
            else
            {
                Balance = amount;
                limit++;
                Console.WriteLine("5000 OverDrafted");

            }

        }
    }
}