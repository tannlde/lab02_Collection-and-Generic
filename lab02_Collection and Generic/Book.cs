using System;
using System.Collections;

namespace lab02_Collection_and_Generic
{
    class Book : IBook, IComparable
    {
        private string isbn;
        private string title;
        private string author;
        private string publisher;
        private int year;

        private ArrayList chapter = new();
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < chapter.Count) return (string)chapter[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < chapter.Count) chapter[index] = value;
                else if (index == chapter.Count) chapter.Add(value);
                else throw new IndexOutOfRangeException();
            }
        }

        public string ISBN { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Year { get => year; set => year = value; }

        public void Show()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Title " + Title);
            Console.WriteLine("Author " + Author);
            Console.WriteLine("Publisher " + Publisher);
            Console.WriteLine("Year " + Year);
            Console.WriteLine("ISBN " + ISBN);
            Console.WriteLine("Chapter ");
            for (int i = 0; i < chapter.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}: {chapter[i]}");
            }
            Console.WriteLine("---------------------");
        }

        public void Input()
        {
            Console.WriteLine("Title: ");
            Title = Console.ReadLine();
            Console.WriteLine("Author: ");
            Author = Console.ReadLine();
            Console.WriteLine("Publisher : ");
            Publisher = Console.ReadLine();
            Console.WriteLine("ISBN: ");
            ISBN = Console.ReadLine();
            Console.WriteLine("Year: ");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input chapter (finished with empty string)");
            string str;
            do
            {
                str = Console.ReadLine();
                if (str.Length > 0) chapter.Add(str);
            } while (str.Length > 0);
        }

        public int CompareTo(object obj)
        {
            Book b = obj as Book;
            if (b.Year > Year) return 1;
            if (b.Year < Year) return -1;
            return 0;
        }
    }
}
