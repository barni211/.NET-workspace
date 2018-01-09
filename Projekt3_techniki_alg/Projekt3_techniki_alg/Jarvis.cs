using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Projekt3_techniki_alg
{
    public class Jarvis
    {
        Vector2 v1 = new Vector2(30, 30);
        private List<Point> pointsAndDegrees;
        private int pointsNumber;

        public Jarvis(int pointsNumber)
        {
            pointsAndDegrees = new List<Point>();
            this.pointsNumber = pointsNumber;
        }

        private int FindFirstApex()
        {
            int lowestX = pointsAndDegrees[0].X;
            int lowestY = pointsAndDegrees[0].Y;
            int indexToReturn = -1;
            for (int i = 0; i < pointsAndDegrees.Count(); i++)
            {
                if (pointsAndDegrees[i].Y < lowestY || pointsAndDegrees[i].Y == lowestY && pointsAndDegrees[i].X < lowestX)
                {
                    lowestX = pointsAndDegrees[i].X;
                    lowestY = pointsAndDegrees[i].Y;
                    indexToReturn = i;
                }
            }

            return indexToReturn;
        }

        public List<Point> RunJarvis()
        {
            PointLottery(pointsNumber, 10, 10);
            int firstApex = FindFirstApex();
            Point p1 = pointsAndDegrees[firstApex];
            Point p0 = new Point(p1.X - 10, p1.Y);
            List<Point> shellList = new List<Point>();
            shellList.Add(p1);

            while(true)
            {
                int flag = 0;
                int[] shellVector = getVector(p1, p0);
                double biggestDegree = -999;
                int lowestIndex = 0;

                for(int i =0; i<= pointsAndDegrees.Count(); i++)
                {
                    if(i== pointsAndDegrees.Count())
                    {
                        flag = 1;
                        break;
                    }
                    int[] tmpVector = getVector(p1, pointsAndDegrees[i]);
                    if (CalculateVectorsDegrees(shellVector, tmpVector) > biggestDegree)
                    {
                        biggestDegree = CalculateVectorsDegrees(shellVector, tmpVector);
                        lowestIndex = i;
                    }              
                }
                shellList.Add(pointsAndDegrees[lowestIndex]);
                p0 = new Point(p1.X, p1.Y);
                p1 = pointsAndDegrees[lowestIndex];
                if(pointsAndDegrees[firstApex].Equals(p1) || flag == 1)
                {
                    break;
                }
            }
            return shellList;
        }

        private int[] getVector(Point p1, Point p2)
        {
            int[] tab = new int[2];
            tab[0] = p2.X - p1.X;
            tab[1] = p2.Y - p1.Y;
            return tab;
        }

        private double CalculateVectorsDegrees(int[] vector1, int[] vector2)
        {
            return (vector1[0] * vector2[0] + vector1[1] * vector2[1]) / (CalculateVectorLength(vector1) * CalculateVectorLength(vector2));
        }

        private double CalculateVectorLength(int[] vector)
        {
            return Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2));
        }

        private List<Point> PointLottery(int size, int firstParam, int secParam)
        {
            pointsAndDegrees.Clear();
            Random rand = new Random();
            int pointExists = 0;
            while (pointsAndDegrees.Count() < size)
            {
                pointExists = 0;
                int x = rand.Next(firstParam) - secParam;
                int y = rand.Next(firstParam) - secParam;
                foreach (Point p in pointsAndDegrees)
                {
                    if (p.X == x && p.Y == y)
                    {
                        pointExists = 1;
                        break;
                    }
                }
                if (pointExists == 0)
                {
                    pointsAndDegrees.Add(new Point(x, y));
                }
            }
            return pointsAndDegrees;
        }
    }

  



}
