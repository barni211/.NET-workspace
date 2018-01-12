using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickSortMultiThread
{
    //jezeli za duzo watkow, to s
    public class QuickSort
    {
        private static int size = 100;
        private int[] tab = new int[size];

        public QuickSort(int[] tab)
        {
            this.tab = tab;
        }


        private void CreateTable()
        {
            Random rand = new Random();
            for(int i=0; i< size; i++)
            {
                tab[i] = rand.Next(30);
            }
        }

        private bool CheckThatTableIsSorted()
        {
            for(int i = 1; i< size; i++)
            {
                if(tab[i-1]>tab[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void Sort(int low, int high)
        { 
            //if(CheckThatTableIsSorted())
            //{
            //    //Console.Write("Posortowano");
            //}
            if (low < high)
            {
                int pivot = Partition(low, high);
                Thread leftTab = new Thread(() => Sort(low, pivot - 1));
                leftTab.Start();
                Thread rightTab = new Thread(() => Sort(pivot + 1, high));
                rightTab.Start();
                leftTab.Join();
                rightTab.Join();
            }
            
        }

        private void Swap(int i, int j)
        {
            int temp = tab[i];
            tab[i] = tab[j];
            tab[j] = temp;
        }

        private int Partition(int low, int high)
        {
            int pivot = tab[high];

            int i = (low - 1);  // Indeks najmniejszego elementu

            for (int j = low; j <= high - 1; j++)
            {
                // Jeżeli element jest mniejszy bądź równy pivot
                if (tab[j] <= pivot)
                {
                    i++;    // zwiększ indeks najmniejszego elementu
                    Swap(i, j);
                }
            }
            Swap(i + 1, high);
            return (i + 1);
        }

    }
}
