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
        void AddCorritage(string[] textObject , List<Figure> list);
        void AddRoom(string[] textObject , List<Figure> list);

        void AddKey(string[] textObject, List<Figure> list);
        Factory getInstance();
    }
}
