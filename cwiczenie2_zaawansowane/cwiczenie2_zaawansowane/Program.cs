using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenie2_zaawansowane
{
    //Opakowanie w obiket (c++) przerwywa łańcuch zależności bycia zasobem
    //W językach java i c# bycie zasobem jest relacją przechodnią. Tj. jeżeli obiekt zawiera inny obiekt
    //będący zasobem, to sam staje się zasobem.

    //strong reachable - silna referencja, przynajmniej jedna silna referencja do obiektu
    //weak reachable - słaba referencja <- istnieją tylko słabe refenncje do obiektu
    // weak_reference<Widget> WR = new weak_reference(W);
    //Widget w1 = WR.get();
    //jeżeli W zostało usunięte to powyższe wyrażenie zwróci null.
    class Program
    {
        static void Main(string[] args)
        {
           
            

            //WeakReference reference = new WeakReference(new MyOwnObject(11));

            ////var myOwnObject = (MyOwnObject)reference.Target;

            //bool value = reference.IsAlive;

            ////if (myOwnObject == null)
            ////    Console.WriteLine("Obiekt został usuniety przez GC");
            ////else
            //    Console.WriteLine("Obiekt wciąż istnieje:{0}", myOwnObject.number);


            //String txt = "txt";
            MyOwnObject objectReference;
            for (int i = 0; i < 1000000; i++)
            {
                objectReference = new MyOwnObject(i);
            }

            GC.Collect();

            
            

           
            //GC.SuppressFinalize(myOwnObject);

            //if (myOwnObject == null)
            //    Console.WriteLine("Obiekt został usuniety przez GC");
            //else
            //    Console.WriteLine("Obiekt wciąż istnieje:{0}", myOwnObject.number);

            Console.ReadKey();
        }
    }
}
