using Labirynt.Model.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class StandardFactory : Factory
    {
        public void AddCorritage(string[] textObject, List<Figure> list)
        {
            Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
            Point y = new Point(Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
            Corritage corrit = new Corritage(x, y);
            list.Add(corrit);
        }

        public void AddRoom(string[] textObject, List<Figure> list)
        {
            Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
            StandardRoom room = new StandardRoom(x, Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
            list.Add(room);
        }

        public void AddKey(string[] textObject, List<Figure> list)
        {
           //DO NOTHING
        }

        public Factory getInstance()
        {
            return this;
        }
    }
}
