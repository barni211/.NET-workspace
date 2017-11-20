using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techniki_alorytmiczne_projekt1;



//jezeli dziele kwadrat o wymiarach [2,3]
namespace techniki_algorytmiczne_projekt1
{
    class Program
    {
        static int[,] tab = new int[100, 100]; //zysk
        static int[,] results = new int[100, 100]; //wynik
        static int costs = 1; //koszt
        static int[,] tempTable = new int[100, 100];
        static int complexity = 0;
        static Dictionary<int, Coordinates> divideList = new Dictionary<int, Coordinates>();
        static void losuj()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    results[i, j] = 0;
                }
            }

            //tab[1, 1] = 1;
            //tab[1, 2] = 2;
            //tab[1, 3] = 2;
            //tab[1, 4] = 3;
            //tab[1, 5] = 4;

            //tab[2, 1] = 1;
            //tab[2, 2] = 1;
            //tab[2, 3] = 3;
            //tab[2, 4] = 3;
            //tab[2, 5] = 5;

            //tab[3, 1] = 1;
            //tab[3, 2] = 2;
            //tab[3, 3] = 4;
            //tab[3, 4] = 6;
            //tab[3, 5] = 7;

            //tab[4, 1] = 2;
            //tab[4, 2] = 4;
            //tab[4, 3] = 10;
            //tab[4, 4] = 11;
            //tab[4, 5] = 12; 22 55 55

            tab[1, 1] = 2;
            tab[1, 2] = 2;
            tab[1, 3] = 2;
            tab[1, 4] = 3;
            tab[1, 5] = 4;

            tab[2, 1] = 5;
            tab[2, 2] = 5;
            tab[2, 3] = 3;
            tab[2, 4] = 3;
            tab[2, 5] = 5;

            tab[3, 1] = 5; //1  1  2  3  4
            tab[3, 2] = 5; //1  1  3  3  5
            tab[3, 3] = 4; //1  2  4  6  7
            tab[3, 4] = 6; //2  4  10 11 11
            tab[3, 5] = 7;

            tab[4, 1] = 2;
            tab[4, 2] = 4;
            tab[4, 3] = 10;
            tab[4, 4] = 11;
            tab[4, 5] = 12;
        }

   

        public static int bottom_up(int k, int n)
        {
            int temp = 0;
            int zysk = tab[1, 1] * (k * n) - ((k * n - 1) * costs);
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    temp = tab[i, j];
                    for (int q = 0; q < i; q++)
                    {
                        temp = Math.Max(temp, tab[q, j] + results[i - q, j] - costs);
                    }
                    for (int q = 0; q < j; q++)
                    {
                        temp = Math.Max(temp, tab[i, q] + results[i, j - q] - costs);
                    }
                    results[i, j] = temp;
                }
            }

            if (zysk < temp)
            {
                zysk = temp;
                //divideList.Add(temp, new Coordinates(i, j));
            }

            return zysk;
        }

        //zrobic bottom up

        //top down
        //zlozonosc 2*k(2*n) + 2*l(2*n)
        static int dynamic_diff(int k, int l)
        {
            if (results[k, l] > 0)
            {
                return results[k, l];
            }
            int q = tab[k, l];
            //complexity += 1;
            for (int i = 1; i < k; i++)
            {
                q = Math.Max(q, dynamic_diff(i, l) + dynamic_diff(k - i, l)/*tab[k - i, l]*/ - costs);
                //complexity += 3;              
            }
            for (int i = 1; i < l; i++)
            {
                q = Math.Max(q, dynamic_diff(k, i) + dynamic_diff(k, l - i) /*tab[k, l-i]*/ - costs);
                //complexity += 3;
            }
            results[k, l] = q;

            return q;
        }


        static void wypisz(int n, int m)
        {
            for (int i = 1; i <= n; i++)
            {

                for (int j = 1; j <= m; j++)
                {
                    Console.Write(results[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }

        static void wypiszZyski(int n, int m)
        {
            for (int i = 1; i <= n; i++)
            {

                for (int j = 1; j <= m; j++)
                {
                    Console.Write(tab[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }



     

        static void Main(string[] args)
        {

            int n = 2, m = 3;
            //int n = 4, m = 5;

            losuj();
            int result = dynamic_diff(n, m);
            Console.WriteLine("Macierz zysków\n");
            wypiszZyski(n, m);
            Console.WriteLine("\nMacierz wynikowa\n");
            wypisz(n, m);

            Console.WriteLine("\nMetoda top down (rekurencyjnie) koncowy zysk: " + result);


            losuj();
            int result2 = bottom_up(n, m);
            Console.WriteLine("\nMacierz zysków\n");
            wypiszZyski(n, m);
            Console.WriteLine("\nMacierz wynikowa\n");
            wypisz(n, m);
            Console.WriteLine();
            Console.WriteLine("\nMetoda bottom up koncowy zysk: " + result2);

            Console.WriteLine("\nTablica uzyskania wyniku\n");

            //for(int i =0; i<divideList.Count;i++)
            //{
            //    Console.WriteLine("Zysk " + divideList.Keys.ElementAt(i) + " miejsce podziału [" +
            //        divideList.Values.ElementAt(i).x + ":" + divideList.Values.ElementAt(i).y + "]");
            //}
            Console.WriteLine("\nDla problemu o wymiarach " + n +"x" +m + " wykonano " + complexity + " operacji");

            Console.ReadKey();
        }
    }
}