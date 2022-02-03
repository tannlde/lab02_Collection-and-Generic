using System;
using System.Collections;
using System.IO;

namespace lab02_Collection_and_Generic_Part_2
{
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
                FileStream ouput = new(fileName, FileMode.CreateNew, FileAccess.Write);
                Console.WriteLine(Path.GetFullPath(fileName));
                StreamWriter writer = new(ouput);

                foreach (var item in Accounts)
                {

                    writer.WriteLine((item as Account).ToString());
                }
                writer.Close();
                ouput.Close();
            }
            catch (IOException e)
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
                FileStream input = new(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new(input);

                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] list = str.Split(',');
                    Account acc = new(list[0].Trim(), double.Parse(list[3].Trim()), list[1].Trim(), list[2].Trim());
                    Accounts.Add(acc);
                }
                reader.Close();
                input.Close();
            }
            catch (IOException e)
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
            AccountComparer ac = new();
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
    }
}
