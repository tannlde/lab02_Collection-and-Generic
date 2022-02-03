using System;
using System.Collections;

namespace lab02_Collection_and_Generic
{
    class BookList
    {
        private ArrayList list = new();

        public void AddBook()
        {
            Book b = new();
            b.Input();
            list.Add(b);
        }

        public void ShowList()
        {
            foreach (Book b in list)
            {
                b.Show();
            }
        }
        public void InputList()
        {
            int n;
            Console.WriteLine("Amount of books: ");
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                AddBook();
                n--;
            }
        }

        public void SortByYearDesc()
        {
            list.Sort();
        }
    }
}