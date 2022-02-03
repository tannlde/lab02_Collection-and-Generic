using System.Collections;


namespace lab02_Collection_and_Generic_Part_2
{
    class AccountComparer : IComparer
    {

        public int Compare(object x, object y)
        {
            return (x as Account).AccountID.CompareTo((y as Account).AccountID);
        }
    }
}
