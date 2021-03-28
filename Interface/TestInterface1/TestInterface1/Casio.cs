using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface1
{
    class Casio : BasicCalculatorInterface, ScientificCalculatorInterface
    {
        int x = 10;
            int y = 10;
        public int division(int x, int y)
        {
            return x / y;
        }

        public int multiplication(int x, int y)
        {
            return x * y;
        }

        public int sub(int x, int y)
        {
            return x - y;
        }

        public int sum(int x, int y)
        {
            return x + y;
        }

        public double XsquarerootY(double x)
        {
            return Math.Sqrt(x);
        }

        public int XtoY(int x, int y)
        {
            return (int)Math.Pow(x,y);
           
        }
        public void ShowInfo()
        {
            Console.WriteLine("Sum is " + (x + y));
            Console.WriteLine("Sub is " + (x - y));
            Console.WriteLine("Multipication is " + (x * y));
            Console.WriteLine("Division is " + (x / y));
            Console.WriteLine("Power is " + (Math.Pow(x,y)));
            Console.WriteLine("Square root is " + Math.Sqrt(x));
        }

        
    }
}
