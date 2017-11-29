using Labirynt.Model.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model.Classes
{
    public class MazeFactory
    {
        private Dictionary<MazeType, Factory> mazeList;
        private List<Figure> figureList;
        private MazeType maze;
        private Factory factoryObject;
        public MazeFactory()
        {
            mazeList = new Dictionary<MazeType, Factory>();
            mazeList.Add(MazeType.STANDARD, new StandardFactory());
            mazeList.Add(MazeType.MAGIC, new ColorFactory());
            figureList = new List<Figure>();
        }

        public List<Figure> CreateMaze(string filePath)
        {
            if(filePath.Equals(""))
            {
                filePath = @"E:\StandardFile.txt";
            }
            bool firstLine = true;
            string line;
            string[] textObject;
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            while ((line = file.ReadLine()) != null)
            {
                if(firstLine==true)
                {
                    switch(line)
                    {
                        case "MAGIC":
                            maze = MazeType.MAGIC;
                            break;
                        case "STANDARD":
                            maze = MazeType.STANDARD;
                            break;
                    }
                    factoryObject = mazeList[maze].getInstance();
                    firstLine = false;
                    continue;
                }
                textObject = line.Split(' ');
                if(textObject[0].Equals("Corritage"))
                {
                    Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
                    Point y = new Point(Int32.Parse(textObject[3]), Int32.Parse(textObject[4]));
                    factoryObject.AddCorritage(x, y, figureList);
                }
                else if(textObject[0].Equals("Room"))
                {
                    Point x = new Point(Int32.Parse(textObject[1]), Int32.Parse(textObject[2]));
                    factoryObject.AddRoom(x, Int32.Parse(textObject[3]), Int32.Parse(textObject[4]), figureList);
                }
                firstLine = false;

            }
            file.Close();

            return figureList;
        }
    }
}
