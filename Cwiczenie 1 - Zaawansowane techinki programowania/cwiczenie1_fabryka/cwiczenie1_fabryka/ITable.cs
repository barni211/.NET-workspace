using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenie1_fabryka
{
    public interface ITable<T>
    {
        void AddElement(T elem, int index);
        void RemoveElement(int index);

        void ShowElements();
    }
}
