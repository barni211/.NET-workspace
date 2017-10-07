using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenie1_fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicTable<int> myOwnTable = BasicTable<int>.GetInstance();
            myOwnTable.SetSource(TableType.ListTable);
            myOwnTable.CreateTableFromBegin(10);
            myOwnTable.AddElement(3, 3);
            myOwnTable.AddElement(10, 5);
            myOwnTable.AddElement(14, 13);

            BasicTable<int> myOwnTableTwo = (BasicTable<int>)myOwnTable.Clone();



            myOwnTableTwo.ShowElements();

            myOwnTableTwo.SetSource(TableType.ArrayTable);
            myOwnTableTwo.CreateTableFromRange(3, 10);
            myOwnTableTwo.AddElement(3, 13);
            myOwnTableTwo.AddElement(8, 9);
            myOwnTableTwo.AddElement(11, 3);
            myOwnTableTwo.AddElement(10, 5);
            myOwnTableTwo.AddElement(31, 10);
            myOwnTableTwo.AddElement(2, 2);
            myOwnTableTwo.ShowElements();

            Console.Read();
        }
    }
}
