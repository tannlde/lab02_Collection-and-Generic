using System;

namespace lab02_Collection_and_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            BookList bl = new();
            bl.InputList();

            bl.ShowList();

            bl.SortByYearDesc();
            Console.WriteLine("Sort by year desc: ");
            bl.ShowList();

            Console.ReadLine();

        }
    }
}
