using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model
{
    public interface Factory
    {
        void AddCorritage(Point x, Point y, List<Figure> list);
        void AddRoom(Point x, int length,int width, List<Figure> list);

        Factory getInstance();
    }
}
