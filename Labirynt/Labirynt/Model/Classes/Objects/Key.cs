using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model.Classes.Objects
{
    public class Key : Figure
    {
        private Point location;

        public Key(Point x)
        {
            location = x;
        }

        public void Draw(Pen p, Graphics g)
        {
            
            g.DrawEllipse(p, location.X, location.Y, 3, 3);
        }

        public Point EndPoint()
        {
            return location;
        }

        public Point StartPoint()
        {
            return location;
        }
    }
}
