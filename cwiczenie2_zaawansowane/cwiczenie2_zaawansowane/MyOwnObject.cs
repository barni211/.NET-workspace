using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenie2_zaawansowane
{
    public class MyOwnObject : IDisposable
    {
        public int number { get; set; }
        public static List<MyOwnObject> list;

        protected virtual void Finalize()
        {
            list.Add(this);
            Console.Write("Object " + number + " destroyed");
        }

        public void destroy()
        {
            
        }

        public MyOwnObject(int number)
        {
            this.number = number;
        }

        public MyOwnObject()
        {

        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Speak()
        {
            Console.Write("Obiekt numer " + number + " zyje!");
        }

        // ~MyOwnObject()
        //{
        //    list.Add(this);
        //    Console.Write("Object " + number + " destroyed");
        //}
    }
}
