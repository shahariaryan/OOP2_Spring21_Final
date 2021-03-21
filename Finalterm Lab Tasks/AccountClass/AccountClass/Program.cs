using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClass
{
    class Program
    {

        static void Main(string[] args)
        {
            Account a1 = new SpecialSavings("Shah ", "1111", 10000);
            Account a2 = new SpecialSavings("Raj", "1112", 2000);
            a1.Withdraw(5000);
            a1.ShowInfo();
            a2.Withdraw(700);
            a2.ShowInfo();

            OverDraft o1 = new OverDraft("BB ", "1113", 1000);
            OverDraft o2 = new OverDraft("DAS", "1114", 1500);
            o2.Withdraw(3000);
            o2.ShowInfo();
            o1.Withdraw(4500);
            o1.ShowInfo();

        }
    }
}