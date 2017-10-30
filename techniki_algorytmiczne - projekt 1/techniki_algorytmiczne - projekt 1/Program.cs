using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//jezeli dziele kwadrat o wymiarach [2,3] 
namespace techniki_algorytmiczne___projekt_1
{
    class Program
    {
        static int[,] tab = new int[100,100]; //zysk
        static int[,] results = new int[100,100]; //wynik
        static int[,] costs = new int[100,100]; //koszt
        static int zysk = 0;
       


        static void losuj()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                for(int j=0; j<100; j++)
                {
                    costs[i, j] = 1;//rnd.Next(7);
                    //tab[i, j] = rnd.Next(7);
                    results[i, j] = 0;
                }
                //Debug.Print(tab[i] + "\n");
            }

            tab[0,0] = 1;
            tab[0, 1] = 2;
            tab[0, 2] = 2;
            tab[0, 3] = 3;
            tab[0, 4] = 4;

            tab[1, 0] = 1;
            tab[1, 1] = 1;
            tab[1, 2] = 3;
            tab[1, 3] = 3;
            tab[1, 4] = 5;

            tab[2, 0] = 1;
            tab[2, 1] = 2;
            tab[2, 2] = 4;
            tab[2, 3] = 6;
            tab[2, 4] = 7;

            tab[3, 0] = 2;
            tab[3, 1] = 4;
            tab[3, 2] = 10;
            tab[3, 3] = 11;
            tab[3, 4] = 12;
        }
        //static int diff(int length)
        //{
        //    int q = tab[length];
        //    for (int i = 1; i < length - 1; i++)
        //    {
        //        q = Math.Max(tab[i], diff(length - i) + tab[i]);
        //    }
        //    return q;
        //}

        static int dynamic_diff(int n, int m)
        {
            if (results[n,m] > 0)
            {
                zysk += results[n, m] - costs[n,m];
                return results[n,m];
            }

            results[n,m] = tab[n,m];
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    int temp = 0;
                    for (int q = 0; q < i; q++)
                    {
                        if(tab[i,q] > temp)
                        {
                            temp += tab[i, q] - costs[i, q];
                        }
                    }
                    for(int z = 0; z < j; z++)
                    {
                        if (tab[z, j] > temp)
                        {
                            temp += tab[z, j] - costs[z,j];
                        }
                    }
                    results[i, j] = temp;//Math.Max(tab[i,j], dynamic_diff(n - i, m - j) + tab[i,j] - costs[i,j]);
                }
            }
            zysk += results[n, m];
            return results[n,m];
        }

        //static int dynamic_diff(int length)
        //{
        //    if (results[length] > 0)
        //    {
        //        return results[length];
        //    }

        //    results[length] = tab[length];
        //    for (int i = 1; i < length - 1; i++)
        //    {
        //        results[i] = Math.Max(tab[i], dynamic_diff(length - i) + tab[i]);
        //    }
        //    return results[length];
        //}

        //static void bottom_up_cut_pipe(int length)
        //{
        //    results[1] = tab[1];
        //    for (int j = 0; j < length; j++)
        //    {
        //        results[j] = tab[j];
        //        for (int i = 0; i < j - 1; i++)
        //        {
        //            results[j] = Math.Max(results[j], results[i] + results[j - i]);
        //        }

        //    }

        //}

        static void wypisz(int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                
                for(int j = 0; j < m; j++)
                {
                    Console.Write(results[i,j] + "\t");
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {

            int n = 4, m = 5;

            losuj();

            int length = 100;
            dynamic_diff(n, m);
            //bottom_up_cut_pipe(l);
            wypisz(n,m);
            Console.Write("koncowy zysk: " + zysk);
            Console.ReadKey();
        }
    }
}