
namespace lab02_Collection_and_Generic
{
    interface IBook
    {
        string this[int index] { get; set; }

        string Title { get; set; }

        string Author { get; set; }

        string Publisher { get; set; }

        string ISBN { get; set; }

        int Year { get; set; }

        void Show();
    }
}
