using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface1
{
    class Program
    {
        static void Main(string[] args)
            
        {
            NormalCalculator n1 = new NormalCalculator();
            Casio c1 = new Casio();
            Console.WriteLine("****Normal Calcultor*****");
            n1.ShowInfo();
            Console.WriteLine("****Scientific Calcultor*****");
            c1.ShowInfo();
        }
    }
}
