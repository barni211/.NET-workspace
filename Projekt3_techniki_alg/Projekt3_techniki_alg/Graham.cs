using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt3_techniki_alg
{
    public class Graham
    {
        private List<Point> pointsAndDegrees = new List<Point>();
        private int firstApexIndex;
        private Dictionary<Point, double> degree = new Dictionary<Point, double>();
        private int numberOfAllPoints;
        private List<Point> shellApexes = new List<Point>();

        public Graham(int numberOfAllPoints)
        {
            this.numberOfAllPoints = numberOfAllPoints;
        }

        public void CleanUp()
        {
            pointsAndDegrees.Clear();
            degree.Clear();
            shellApexes.Clear();
        }

        public List<Point> RunGraham()
        {
            PointLottery(numberOfAllPoints, 30, 30);
            firstApexIndex = FindFirstApex();
            SetLowestApexOnFirstPosition();
            SortPointAndDegrees();
            pointsAndDegrees.Add(pointsAndDegrees[0]);


            //List<Point> shellApexes = new List<Point>();
            shellApexes.Add(pointsAndDegrees[0]);
            shellApexes.Add(pointsAndDegrees[1]);
            shellApexes.Add(pointsAndDegrees[2]);

            for (int i = 3; i < pointsAndDegrees.Count(); ++i)
            {
                int size = shellApexes.Count();
                while (size > 1 && CalculateMatrixDeterminant(shellApexes[size - 2], shellApexes[size - 1], pointsAndDegrees[i]) < 0)
                {
                    Point itemToRemove = shellApexes[size - 1];
                    shellApexes.Remove(itemToRemove);
                    size = shellApexes.Count();
                }
                shellApexes.Add(pointsAndDegrees[i]);
            }

            //foreach (Point p in shellApexes)
            //{
            //    Console.WriteLine("[" + p.X + "," + p.Y + "]");
            //}

            return shellApexes;
        }


        private List<Point> PointLottery(int size, int firstParam, int secParam)
        {
            pointsAndDegrees.Clear();
            Random rand = new Random();
            int pointExists = 0;
            while(pointsAndDegrees.Count() < size)
            {
                pointExists = 0;
                int x = rand.Next(firstParam) - secParam;
                int y = rand.Next(firstParam) - secParam;
                foreach(Point p in pointsAndDegrees)
                {
                    if(p.X == x && p.Y == y)
                    {
                        pointExists = 1;
                        break;
                    }
                }
                if(pointExists == 0)
                {
                    pointsAndDegrees.Add(new Point(x, y));
                }
            }

            return pointsAndDegrees;
        }

        private int FindFirstApex()
        {
            int lowestX = pointsAndDegrees[0].X;
            int lowestY = pointsAndDegrees[0].Y;
            int indexToReturn = -1;
            for(int i = 0; i< pointsAndDegrees.Count(); i++)
            {
                if(pointsAndDegrees[i].Y < lowestY || pointsAndDegrees[i].Y == lowestY && pointsAndDegrees[i].X < lowestX)
                {
                    lowestX = pointsAndDegrees[i].X;
                    lowestY = pointsAndDegrees[i].Y;
                    indexToReturn = i;
                }
            }

            return indexToReturn;
        }

        private void SetLowestApexOnFirstPosition()
        {
            Point first = pointsAndDegrees[0];
            pointsAndDegrees.Remove(first);
            degree.Add(first, -1.0);
            pointsAndDegrees.Insert(0, first);
            firstApexIndex = 0;
        }

        private void SortPointAndDegrees()
        {
            pointsAndDegrees.OrderBy(p => p.X).ThenBy(p => p.Y);
        }

        private double CalculateMatrixDeterminant(Point p1, Point p2, Point p3)
        {
            return p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p1.X * p3.Y - p2.X * p1.Y;
        }

        private double calculateDistanceFromFirstApex(Point point)
        {
            Point firstApex = pointsAndDegrees[firstApexIndex];
            return Math.Sqrt(Math.Pow((point.X - firstApex.X), 2) + Math.Pow((point.Y - firstApex.Y), 2)); 
        }

        private void PrintPointsAndDegrees()
        {
            for(int i =0; i< pointsAndDegrees.Count(); i++)
            {
                Console.WriteLine("[" + pointsAndDegrees[i].X + "," + pointsAndDegrees[i].Y + "]" + " distance: " + calculateDistanceFromFirstApex(pointsAndDegrees[i]));
            }
        }

    }
}
