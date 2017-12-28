using Labirynt.Model.Classes.Objects;
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

        public void AddCorritage(string[] textObject, List<Figure> list)
        {
            //YellowCorritage corrit = new YellowCorritage(x, y);
            Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
            Point y = new Point(Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
            YellowCorritage  corrit = new YellowCorritage(x, y);
            list.Add(corrit);
        }

        public void AddKey(string[] textObject, List<Figure> list)
        {
            Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
            Key key = new Key(x);
            list.Add(key);
        }

        public void AddRoom(string[] textObject, List<Figure> list )
        {
            //RedRoom room = new RedRoom(x, 30, 30);
            if (textObject[0].Equals("Room"))
            {
                Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
                RedRoom room = new RedRoom(x, Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
                list.Add(room);
            }
            else if (textObject[0].Equals("MagicRoom"))
            {
                Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
                MagicRoom room = new MagicRoom(x, Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
                list.Add(room);
            }
        }

        public Factory getInstance()
        {
            return this;
        }
    }
}
