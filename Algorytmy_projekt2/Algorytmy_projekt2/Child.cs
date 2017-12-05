using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_projekt2
{
    public class Child
    {
        private List<Child> adjusments;
        private bool visited = false;
        public int name { get; set; }
        public int number { get; set; }

        public Child(int name)
        {
            adjusments = new List<Child>();
            this.name = name;
            this.number = 0;
        }

        public bool IsVisited()
        {
            return this.visited;
        }

        public void Visit()
        {
            this.visited = true;
        }

        public List<Child> GetAdj()
        {
            return this.adjusments;
        }

        public void AddAdj(Child c)
        {
            adjusments.Add(c);
        }
    }
}
