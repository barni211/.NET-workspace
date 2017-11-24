using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_Lab2
{
    //0 11 12 2
    //1 0 12
    //2 1 4
    //3
    //4 3 6
    //5 4
    //6 5 7
    //7
    //8 9
    //9 11
    //10 8
    //11 10
    //12 1

    //odwrotny
    //0 1
    // 1 2
    // 2 0
    // 3 4
    // 4 2 5
    // 5 6
    // 6 7
    // 7 6
    // 8 10
    // 9 8
    // 10 11
    //11 0 9 12
    //12 0 1
    class Program
    {
        static Dictionary<int, int[]> graph;
        static List<int> stack;
        static bool[] visited = new bool[12];
        static void Main(string[] args)
        {
            stack = new List<int>();
           
            //List<int[]> graph2 = new List<int[]>();
            //graph2.Add(new int[] { 0, 11, 12, 2 });
            //graph2.Add(new int[] { 1, 0, 12 });
            //graph2.Add(new int[] { 2, 1, 4 });
            graph = new Dictionary<int, int[]>();
            graph.Add(0, new int[] { 11, 12, 2 });
            graph.Add(1, new int[] { 0, 12 });
            graph.Add(2, new int[] { 1, 4 });
            graph.Add(3, new int[] { });
            graph.Add(4, new int[] { 3, 6 });
            graph.Add(5, new int[] { 4 });
            graph.Add(6, new int[] { 5, 7 });
            graph.Add(7, new int[] { });
            graph.Add(8, new int[] { 9 });
            graph.Add(9, new int[] { 11 });
            graph.Add(10, new int[] { 8 });
            graph.Add(11, new int[] { 10 });
            graph.Add(12, new int[] { 1 });

            reverseGraph(0);

            foreach(int elem in stack)
            {
                Console.Write(elem + "\n");
            }

            foreach (int elem in graph.Keys)
            {
                
                Console.Write(graph[elem] + "\n");
            }

            Console.ReadKey();
        }

        static void reverseGraph(int v)
        {
            if(visited[v]==true)
            {
                foreach(int adj in graph[v])
                {
                    if(visited[adj]==false)
                    {
                        //TODO: wywołaj DFS
                    }
                    else
                    {
                        stack.Add(adj);
                    }
                }
            }
        }

        static int DFS(int v)
        {
            
        }
    }

    
}
