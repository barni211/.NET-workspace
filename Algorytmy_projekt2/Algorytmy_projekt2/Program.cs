using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//jeżeli jest cykl, to nie można ustawić dzieciaków za sobą
//silnie spójne składowe -> algorytm kosaraju
//znajdź cykle w grafie, part a)
//
//0 1
//1 8 4 3
//2 0
//3 7
//4 5 6 2
//5 6
//6 2
//7 5
//8
namespace Algorytmy_projekt2
{
    public class Program
    {
        static List<Child> listaSasiedstwa;
        //static List<Child> listaSasiedstwa = GraphFactory.CreateGraph();
        static int[] sccQueue = new int[30]; //VN
        //static List<int> lowB = new List<int>(); //VLOW
        static int[] lowB = new int[30];
        static int counter = 0;
        static Stack<Child> stack = new Stack<Child>();
        static List<Child> listaWierzcholkow = new List<Child>();
        static List<Child[]> listaSkladowych = new List<Child[]>();
        static Child[] theBiggest = new Child[30];
       

        static void DFSscc(Child v)
        {
            v.number=counter++;
            lowB[v.number] = v.number;
            sccQueue[v.number] = v.number;
            v.Visit();
            stack.Push(v);
            foreach (Child adj in v.GetAdj())
            {
                if (adj != null)
                { 
                    if (adj.IsVisited() == false)
                    {
                        DFSscc(adj);
                        lowB[v.number] = Math.Min(lowB[adj.number], lowB[v.number]);
                        //continue;
                    }
                    else if (stack.Contains(adj))
                    {
                        lowB[v.number] = Math.Min(lowB[adj.number], lowB[v.number]);//MinimumValue(adj, v).number;
                        //continue;
                    }
                }
            }

            
            if (lowB[v.number] == sccQueue[v.number])
            {
                Child temp;
                do
                {
                    temp = stack.Pop();
                    listaWierzcholkow.Add(temp);
                }while (temp != v && stack.Count > 0);

                listaSkladowych.Add(listaWierzcholkow.ToArray());
                listaWierzcholkow.Clear();
            }
        }

        static Child MinimumValue(Child one, Child two)
        {
            if (one.number < two.number)
                return one;
            else
                return two;
        }

        static void WypiszGraf()
        {
            foreach(Child elem in listaSasiedstwa)
            {
                Console.Write(elem.name + " ");
                foreach(Child adj in elem.GetAdj())
                {
                    if (adj != null)
                    {
                        Console.Write(adj.name + " ");
                    }
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
           // listaSasiedstwa = GraphFactory.CreateGraphFromFile(@"E:\GrafWalaszek.txt");
            listaSasiedstwa = GraphFactory.CreateGraph();
            Console.WriteLine("Graf podany na wejściu");
            WypiszGraf();

            foreach( Child item in listaSasiedstwa)
            {
                if (item.IsVisited() == false)
                {
                    DFSscc(item);
                }
            }

            counter = 0;

            //Console.Write("Grupy nielubienia \n");
            //foreach(Child[] item in listaSkladowych)
            //{
            //    //Console.Write(item.)
            //    foreach(Child v in item.ToArray())
            //    {
            //        Console.Write(v.name + " -> ");
            //    }
            //    Console.Write("\n");
            //}

            Console.Write("Grupy nielubienia \n");
            for (int j = listaSkladowych.Count() - 1; j >= 0; j--)
            {
                Child[] item = listaSkladowych[j];
                //Console.Write(item.)
                //foreach(Child v in item.ToArray())
                for (int i = item.Count() - 1; i >= 0; --i)
                {
                    Console.Write(item[i].name + " -> ");
                    //Console.Write(v.name + " -> ");
                }
                Console.Write("\n");
            }


            int max = 0;
            foreach(Child[] item in listaSkladowych)
            {
                int size = item.Count();
                if(size>max)
                {
                    max = size;
                    theBiggest = item;
                }
            }

            Console.WriteLine("Największa grupa nielubienia: ");
            for (int i =theBiggest.Count() - 1 ;i >= 0 ; i--)
            {
                Console.Write(theBiggest[i].name + " -> ");
            }


            Console.ReadKey();
        }
    }

  
}
