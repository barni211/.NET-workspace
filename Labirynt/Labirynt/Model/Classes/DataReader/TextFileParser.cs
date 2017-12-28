using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirynt.Model.Classes.DataReader
{
    public class TextFileParser
    {
        private Dictionary<int, string[]> fileInList;

        public TextFileParser()
        {
            fileInList = new Dictionary<int, string[]>();
        }


        public Dictionary<int, string[]> CreateStringDictionary(string filePath)
        {
            int counter = 1;
            fileInList = new Dictionary<int, string[]>();
            if (filePath.Equals(""))
            {
                filePath = @"E:\StandardFile.txt";
            }
            bool firstLine = true;
            string line;
            string[] textObject;
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (firstLine == true)
                {
                    string[] board = new string[2];
                    board[0] = line;
                    fileInList.Add(0, board);
                    firstLine = false;
                    continue;
                }
                textObject = line.Split(' ');
                fileInList.Add(counter, textObject);
                firstLine = false;
                counter++;

            }
            file.Close();

            return fileInList;
        }
    }
}
