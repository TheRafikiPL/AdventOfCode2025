using System;

namespace Day_5
{
    internal class Program
    {
        static bool IsIngredientsInRangesPart1(ulong ingredient, List<string> ranges)
        {
            foreach (var range in ranges) 
            {
                string[] tmp = range.Split('-');
                ulong a = Convert.ToUInt64(tmp[0]);
                ulong b = Convert.ToUInt64(tmp[1]);

                if (ingredient >= a && ingredient <= b)
                {
                    return true;
                }
            }
            return false;
        }
        static void Part1()
        {
            List<string> ranges = new List<string>();
            List<ulong> ingredients = new List<ulong>();
            string fileName = "day5.txt";
            StreamReader sr = new StreamReader(fileName);
            bool addIngredients = false;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if(String.IsNullOrEmpty(s))
                {
                    addIngredients = true;
                    continue;
                }
                if(addIngredients)
                {
                    ingredients.Add(Convert.ToUInt64(s));
                    continue;
                }
                ranges.Add(s);
            }
            sr.Close();

            int sum = 0;
            foreach(ulong ingredient in ingredients)
            {
                if(IsIngredientsInRangesPart1(ingredient, ranges))
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }
        static void SortRanges(ref List<string> ranges)
        {
            for (int i = 0; i < ranges.Count - 1; i++)
            {
                for (int j = i+1; j < ranges.Count; j++)
                {
                    ulong a1 = Convert.ToUInt64(ranges[i].Split('-')[0]);
                    ulong a2 = Convert.ToUInt64(ranges[j].Split('-')[0]);
                    if(a1 > a2)
                    {
                        string tmp = ranges[i];
                        ranges[i] = ranges[j];
                        ranges[j] = tmp;
                    }
                }
            }
        }
        static void Part2()
        {
            List<string> ranges = new List<string>();
            string fileName = "day5.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (String.IsNullOrEmpty(s))
                {
                    break;
                }

                ranges.Add(s);
            }
            sr.Close();
            SortRanges(ref ranges);
            for (int i = 0; i < ranges.Count; i++)
            {
                List<int> toDelete = new List<int>();
                string[] tmp1 = ranges[i].Split('-');
                ulong a1 = Convert.ToUInt64(tmp1[0]);
                ulong b1 = Convert.ToUInt64(tmp1[1]);
                for (int j = 0; j < ranges.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    string[] tmp2 = ranges[j].Split('-');
                    ulong a2 = Convert.ToUInt64(tmp2[0]);
                    ulong b2 = Convert.ToUInt64(tmp2[1]);
                    if (a2 >= a1 && a2 <= b1)
                    {
                        if (b2 >= a1 && b2 <= b1)
                        {
                            toDelete.Add(j);
                            continue;
                        }
                        b1 = b2;
                        toDelete.Add(j);
                        continue;
                    }
                    if (b2 >= a1 && b2 <= b1)
                    {
                        a1 = a2;
                        toDelete.Add(j);
                    }
                }
                ranges[i] = $"{a1}-{b1}";
                toDelete.Sort();
                toDelete.Reverse();
                foreach (int index in toDelete)
                {
                    ranges.RemoveAt(index);
                }
            }
            ulong sum = 0;
            foreach (string s in ranges)
            {
                string[] tmp = s.Split('-');
                ulong a = Convert.ToUInt64(tmp[0]);
                ulong b = Convert.ToUInt64(tmp[1]);

                sum += b - a + 1;
            }
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
