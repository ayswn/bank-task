using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_task
{
    internal class BankCard
    {


        public string BankName { get; set; }
        public string Username { get; set; }
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Balance { get; set; }



        public BankCard(string bankName, string username, string pAN, string pIN,  DateTime expireDate)
        {
            BankName = bankName;
            Username = username;
            PAN = pAN;
            PIN = pIN;
           
            ExpireDate = expireDate;

            CVC = GenerateRandomCvc();
            Balance = Random.Shared.Next(100, 10000);
        }

        private static string GenerateRandomCvc()
        {
            int number = Random.Shared.Next(100, 1000);
            return number.ToString();
        }



        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

    










    }
}
