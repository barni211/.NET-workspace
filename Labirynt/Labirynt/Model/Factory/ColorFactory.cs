using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class ColorFactory : Factory
    {

        public void AddCorritage(Point x, Point y, List<Figure> list)
        {
            YellowCorritage corrit = new YellowCorritage(x, y);
            list.Add(corrit);
        }

        public void AddRoom(Point x, int width, int length, List<Figure> list )
        {
            RedRoom room = new RedRoom(x, 30, 30);
            list.Add(room);      
        }

        public Factory getInstance()
        {
            return this;
        }
    }
}
