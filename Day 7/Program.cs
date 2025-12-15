using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Day_7
{
    public class Point
    {
        public int x;
        public Point? left, right;
        public bool hadLight;
        public ulong weight;
        public Point(int x)
        {
            this.x = x;
            left = null;
            right = null;
            hadLight = false;
            weight = 0;
        }
    }
    internal class Program
    {
        static void Part1()
        {
            List<string> list = new List<string>();
            string fileName = "day7.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            sr.Close();
            int splitCounter = 0;
            List<int> linePoints = new List<int>();
            linePoints.Add(list[0].IndexOf('S'));
            for (int i = 1; i < list.Count; i++) 
            { 
                List<int> toRemove = new List<int>();
                List<int> toAdd = new List<int>();
                int tmpCount = 0;
                tmpCount = linePoints.Count;
                for (int j = 0; j < tmpCount; j++)
                {
                    if (list[i][linePoints[j]] == '^')
                    {
                        //SPLIT
                        splitCounter++;
                        toRemove.Add(j);
                        if (!linePoints.Contains(linePoints[j] - 1) && !toAdd.Contains(linePoints[j] - 1))
                        {
                            toAdd.Add(linePoints[j] - 1);
                        }
                        if (!linePoints.Contains(linePoints[j] + 1) && !toAdd.Contains(linePoints[j] + 1))
                        {
                            toAdd.Add(linePoints[j] + 1);
                        }
                    }
                }
                toRemove.Reverse();
                foreach(int ind in toRemove)
                {
                    linePoints.RemoveAt(ind);
                }
                foreach (int ind in toAdd)
                {
                    linePoints.Add(ind);
                }
                StringBuilder tmp = new StringBuilder(list[i]);
                foreach (int ind in linePoints)
                {
                    tmp[ind] = '|';
                }
                list[i] = tmp.ToString();
            }
            Console.WriteLine(splitCounter);
        }

        static ulong CountYourBlessings(ref Point p)
        {
            if(p.right == null && p.left == null)
            {
                p.weight = 2;
                return p.weight;
            }
            if(p.right == null)
            {
                if(p.left.weight > 0)
                {
                    p.weight = 1 + p.left.weight;
                    return p.weight;
                }
                p.weight = 1 + CountYourBlessings(ref p.left);
                return p.weight; 
            }
            if (p.left == null)
            {
                if (p.right.weight > 0)
                {
                    p.weight = 1 + p.right.weight;
                    return p.weight;
                }
                p.weight = 1 + CountYourBlessings(ref p.right);
                return p.weight;
            }
            if (p.right.weight > 0 && p.left.weight < 1)
            {
                p.weight = p.right.weight + CountYourBlessings(ref p.left);
                return p.weight;
            }
            if (p.left.weight > 0 && p.right.weight < 1)
            {
                p.weight = p.left.weight + CountYourBlessings(ref p.right);
                return p.weight;
            }
            if(p.left.weight > 0 && p.right.weight > 0)
            {
                p.weight = p.right.weight + p.left.weight;
                return p.weight;
            }
            p.weight = CountYourBlessings(ref p.right) + CountYourBlessings(ref p.left);
            return p.weight;
        }
        static void Part2()
        {
            List<List<Point>> points = new List<List<Point>>();
            string fileName = "day7.txt";
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                List<Point> temp = new List<Point>();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '^')
                    {
                        temp.Add(new Point(j));
                    }
                }
                points.Add(temp);
                sr.ReadLine();
            }
            sr.Close();
            points[0][0].hadLight = true;
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = 0; j < points[i].Count;j++)
                {
                    if(!points[i][j].hadLight)
                    {
                        continue;
                    }
                    for (int k = i+1; k < points.Count; k++)
                    {
                        for (int m = 0; m < points[k].Count; m++)
                        {
                            if(points[i][j].left == null)
                            {
                                if (points[k][m].x == points[i][j].x - 1)
                                {
                                    points[i][j].left = points[k][m];
                                    points[k][m].hadLight = true;
                                }
                            }
                            if (points[i][j].right == null)
                            {
                                if (points[k][m].x == points[i][j].x + 1)
                                {
                                    points[i][j].right = points[k][m];
                                    points[k][m].hadLight = true;
                                }
                            }
                            if (points[i][j].right != null && points[i][j].left != null)
                            {
                                break;
                            }
                        }
                        if (points[i][j].right != null && points[i][j].left != null)
                        {
                            break;
                        }
                    }
                }
            }
            Point p = points[0][0];
            Console.WriteLine(CountYourBlessings(ref p));
        }
        static void Main(string[] args)
        {
            Part1();
            Console.WriteLine();
            Part2();
        }
    }
}
