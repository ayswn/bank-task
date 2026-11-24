using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_task
{
    internal class Transaction
    {


        public string Operation { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }


        public Transaction(string operation, double amount, DateTime date)
        {
            Operation = operation;
            Amount = amount;
            Date = date;
        }

    }
}
