using Labirynt.Model.Classes.DataReader;
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
        private Dictionary<string, Figure> elementTypeList;
        private Dictionary<MazeType, Factory> mazeList;
        private Dictionary<string, MazeType> mazeTypeConverter; //mapa mazeTypeConverter powstała w celu uniknięcia switcha przy wyborze typu labiryntu
        private List<Figure> figureList;                        //switch został w kodzie - do wyjaśnienia które rozwiązanie byłoby lepsze.
        private MazeType maze;
        private Factory factoryObject;
        public MazeFactory()
        {
            mazeList = new Dictionary<MazeType, Factory>();
            mazeTypeConverter = new Dictionary<string, MazeType>();
            elementTypeList = new Dictionary<string, Figure>();
            mazeList.Add(MazeType.STANDARD, new StandardFactory());
            mazeList.Add(MazeType.MAGIC, new ColorFactory());
            mazeTypeConverter.Add("STANDARD", MazeType.STANDARD);
            mazeTypeConverter.Add("MAGIC", MazeType.MAGIC);
           
        }

        public List<Figure> CreateMazeFromTextFile(string filePath)
        {
            if(filePath.Equals(""))
            {
                filePath = @"E:\StandardFile.txt";
            }
            figureList = new List<Figure>();
            TextFileParser parser = new TextFileParser();
            bool isFirstLine = true;

            Dictionary<int, string[]> dict = parser.CreateStringDictionary(filePath);

            for (int i = 0; i< dict.Count; i++)
            {
                if(isFirstLine==true)
                {
                    maze = mazeTypeConverter[dict[0].First()];
                    factoryObject = mazeList[maze].getInstance();
                    isFirstLine = false;
                    continue;
                }
                else
                {
                    string[] param = dict[i];
                    if(param[0].Equals("Room"))
                    {
                        factoryObject.AddRoom(param, figureList);
                    }
                    else if(param[0].Equals("Corritage"))
                    {
                        factoryObject.AddCorritage(param, figureList);
                    }
                }
            }
            return figureList;
        }
    }
}
