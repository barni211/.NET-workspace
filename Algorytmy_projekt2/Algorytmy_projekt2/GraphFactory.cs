using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_projekt2
{
    public class GraphFactory
    {

        public static List<Child> CreateGraph()
        {
            List<Child> listaSasiedstwa = new List<Child>();

            Child zero = new Child(0);
            Child one = new Child(1);
            Child two = new Child(2);
            Child three = new Child(3);
            Child four = new Child(4);
            Child five = new Child(5);
            Child six = new Child(6);
            Child seven = new Child(7);
            Child eight = new Child(8);
            listaSasiedstwa.Add(zero);
            listaSasiedstwa.Add(one);
            listaSasiedstwa.Add(two);
            listaSasiedstwa.Add(three);
            listaSasiedstwa.Add(four);
            listaSasiedstwa.Add(five);
            listaSasiedstwa.Add(six);
            listaSasiedstwa.Add(seven);
            listaSasiedstwa.Add(eight);

            listaSasiedstwa.ElementAt(0).AddAdj(one);
            //listaSasiedstwa.ElementAt(1).AddAdj(one);
            listaSasiedstwa.ElementAt(1).AddAdj(eight);
            listaSasiedstwa.ElementAt(1).AddAdj(four);
            listaSasiedstwa.ElementAt(1).AddAdj(three);
            listaSasiedstwa.ElementAt(2).AddAdj(zero);
            listaSasiedstwa.ElementAt(3).AddAdj(seven);
            listaSasiedstwa.ElementAt(4).AddAdj(five);
            listaSasiedstwa.ElementAt(4).AddAdj(six);
            listaSasiedstwa.ElementAt(4).AddAdj(two);
            listaSasiedstwa.ElementAt(5).AddAdj(six);
            listaSasiedstwa.ElementAt(6).AddAdj(two);
            listaSasiedstwa.ElementAt(7).AddAdj(five);

            return listaSasiedstwa;
        }

        public static List<Child> CreateGraphFromFile(string filePath)
        {
            if (filePath.Equals(""))
            {
                filePath = @"E:\GrafWalaszek.txt";
            }
            
            List<Child> wierzcholki = CreateObjects(filePath);
           
            string line;
            string[] textObject;
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            int counter = 0;
            while ((line = file.ReadLine()) != null)
            {   

                textObject = line.Split(' ');
                if (textObject.Count() > 1)
                {
                    for (int i = 1; i < textObject.Count(); i++)
                    {
                        Child temp = FindV(int.Parse(textObject[i]), wierzcholki);
                        wierzcholki[counter].AddAdj(temp);
                    }
                }
                counter++;

            }
            file.Close();

            return wierzcholki;
        }

        private static List<Child> CreateObjects(string filePath)
        {
            List<Child> wierzcholki = new List<Child>();
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            string line;
            string[] textObject;
            while ((line = file.ReadLine()) != null)
            {

                textObject = line.Split(' ');
                Child temp = new Child(int.Parse(textObject[0]));
                wierzcholki.Add(temp);
            }

            return wierzcholki;
        }

        public static List<Child> CreateGraphWithFriendlyKids(string filePath)
        {
            if (filePath.Equals(""))
            {
                filePath = @"E:\GrafWalaszek.txt";
            }

            List<Child> wierzcholki = CreateObjects(filePath);


            //dodaje wierzchołki każdy z każdym
            foreach(Child v in wierzcholki)
            {
                foreach(Child v2 in wierzcholki)
                {
                    if(v.Equals(v2)==false)
                    {
                        v.AddAdj(v2);
                    }
                }
            }

            string line;
            string[] textObject;
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            int counter = 0;
            while ((line = file.ReadLine()) != null)
            {

                textObject = line.Split(' ');
                if (textObject.Count() > 1)
                {
                    for (int i = 1; i < textObject.Count(); i++)
                    {
                        Child temp = FindV(int.Parse(textObject[i]), wierzcholki);
                        wierzcholki[counter].RemoveAdj(temp);
                    }
                }
                counter++;

            }
            file.Close();

            return wierzcholki;
        }

        private static Child FindV(int number, List<Child> v)
        {
            foreach(Child wierzcholek in v)
            {
                if (wierzcholek.name == number)
                {
                    return wierzcholek;
                }
            }
            return null;
        }
    }
    
}
