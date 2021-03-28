using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Savings("shahariar", "22222", 200000);
            Account a2 = new Current("Fozlur", "11111", 100000);
            Account a3 = new Overdraft("Fozlur", "11111", 5000,5000);

            a1.ShowInfo();
            a1.deposit(1000);
            a3.widhdraw(11000);


        }
    }
}
