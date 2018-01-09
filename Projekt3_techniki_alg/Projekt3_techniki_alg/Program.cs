﻿using System;
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
            time = watch.ElapsedTicks;
        }



        static void Main(string[] args)
        {

            SortingAndBoxMethods sortingAndBox = new SortingAndBoxMethods(resultList, metodaBazowa, metodaKubelkowa, iloscPunktow);
            sortingAndBox.Calculate();

            Console.WriteLine("Metoda bazowa : Metoda kublekowa");
            for (int i = 0; i < iloscPunktow.Count(); i++)
            {
                Console.WriteLine(iloscPunktow[i] + " -> " + metodaBazowa[i] + " : " + metodaKubelkowa[i]);
            }

            ChartForm chr = new ChartForm();

            chr.AddBasicMetodChart(iloscPunktow, metodaBazowa);
            chr.AddBoxMetodChart(iloscPunktow, metodaKubelkowa);
            chr.RefreshChart();

            chr.ShowDialog();


            // -------------------------------------------------------------------------------------------Jarvis i graham

            int numberOfPoints = 10;
            Dictionary<int, long> grahamDic = new Dictionary<int, long>(); 
            for (int i = 0; i < 10; i++)
            {              
                watch.Reset();
                Start();
                Graham g = new Graham(numberOfPoints);
                g.RunGraham();
                Stop();
                SaveTime();
                g.CleanUp();
                Console.WriteLine("\nCzas działania algorytmu grahama dla " + numberOfPoints + " punktów: " + time);
                grahamDic.Add(numberOfPoints, time);
                numberOfPoints += 10;
            }

            numberOfPoints = 10;
            Dictionary<int, long> jarvisDic = new Dictionary<int, long>();
            for (int i =0; i< 10; i++)
            {

                watch.Reset();
                Start();
                Jarvis j = new Jarvis(numberOfPoints);
                j.RunJarvis();
                Stop();
                SaveTime();
                Console.WriteLine("\nCzas działania algorytmu Jarvisa dla " + numberOfPoints + " punktów: " + time);
                jarvisDic.Add(numberOfPoints, time);
                numberOfPoints += 10;
            }

            ChartForm chr2 = new ChartForm();
            chr2.RenameToJarvisAndGraham();
            chr2.AddBasicMetodChart(grahamDic.Keys.ToList(), grahamDic.Values.ToList());
            chr2.AddBoxMetodChart(jarvisDic.Keys.ToList(), jarvisDic.Values.ToList());
            chr2.RefreshChart();         
            chr2.ShowDialog();


            Console.ReadKey();
        }




       
    }
}
