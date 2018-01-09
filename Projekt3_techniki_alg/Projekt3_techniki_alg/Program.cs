using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt3_techniki_alg
{
    class Program
    {
        private static List<int> tab = new List<int>();
        private static int R = 5;
        private static int size = 2000;
        private static long time;
        private static Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        private static List<string> resultList = new List<string>();

        private static List<long> metodaBazowa = new List<long>();
        private static List<long> metodaKubelkowa = new List<long>();

        private static List<int> iloscPunktow = new List<int>();

        public static void Start()
        {
            watch.Start();
        }

        public static void Stop()
        {
            watch.Stop();
        }

        public static void SaveTime()
        {
            time = watch.ElapsedMilliseconds;
        }

        private static int MaxValFromDict(Dictionary<int, List<int>> list)
        {
            int max = -1;
            foreach(int key in list.Keys)
            {
                if (key > max)
                {
                    max = key;
                }
            }
            return max;
        }


        static void Main(string[] args)
        {

            for (int h = 0; h < 10; h++)
            {
                iloscPunktow.Add(size);

                Random rand = new Random();

                for (int i = 0; i < size; i++)
                {
                    tab.Add(rand.Next(1000000));
                    //Console.Write(tab[i] + ", ");
                }


                int licznik = 0;
                int z = 0;

                tab.Sort();
                Start();
                for (int i = 0; i < size; i++)
                {
                    z = i + 1;
                    if (z >= tab.Count)
                    {
                        break;
                    }

                    while (Math.Abs(tab.ElementAt(z) - tab.ElementAt(i)) < R)
                    {
                        licznik++;
                        resultList.Add("[" + tab.ElementAt(i) + ", " + tab.ElementAt(z) + "]; ");
                        z++;
                        if (z >= tab.Count)
                        {
                            break;
                        }
                    }
                }
                Stop();
                SaveTime();
                //Console.WriteLine("\nLicznik " + licznik);
                //Console.WriteLine("\nTime: " + time);
                metodaBazowa.Add(time);

                //Console.WriteLine("\t\t\tMetoda kubełkowa:");

                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

                foreach (int elem in tab)
                {
                    int tmpVal = (int)Math.Floor((double)elem / (double)R);
                    if (map.ContainsKey(tmpVal) == false)
                    {
                        map.Add(tmpVal, new List<int>());
                    }
                }



                foreach (int elem in tab)
                {
                    int tmpVal = (int)Math.Floor((double)elem / (double)R);
                    if (map.ContainsKey(tmpVal) == true)
                    {
                        map[tmpVal].Add(elem);
                    }
                }

                watch.Reset();
                Start();

                int index = 0;
                licznik = 0;

                int maxValue = MaxValFromDict(map);
                while (index <= maxValue)
                {
                    List<int> currList = null;
                    List<int> nextList = null;
                    if (map.ContainsKey(index))
                    {
                        currList = map[index];
                    }

                    if (map.ContainsKey(index + 1))
                    {
                        nextList = map[index + 1];
                    }


                    if (currList != null)
                    {
                        for (int i = 0; i < currList.Count; i++)
                        {
                            int currentPoint = currList.ElementAt(i);
                            for (int j = i + 1; j < currList.Count(); j++)
                            {
                                licznik++;
                                resultList.Add("[" + currentPoint + ", " + currList.ElementAt(j) + "];");
                            }
                            if (nextList != null)
                            {
                                for (int p = 0; p < nextList.Count(); p++)
                                {
                                    if (Math.Abs(currentPoint - nextList.ElementAt(p)) < R)
                                    {
                                        licznik++;
                                        resultList.Add("[" + currentPoint + ", " + nextList.ElementAt(p) + "];");
                                    }
                                }
                            }
                        }
                    }
                    index++;
                }
                Stop();
                SaveTime();

                //Console.WriteLine("\nTime: " + time);
                //Console.WriteLine("Licznik " + licznik);
                metodaKubelkowa.Add(time);

                map.Clear();
                tab.Clear();
                size += 50000;
                //Console.Read();
            }

            Console.WriteLine("Metoda bazowa : Metoda kublekowa");
            for (int i  =0; i< iloscPunktow.Count(); i++)
            {
                Console.WriteLine(metodaBazowa[i] + " : " + metodaKubelkowa[i]);
            }

            ChartForm chr = new ChartForm();

            chr.AddBasicMetodChart(iloscPunktow, metodaBazowa);
            chr.AddBoxMetodChart(iloscPunktow, metodaKubelkowa);
            //chr.RefreshChart();

            chr.ShowDialog();

        }


       
    }
}
