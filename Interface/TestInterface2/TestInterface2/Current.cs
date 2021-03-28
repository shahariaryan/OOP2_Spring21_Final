﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface2
{
    class Current:Account , BasicBankingInterface

    {
        public Current(string AccName, string AccNo, double balance) : base(AccName, AccNo, balance) { }
        override public void deposit(int amount)
        {
            Balance += amount;
            Console.WriteLine("Your money deposited by {0} to self", amount);
        }

       override public void widhdraw(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Your money has been widrawn by {0} to self", amount);
               
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
    }
}