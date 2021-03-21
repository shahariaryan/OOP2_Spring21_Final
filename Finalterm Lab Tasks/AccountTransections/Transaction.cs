using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransections
{
    class Transections
    {
        private Account sender;

        public Account Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private Account receiver;

        public Account Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private int additionalInfo;

        public int AdditionalInfo
        {
            get { return additionalInfo; }
            set { additionalInfo = value; }
        }

        private Account account;

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        private string strValue;

        public string StrValue
        {
            get { return strValue; }
            set { strValue = value; }
        }

        public Transections() { }
        public Transections(Account sender, Account receiver, int amount, string strValue)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Amount = amount;
            this.StrValue=strValue;
        }
        public void ShowInfo()
        {
            Console.WriteLine("sender is:" + sender);
            Console.WriteLine("receiver is:" + receiver);
            Console.WriteLine("amount is:" + amount);
            Console.WriteLine("Details:" + strValue);
        }

    }
}