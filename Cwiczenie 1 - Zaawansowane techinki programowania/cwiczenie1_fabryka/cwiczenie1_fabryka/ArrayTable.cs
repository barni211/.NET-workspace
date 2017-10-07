using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cwiczenie1_fabryka
{
    public class ArrayTable<T> : ITable<T>, ICloneable
    {
        private T[] table;

        public ArrayTable(int size)
        {
            table = new T[size + 1];   
        }
        public void AddElement(T elem, int index)
        {
            table[index] = elem;
        }

        public object Clone()
        {
            return this;
        }

        public void RemoveElement(int index)
        {
            
        }

        public void ShowElements()
        {
            for(int i = 0; i<table.Count(); i++)
            {
                Debug.Print(table[i].ToString());
            }
        }
    }
}
