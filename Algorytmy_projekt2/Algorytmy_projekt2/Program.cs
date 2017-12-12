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
        static Dictionary<int, Child[]> listaCykli = new Dictionary<int, Child[]>();
      //  static int rowsCounter = 0;

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

        static void SetVisitedToFalse()
        {
            foreach(Child elem in listaSasiedstwa)
            {
                elem.SetVisitToFalse();
            }
        }

        static bool FindCycles(Child start, Child v)
        {
            v.Visit();
            stack.Push(v);
            foreach(Child adj in v.GetAdj())
            {
                if(adj.name == start.name)
                {
                    return true;
                }
                else if(adj.IsVisited()==false && FindCycles(start,adj))
                {
                    return true;
                }
            }
            stack.Pop();
            return false;
        }

        static int CheckCycles()
        {
            int cyclesCounter = 1;
            List<Child> tmpChildList = new List<Child>();
            Child tmpChild;
            foreach (Child v in listaSasiedstwa)
            {
                SetVisitedToFalse();
                if(FindCycles(v,v)==false)
                {
                    continue;
                }

                stack.Push(v);
                while(stack.Count > 0)
                {
                    tmpChild = stack.Pop();
                    tmpChildList.Add(tmpChild);
                }
                listaCykli.Add(cyclesCounter, tmpChildList.ToArray());
                tmpChildList.Clear();

                cyclesCounter++;
            }
            return cyclesCounter;
        }

        static int HowManyRowsIsNecessary()
        {
            bool allKidsAreInRows = false;
            int rowsCounter = 0;
            SetVisitedToFalse();
            List<Child> tmpChildList = new List<Child>();
            while(!allKidsAreInRows)
            {
                for(int i =0; i<listaSasiedstwa.Count(); ++i)
                {
                    if(listaSasiedstwa[i].IsVisited()==false)
                    {
                        if (tmpChildList.Count() == 0)
                        {
                            tmpChildList.Add(listaSasiedstwa[i]);
                            listaSasiedstwa[i].Visit();
                        }
                        else
                        {
                            ChildRowsVerification(listaSasiedstwa[i], tmpChildList);
                        }
                    }

                }
                listaSkladowych.Add(tmpChildList.ToArray());
                rowsCounter++;
                tmpChildList.Clear();
                allKidsAreInRows = AreAllChildsVisited();
            }
            return rowsCounter;
        }

        static bool AreAllChildsVisited()
        {
            foreach(Child item in listaSasiedstwa)
            {
                if(item.IsVisited()==false)
                {
                    return false;
                }
            }
            return true;
        }

        static void ChildRowsVerification(Child actKid, List<Child> tmpChildList)
        {
            if(ChildIsGoodToAddAtTheFrontOf(actKid, tmpChildList))
            {
                //tmpChildList.Add(actKid);
                tmpChildList.Insert(0, actKid);
                actKid.Visit();
            }
            else if(ChildIsGoodToAddBehind(actKid, tmpChildList))
            {
                tmpChildList.Add(actKid);
                actKid.Visit();
            }
            else if(ChildIsGoodToAddInside(actKid, tmpChildList))
            {
                actKid.Visit();
            }
        }

        static bool ChildIsGoodToAddAtTheFrontOf(Child actKid, List<Child> tmpChildList)
        {
            foreach(Child item in tmpChildList)
            {
                List<Child> adj = item.GetAdj();
                foreach(Child adjItem in adj)
                {
                    if(actKid.Equals(adjItem))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool ChildIsGoodToAddBehind(Child actKid, List<Child> tmpChildList)
        {
            List<Child> adj = actKid.GetAdj();
            for(int i = tmpChildList.Count() - 1; i>= 0; --i)
            {
                foreach(Child item in adj)
                {
                    if(tmpChildList[i].Equals(item))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool ChildIsGoodToAddInside(Child actKid, List<Child> ChildList)
        {
            List<Child> adj = actKid.GetAdj();
            List<Child> tmpChildList = new List<Child>(ChildList);
            int size = tmpChildList.Count() - 1;
            int index = -1;
            for( int i = 0; i< size;i++)
            {
                Child actualKid = ChildList.ElementAt(i);
                if(ChildIsGoodToAddAtTheFrontOf(actKid, tmpChildList)==false)
                {
                    tmpChildList.RemoveAt(i);
                    size--;
                    i--;
                    continue;
                }
                else
                {
                    index = i;
                    //Child elem = ChildList.ElementAt(index);
                    int flag = 1;
                    for(int j = 0; i< index; j++)
                    {
                        if(DoTheyLikeEachOther(ChildList.ElementAt(i),actKid)==false)
                        {
                            flag = 0;
                        }
                    }
                    if(flag==1)
                    { 
                        ChildList.Insert(index, actKid);
                        return true;
                    }
                }
            }


            return false;
        }

        public static bool DoTheyLikeEachOther(Child actKid, Child secKid)
        {
            foreach(Child item in actKid.GetAdj())
            {
                if(item.Equals(secKid))
                {
                    return false;
                }
            }
            return true;
        }


        static void Main(string[] args)
        {
            string filePath = @"E:\Somsiad3.txt";
            listaSasiedstwa = GraphFactory.CreateGraphFromFile(filePath);
            //listaSasiedstwa = GraphFactory.CreateGraph();
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

            Console.Write("Grupy nielubienia \n");
            for (int j = listaSkladowych.Count() - 1; j >= 0; j--)
            {
                Child[] item = listaSkladowych[j];
                for (int i = item.Count() - 1; i >= 0; i--)
                {
                    Console.Write(item[i].name + " -> ");
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

            int value = CheckCycles();

            if (value > 0)
            {
                Console.Write("\nDzieci nie da się ustawić w rząd - w grafie występuje " + (value - 1) + " cykli:\n");
                foreach (int key in listaCykli.Keys)
                {
                    Console.Write(key + " : ");
                    for (int i = listaCykli[key].Count() - 1; i >= 0; i--)
                    {
                        Console.Write(listaCykli[key].ElementAt(i).name + " -> ");
                    }
                    Console.WriteLine();

                }
            }
            else
            {
                Console.Write("\nDzieci z powodzeniem można ustawić w rząd - w grafie nie występują cykle.");
            }


            Console.WriteLine("\nProblem ustawienia dzieci w rzędy");
            //v.number = counter++;
            for(int i = 0; i<lowB.Count(); i++)
            {
                lowB[i] = -1;
                sccQueue[i] = 1;
            }
           // sccQueue[v.number] = v.number;
            listaSasiedstwa.Clear();
            listaSasiedstwa = GraphFactory.CreateGraphFromFile(filePath);
            listaSkladowych.Clear();

            counter = HowManyRowsIsNecessary();

            Console.WriteLine("\nDo ustawienia dzieci potrzeba " + counter + " rzedow");

            for (int j = listaSkladowych.Count() - 1; j >= 0; j--)
            {
                Child[] item = listaSkladowych[j];
                for (int i = item.Count() - 1; i >= 0; i--)
                {
                    Console.Write(item[i].name + " -> ");
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }

  
}
