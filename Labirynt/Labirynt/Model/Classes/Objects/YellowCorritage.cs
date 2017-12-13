using Labirynt.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public class YellowCorritage : Figure, CorritageFace
    {
        Point startPoint;
        Point endPoint;

        public YellowCorritage(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public void Draw(Pen p, Graphics g)
        {
            p.Color = Color.Yellow;
            g.DrawLine(p, startPoint, endPoint);
            p.Color = Color.Black;
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
