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
        public void AddCorritage(Point x, Point y, List<Figure> list)
        {
            Corritage corit = new Corritage(x, y);
            list.Add(corit);
        }

        public void AddRoom(Point x, int width, int length, List<Figure> list)
        {
            Room room = new Room(x, 30, 30);
            list.Add(room);
        }

        public Factory getInstance()
        {
            return this;
        }
    }
}
