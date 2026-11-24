using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bank_task
{
    internal class ATM
    {

        private Bank _bank;
        private BankCard CurrentCard;

        private List<Transaction> Transactions = new List<Transaction>();

        public ATM(Bank bank)
        {
            _bank = bank;
        }




        public void EnterPin()
        {
            while (true)
            {

                Console.Write("Enter PIN: ");
                string pin = Console.ReadLine();
                Client client = _bank.FindClientByPin(pin);
                if (client == null)
                {
                    Console.WriteLine("No card found for this PIN!");
                    continue;
                }
                CurrentCard = client.BankCard;

                Console.WriteLine($"Welcome, {client.Name} {client.Surname}!");
                ShowMenu();
                break;
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Your balance: {CurrentCard.Balance}");
        }

        public void CashWithdrawal()
        {
            Console.WriteLine("1. 10 AZN");
            Console.WriteLine("2. 20 AZN");
            Console.WriteLine("3. 50 AZN");
            Console.WriteLine("4. 100 AZN");
            Console.WriteLine("5. Diger");
            Console.Write("Secimi daxil et: ");

            string choice = Console.ReadLine();
            double amount = 0;

            switch (choice)
            {
                case "1":
                    amount = 10;
                    break;
                case "2":
                    amount = 20;
                    break;
                case "3":
                    amount = 50;
                    break;
                case "4":
                    amount = 100;
                    break;
                case "5":
                    Console.Write("Meblegi daxil et: ");
                    amount = double.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Yanlis secim!");
                    return;
            }

            if (amount <= 0)
            {
                throw new Exception("Invalid amount!");
            }

            if (amount > CurrentCard.Balance)
            {
                throw new Exception("Insufficient balance!");
            }

            CurrentCard.Withdraw(amount);

            Transactions.Add(new Transaction("Cash Withdrawal", amount, DateTime.Now));

            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine($"Remaining balance: {CurrentCard.Balance}");
        }
        public void ShowTransactions()
        {
            Console.WriteLine("1. Last 1 day");
            Console.WriteLine("2. Last 5 day");
            Console.WriteLine("3. Last 10 day");

            Console.Write("Choose period: ");
            int days = int.Parse(Console.ReadLine());

            if (days == 1)
            {
                days = 1;
            }
            else if (days == 2)
            {
                days = 5;
            }
            else if (days == 3)
            {
                days = 10;
            }
            else
            {
                Console.WriteLine("Inalid choice");
                return;
            }

            DateTime startDate = DateTime.Now.AddDays(-days);

            bool found = false;

            foreach (var transaction in Transactions)
            {

                if (transaction.Date >= startDate)
                {
                    Console.WriteLine($"Operation:{transaction.Operation}");
                    Console.WriteLine($"Amount: {transaction.Amount}");
                    Console.WriteLine($"Date: {transaction.Date}");
                    Console.WriteLine("----------------------");

                    found = true;


                }

            }

            if (!found)
            {
                Console.WriteLine("No transactions found!");
            }


        }


         public void TransferMoney()
        {
            Console.Write("Enter receiver PAN: ");
            string receiverPan = Console.ReadLine();

            BankCard receiverCard = null;

            foreach (var client in _bank.Clients)
            {
                if (client.BankCard.PAN == receiverPan)
                {
                    receiverCard = client.BankCard;
                    break;
                }
            }

            if (receiverCard == null)
            {
                Console.WriteLine("Card not found!");
                return;
            }

            if (receiverCard.PAN == CurrentCard.PAN)
            {
                Console.WriteLine("You cannot transfer money to your own card!");
                return;
            }

            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            if (amount > CurrentCard.Balance)
            {
                throw new Exception("Insufficient balance!");
            }

            CurrentCard.Withdraw(amount);
            receiverCard.Deposit(amount);

            Transactions.Add(new Transaction(
                "Money Transfer",
                amount,
                DateTime.Now
            ));

            Console.WriteLine("Transfer completed successfully!");
            Console.WriteLine($"Remaining balance: {CurrentCard.Balance}");
        }






        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== ATM MENU =====");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Cash Withdrawal");
                Console.WriteLine("3. Transaction History");
                Console.WriteLine("4. Card-to-Card Transfer");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckBalance();
                        break;

                    case 2:
                        try
                        {
                            CashWithdrawal();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        ShowTransactions();
                        break;

                    case 4:
                        try
                        {
                            TransferMoney();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }





        }




    }
}
