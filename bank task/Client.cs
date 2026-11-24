using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_task
{
    internal class Client
    {
       

        public string Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public double Salary { get; set; }

        public BankCard BankCard { get; set; }


        public Client(string id, string name, string surname, int age, double salary, BankCard bankCard)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            BankCard = bankCard;
        }

    }
}
