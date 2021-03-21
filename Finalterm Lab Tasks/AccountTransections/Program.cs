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
            Account s1 = new Account("Shahariar", "13123", 2123131);
            Account s2 = new Account("alir", "14243", 10000);
            Account r1 = new Account("Tabassym", "11123", 5000);
            Account r2 = new Account("Shahariar", "4443", 20000);

            Transections t1 = new Transections(s1, r1, 1000, "send money");
            Transections t2 = new Transections(s1, r2, 550, "send money");

            s1.addTransaction(t1, t2);
            s1.showAllTransection();
            s1.ShowInfo();
            s1.Transfer(r2, 1000);
        }
    }
}
