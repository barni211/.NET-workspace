using Labirynt.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class Corritage : Figure, CorritageFace
    {
        Point startPoint;
        Point endPoint;

        public Corritage(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public void Draw(Pen p, Graphics g)
        {
            g.DrawLine(p, startPoint, endPoint);
        }

        public Point StartPoint()
        {
            return this.startPoint;
        }

        public Point EndPoint()
        {
            return this.endPoint;
        }
    }
}
