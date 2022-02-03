using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab02_Collection_and_Generic_Part_2
{
    class SortByFirstNameAsc : IComparer
    {
        public int Compare(object x, object y) => (x as Account).FirstName.CompareTo((y as Account).FirstName);
    }

    class SortByBalanceAsc : IComparer
    {
        public int Compare(object x, object y)
        {
            double b1 = (x as Account).Balance;
            double b2 = (y as Account).Balance;
            if (b1 > b2) return 1;
            if (b1 < b2) return -1;
            return 0;
        }
    }

    class SortByAccountIDAsc : IComparer
    {
        public int Compare(object x, object y)
        {
            return (x as Account).AccountID.CompareTo((y as Account).AccountID);
        }
    }

    class AccountList
    {
        private ArrayList Accounts = new();

        public void NewAccount()
        {
            Account acc = new();
            acc.FillInfo();
            Accounts.Add(acc);
        }

        public void SaveFile()
        {
            Console.Write("Input file name to save: ");
            string fileName = Console.ReadLine();
            try
            {
                BinaryFormatter bf = new();
                FileStream output = new(fileName, FileMode.CreateNew, FileAccess.Write);
                bf.Serialize(output, Accounts);
                output.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadFile()
        {
            Console.Write("Input file name to load: ");
            string fileName = Console.ReadLine();
            Accounts.Clear();
            try
            {
                BinaryFormatter bf = new();
                FileStream input = new(fileName, FileMode.Open, FileAccess.Read);
                Accounts = (ArrayList)bf.Deserialize(input);
                input.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Report()
        {
            foreach (var item in Accounts)
            {
                (item as Account).Query();
            }
        }

        public void Remove()
        {
            SortByAccountIDAsc ac = new();
            Accounts.Sort(ac);
            Console.Write("Enter Account ID to remove: ");
            string accID = Console.ReadLine();
            int pos = Accounts.BinarySearch(new Account(accID), ac);
            if (pos < 0) Console.WriteLine("Not found!");
            else
            {
                Accounts.RemoveAt(pos);
                Console.WriteLine("Removed");
            }
        }
        public void SortByFirstNameAsc()
        {
            Accounts.Sort(new SortByFirstNameAsc());
        }

        public void SortByBalanceAsc()
        {
            Accounts.Sort(new SortByBalanceAsc());
        }

        public void SortByAccountIDAsc()
        {
            Accounts.Sort(new SortByAccountIDAsc());
        }
    }
}
