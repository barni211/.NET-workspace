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
        private List<Figure> figureList;

        public List<Figure> createObjects()
        {
            figureList = new List<Figure>();
            Point x = new Point(100, 300);
            Point y = new Point(300, 300);
            YellowCorritage coritOne = new YellowCorritage(x, y);

            Point x1 = new Point(300, 300);
            Point y1 = new Point(300, 250);
            YellowCorritage coritTwo = new YellowCorritage(x1, y1);

            Point x2 = new Point(300, 250);
            Point y2 = new Point(350, 250);
            YellowCorritage coritThree = new YellowCorritage(x2, y2);

            Point x3 = new Point(350, 250);
            Point y3 = new Point(350, 100);
            YellowCorritage coritFour = new YellowCorritage(x3, y3);

            Point x4 = new Point(350, 100);
            Point y4 = new Point(100, 100);
            YellowCorritage coritFive = new YellowCorritage(x4, y4);

            Point x5 = new Point(100, 100);
            Point y5 = new Point(100, 150);
            YellowCorritage coritSix = new YellowCorritage(x5, y5);

            Point x6 = new Point(100, 150);
            Point y6 = new Point(300, 150);
            YellowCorritage coritSeven = new YellowCorritage(x6, y6);

            Point x7 = new Point(170, 100);
            Point y7 = new Point(170, 50);
            YellowCorritage coritEight = new YellowCorritage(x7, y7);

            Point x8 = new Point(170, 50);
            Point y8 = new Point(170, 20);
            YellowCorritage coritNine = new YellowCorritage(x8, y8);

            Point x9 = new Point(170, 20);
            Point y9 = new Point(40, 20);
            YellowCorritage coritTen = new YellowCorritage(x9, y9);

            Point x10 = new Point(40, 20);
            Point y10 = new Point(40, 300);
            YellowCorritage coritEleven = new YellowCorritage(x10, y10);

            Point x11 = new Point(40, 300);
            Point y11 = new Point(70, 300);
            YellowCorritage coritTwelve = new YellowCorritage(x11, y11);




            RedRoom firstRoom = new RedRoom(y6, 30, 30);
            RedRoom secondRoom = new RedRoom(y7, 70, 30);

            figureList.Add(coritOne);
            figureList.Add(coritTwo);
            figureList.Add(coritThree);
            figureList.Add(coritFour);
            figureList.Add(coritFive);
            figureList.Add(coritSix);
            figureList.Add(coritSeven);
            figureList.Add(coritEight);
            figureList.Add(coritNine);
            figureList.Add(coritTen);
            figureList.Add(coritEleven);
            figureList.Add(coritTwelve);
            figureList.Add(firstRoom);
            figureList.Add(secondRoom);

            return figureList;
        }
    }
}
