using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransections
{
    class Program
    {
        static void Main(string[] args)
        {
            Account s1 = new Account("Shahariar", "13123", 21236);
            Account s2 = new Account("alir", "14243", 100006);
            Account r1 = new Account("Tabassym", "11123", 5000);
            Account r2 = new Account("Shahariar", "4443", 200);

            Transections t1 = new Transections(s1, r1, 100, "send money");
            Transections t2 = new Transections(s2, r2, 550, "send money");
            Transections t3 = new Transections(s1, r2, 550, "Cash out");

            s1.ShowInfo();
            s1.addTransaction(t1,t2,t3);
            s1.showAllTransection();
            
         
        }
    }
}
