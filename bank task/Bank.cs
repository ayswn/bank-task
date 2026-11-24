using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_task
{
    internal class Bank
    {

        public List<Client> Clients { get; set; } = new List<Client>();
        public void AddClient(Client new_client)
        {
            Clients.Add(new_client);

        }

        public BankCard CheckCard(string pin, string pan)
        {
            foreach (var client in Clients) {
                if (client.BankCard.PIN == pin && client.BankCard.PAN==pan)
                {
                    return client.BankCard;
                }
            
            
            }
            return null;
        }


        public BankCard FindCardByPin(string pin)
        {
            foreach (var client in Clients)
            {
                if (client.BankCard.PIN == pin)
                {
                    return client.BankCard;
                }
            }

            return null;
        }

        public void showtce(string pin, string pan)
        {
            BankCard card = CheckCard(pin, pan);
            if (card != null)
            {
                Console.WriteLine($"Card found: {card.BankName} | PAN: {card.PAN} | Balance: {card.Balance}");
            }
            else
            {
                Console.WriteLine("Card with this PIN and PAN was not found!");
            }
        }


        public Client FindClientByPin(string pin)
        {
            foreach (var client in Clients)
            {
                if (client.BankCard.PIN == pin)
                {
                    return client;
                }
            }

            return null;
        }

        public void TransferMoney(BankCard senderCard, string receiverPan, double amount)
        {
            BankCard receiverCard = null;

            foreach (var client in Clients)
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

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            if (senderCard.Balance < amount)
            {
                throw new Exception("Insufficient balance!");
            }

            senderCard.Balance -= amount;
            receiverCard.Balance += amount;

            Console.WriteLine("Transfer completed successfully!");
        }


    }
}
