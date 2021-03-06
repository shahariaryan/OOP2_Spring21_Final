using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransections
{
    class Account
    {
     
        public string AccName { get; set; }
        public string AccNo { get; }
        public double Balance { get; set; }

        Transections[] transections;
        public int totalNumberOfTransections { get; set; }

        public Account() {
            transections = new Transections[10];
        }
           
        public Account(string accName, string accNo, double balance)
        {
            AccName = accName;
            AccNo = accNo;
            Balance = balance;
            transections = new Transections[10];
        }
        public void addTransaction(params Transections[] transections)

        {
           foreach(Transections transaction in transections)
            {
                this.transections[totalNumberOfTransections++] = transaction;
              
            }
        }

        public void showAllTransection()
        {
            for(int i=0;i< totalNumberOfTransections;i++ )
            {
                transections[i].ShowInfo();
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("Name: " + AccName);
            Console.WriteLine("Acc No: " + AccNo);
            Console.WriteLine("Balance: " + Balance);

        }
        

        public void Deposit(int amount)
        {
            Balance += amount;
            transections[totalNumberOfTransections++] = new Transections(this, this, amount, "self deposit");
        }
        virtual public void Withdraw(int amount)
        {
            if(amount<Balance)
            {
                Balance -= amount;
                Console.WriteLine("Balance now is {0}}:", Balance);
                transections[totalNumberOfTransections++] = new Transections(this, this, amount, "self Widhdraw");
            }
            else
            {
                Console.WriteLine("Not Enough Balance");
            }
        }
        

        virtual public void Transfer(Account transaction, int amount)
        {
            if(amount<Balance)
            {
                Balance -= amount;
                Console.WriteLine("Balance now is {0}}:", Balance);
                transections[totalNumberOfTransections++] = new Transections(this, transaction, amount, "Transfer");
            }
            else
            {
                Console.WriteLine("Not Enough Balance");
            }
        }


    }
}