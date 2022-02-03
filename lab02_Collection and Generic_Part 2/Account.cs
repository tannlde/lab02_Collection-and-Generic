using System;

namespace lab02_Collection_and_Generic_Part_2
{
    [Serializable]
    class Account
    {
        private string accountID;
        private double balance;
        private string firstName;
        private string lastName;

        public Account()
        {
        }

        public Account(string accountID)
        {
            AccountID = accountID;
        }

        public Account(string accountID, double balance, string firstName, string lastName)
        {
            AccountID = accountID;
            Balance = balance;
            FirstName = firstName;
            LastName = lastName;
        }

        public string AccountID { get => accountID; set => accountID = value; }
        public double Balance { get => balance; set => balance = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public void FillInfo()
        {
            Console.WriteLine("Account ID: ");
            AccountID = Console.ReadLine();
            Console.WriteLine("First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Balance: ");
            Balance = double.Parse(Console.ReadLine());

        }

        public void Query()
        {
            Console.WriteLine($"{{{AccountID}, {FirstName}, {LastName}, {Balance}}}");
        }

        public override string ToString() => $"{AccountID}, {FirstName}, {LastName}, {Balance}";
    }
}
