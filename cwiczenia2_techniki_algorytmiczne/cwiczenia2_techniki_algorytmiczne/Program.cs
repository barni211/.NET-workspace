using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2_techniki_algorytmiczne
{
    class Program
    {

        static void generujMacierz(int[,] M, int sizeI, int sizeJ)
        {
            for (int i = 0; i < sizeI; i++)
            {
                for (int j = 0; j < sizeJ; j++)
                {
                    M[i,j] = 0;
                }
            }
        }

        static void wypisz(int[,] M, int sizeI, int sizeJ)
        { 
            for (int i = 0; i < sizeI; i++)
            {
                for (int j = 0; j < sizeJ; j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }


        static int[,] costs = new int[100, 100];

        static int recursiveFn(int i, int j, int[] P)
        {
            if (i==j)
            {
                return 0;
            }
            else
            {
                //return recursiveFn(P[i],P[k], P) + recursiveFn(P[k+1,j, P) + P[i - 1] * P[k] * P[j];
                int q = 345533;
                int tempValue = 30000000;
                
                for (int k=i; k< j; k++)
                {
                    tempValue = recursiveFn(i, k, P) + recursiveFn(k + 1, j, P) + P[i - 1] * P[k] * P[k];
                    if(tempValue<q)
                    {
                        q = tempValue;
                    }
                }
                costs[i, j] = q;
                return q;
            }
        }
      
        static void Main(string[] args)
        {
               
            int[] P = new int[20];
            P[0] = 10;
            P[1] = 10;
            P[2] = 10;
            P[3] = 10;
            P[4] = 10;
            P[5] = 10;
            P[6] = 10;
            P[7] = 10;

            recursiveFn(3, 5, P);

            wypisz(costs, 10, 10);


            //int[,] A1 = new int[10,10];
            //int[,] A2 = new int[30, 10];
            //int[,] A3 = new int[10, 30];
            //int[,] A4 = new int[5, 15];

            //generujMacierz(A1, 10, 10);
            //wypisz(A1, 10, 10);

            //generujMacierz(A2, 30, 10);
            //wypisz(A1, 30, 10);

            //generujMacierz(A3, 10, 20);
            //wypisz(A3, 10, 20);

            //generujMacierz(A4, 5, 15);
            //wypisz(A1, 5, 15);


            Console.Read();
        }

       
    }
}
