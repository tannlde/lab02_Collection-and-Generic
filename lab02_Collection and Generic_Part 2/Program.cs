using System;

namespace lab02_Collection_and_Generic_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountList accountList= new();
            while (true)
            {
                Console.WriteLine("Enter Add/Save/Load/Report/Remove/Exit");
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "ADD":
                        accountList.NewAccount();
                        break;
                    case "SAVE":
                        accountList.SaveFile();
                        break;
                    case "LOAD":
                        accountList.LoadFile();
                        break;
                    case "REPORT":
                        accountList.Report();
                        break;
                    case "REMOVE":
                        accountList.Remove();
                        break;
                    case "EXIT":
                        return;
                    default:
                        Console.WriteLine("Try agian");
                        break;
                }
            }
        }
    }
}
