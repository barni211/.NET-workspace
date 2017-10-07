using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cwiczenie1_fabryka
{
    public class ListTable<T> : ITable<T>
    {
        private List<T> tableList = new List<T>();
        public void AddElement(T elem, int index)
        {
            tableList.Add(elem);
        }

        public void RemoveElement(int elem)
        {
            //tableList.Remove(elem);
        }

        public void ShowElements()
        {
            foreach(T elem in tableList)
            {
                Debug.Print(elem.ToString());
            }
        }

        public int ElementsCount()
        {
            return tableList.Count();
        }
    }
}
