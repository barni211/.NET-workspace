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
       // static List<int> listaZyskow = new List<int>();
       


        static void losuj()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    costs[i, j] = 1;//rnd.Next(7);
                    //tab[i, j] = rnd.Next(7);
                    results[i, j] = 0;
                }
                //Debug.Print(tab[i] + "\n");
            }

            tab[1, 1] = 3;
            tab[1, 2] = 6;
            tab[2, 1] = 5;
            tab[2, 2] = 12;

            //tab[0, 0] = 1;
            //tab[0, 1] = 2;
            //tab[0, 2] = 2;
            //tab[0, 3] = 3;
            //tab[0, 4] = 4;

            //tab[1, 0] = 1;
            //tab[1, 1] = 1;
            //tab[1, 2] = 3;
            //tab[1, 3] = 3;
            //tab[1, 4] = 5;

            //tab[2, 0] = 1;
            //tab[2, 1] = 2;
            //tab[2, 2] = 4;
            //tab[2, 3] = 6;
            //tab[2, 4] = 7;

            //tab[3, 0] = 2;
            //tab[3, 1] = 4;
            //tab[3, 2] = 10;
            //tab[3, 3] = 11;
            //tab[3, 4] = 12;
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

        //static int dynamic_diff(int n, int m)
        //{
        //    if (results[n, m] > 0)
        //    {
        //        zysk += results[n, m] - costs[n, m];
        //        return results[n, m] - costs[n, m];
        //    }

        //    results[n,m] = tab[n,m];

        //dwa problemy sa kompletnie niezalezne wiec mozna stosowac rekurencje
        //    for (int i = 0; i <= n - 1; i++)
        //    {
        //        for (int j = 0; j <= m - 1 ; j++)
        //        {
        //            int temp = 0;
        //            for (int q = 0; q <= i; q++)
        //            {
        //                if(tab[i,q] > temp)
        //                {
        //                    temp = tab[i, q] - costs[i, q];
        //                }
        //            }
        //            for(int z = j; z <= m - 1; z++)
        //            {
        //                if (tab[z, j] > temp)
        //                {
        //                    temp = tab[z, j] - costs[z,j];
        //                }
        //            }

        //            if(temp > zysk)
        //            {
        //                zysk = temp;
        //                results[i, j] = temp;
        //            }
        //            //Math.Max(tab[i,j], dynamic_diff(n - i, m - j) + tab[i,j] - costs[i,j]);
        //        }

        //    }
        //    //zysk += temp;//results[n, m];
        //    return zysk;// results[n,m];
        //}

        //static int dynamic_diff(int n, int m)
        //{
        //    if (results[n,m] > 0)
        //    {
        //        return results[n,m];
        //    }

        //    results[n,m] = tab[n,m];
        //    for (int i = 0; i <= n - 1; i++)
        //    {
        //        for(int j = 0; j <= m - 1; j++)
        //        {
        //            results[n, m] = Math.Max(tab[i, j], dynamic_diff(i, j) + tab[i, j]);
        //            if(results[n,m] > zysk)
        //            {
        //                zysk = results[n, m];
        //            }
        //        }
        //        //results[i] = Math.Max(tab[i], dynamic_diff(length - i) + tab[i]);
        //    }
        //    return results[n,m];
        //}

            //for(i=1 ... k-1)
                //q=max(f(i,l) + f(k-1,l); + 

        //static int dynamic_diff(int n, int m)
        //{
        //    if (results[n, m] > 0)
        //    {
        //        return results[n, m];
        //    }

        //    results[n, m] = tab[n, m];
        //    for (int i = 1; i <= n - 1; i++)
        //    {
        //        for (int j = 1; j <= m - 1; j++)
        //        {
        //            results[n, m] = Math.Max(tab[i, j] , dynamic_diff(n-i, m-i) + tab[i, j] - costs[i,j]);
        //            if (results[n, m] > zysk)
        //            {
        //                zysk = results[n, m];
        //            }
        //        }
        //        //results[i] = Math.Max(tab[i], dynamic_diff(length - i) + tab[i]);
        //    }

       //zrobic bottom up

       //top down
       static int dynamic_diff(int k, int l)
       {
            if (results[k, l] > 0)
            {
                return results[k, l];
            }

            int q = tab[k,l] ;
            for (int i = 1; i < k ; ++i)
            {
                q = Math.Max(q, dynamic_diff(i, l) + dynamic_diff(k-i, l)/*tab[k - i, l]*/ - costs[0,0]) ;
            }
            for (int i = 1; i < l ; ++i)
            {
                q = Math.Max(q, dynamic_diff(k, i) + dynamic_diff(k, l-i) /*tab[k, l-i]*/ - costs[0,0] ) ;
            }
            results[k, l] = q;
            return q;
        }

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
            for (int i = 1; i <= n; i++)
            {
                
                for(int j = 1; j <= m; j++)
                {
                    Console.Write(results[i,j] + "\t");
                    if (results[i, j] > zysk)
                    {
                        zysk = results[i, j];
                    }
                }
                Console.WriteLine("");
            }
        }

        static void wypiszZyski(int n, int m)
        {
            for (int i = 1; i <= n ; i++)
            {

                for (int j = 1; j <= m ; j++)
                {
                    Console.Write(tab[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {

            //int n = 4, m = 5;
            int n = 2, m = 2;

            losuj();

            int length = 100;
            zysk = 0;
            dynamic_diff(n, m);
            //bottom_up_cut_pipe(l);
            Console.WriteLine("Macierz wyników\n");
            wypisz(n,m);

            Console.Write("\n");
            Console.WriteLine("Macierz zysków\n");
            wypiszZyski(n, m);
            //dynamic_diff(n, m);

            Console.Write("\n");

            Console.Write("koncowy zysk: " + zysk);
            Console.ReadKey();
        }
    }
}