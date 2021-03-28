using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Interface_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone p1 = new Phone("Nokia", "1111");
            p1.ShowInfo();
            p1.switching(true);
        }
    }
}
