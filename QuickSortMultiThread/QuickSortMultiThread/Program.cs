using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortMultiThread
{
    class Program
    {

        
        static void Main(string[] args)
        {
            int size = 100;
            int[] tab = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                tab[i] = rand.Next(30);
                Console.Write(tab[i] + "\t");
            }
            Console.WriteLine("\nPo sorotowaniu");
            QuickSort sort = new QuickSort(tab);
            sort.Sort(0,99);

            for (int i = 0; i < size; i++)
            {
                Console.Write(tab[i] + "\t");
            }

            Console.Read();
        }


    }
}
