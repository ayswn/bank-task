namespace bank_task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bank bank = new Bank();

            Console.Write("How many clients do you want to add? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nClient {i + 1}");

                Console.Write("Enter ID: ");
                string ?id = Console.ReadLine();

                Console.Write("Enter Name: ");
                string ?name = Console.ReadLine();

                Console.Write("Enter Surname: ");
                string ?surname = Console.ReadLine();

                int age;

                while (true)
                {
                    Console.Write("Enter age: ");
                    age = int.Parse(Console.ReadLine());

                    if (age >= 18 && age <= 100)
                        break;

                    Console.WriteLine("Age must be between 18 and 100!");
                }
                Console.Write("Enter Salary: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Enter Bank Name: ");
                string ?bankName = Console.ReadLine();

                Console.Write("Enter Username: ");
                string ?username = Console.ReadLine();

                string pan;

                while (true)
                {
                    Console.Write("Enter 16-digit card number: ");
                    pan = Console.ReadLine();

                    if (pan.Length == 16)
                        break;

                    Console.WriteLine("Card number must contain 16 digits!");
                }

                string pin;

                while (true)
                {
                    Console.Write("Enter 4-digit PIN: ");
                    pin = Console.ReadLine();

                    if (pin.Length == 4)
                        break;

                    Console.WriteLine("PIN must contain 4 digits!");
                }
                Console.Write("Enter Expire Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Expire Month: ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Enter Expire Day: ");
                int day = int.Parse(Console.ReadLine());

                BankCard card = new BankCard(
                    bankName,
                    username,
                    pan,
                    pin,
                    new DateTime(year, month, day)
                );

                Client client = new Client(
                    id, name, surname, age, salary, card
                );

                bank.AddClient(client);

                Console.WriteLine("Client added successfully!");
                Console.WriteLine($"Generated CVC: {card.CVC}");
                Console.WriteLine($"Generated Balance: {card.Balance}");
            }

            ATM atm = new ATM(bank);
            atm.EnterPin();


        }
    }
}

