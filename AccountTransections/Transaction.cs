using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransections
{
    class Transections
    {
         public Account sender;
        public  Account receiver;
        public int Amount { get; set; }
        public string AdditionalInfo { get; set; }

    
        public Transections() { }
        public Transections(Account sender, Account receiver, int amount, string additionalInfo)
        {
            this.sender = sender;
            this.receiver = receiver;
              Amount = amount;
              AdditionalInfo = additionalInfo;
        }
        public void ShowInfo()
        { 
            Console.WriteLine("Details: " + AdditionalInfo);
               Console.WriteLine("Sender: " + sender.AccName);
                Console.WriteLine("Receiver: " + receiver.AccName);
                  Console.WriteLine("Amount: " + Amount);
                   Console.WriteLine("amount is:" + Amount);
        }

    }
}