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
        List<Child> listaSasiedstwa = GraphFactory.CreateGraph();
        List<Child> sccQueue = new List<Child>();
        List<Child> visitedN = new List<Child>();
        List<Child> lowB = new List<Child>();

        Stack<Child> stack = new Stack<Child>();
        static void Main(string[] args)
        {
          
        }

        void DFSscc(Child v)
        {
            v.number++;
            visitedN.Add(v);
            lowB.Add(v);
            stack.Push(v);
            v.Visit();
            foreach(Child adj in v.GetAdj())
            {
                if(adj.IsVisited()==false)
                {
                    DFSscc(adj);
                }
                else if(stack.is)
            }
        }
    }
}
