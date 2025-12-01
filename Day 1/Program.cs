using System.IO;

namespace Day_1
{
    internal class Program
    {
        //PART 1
        static void Left(ref int val, int sub)
        {
            val -= sub % 100;
            if (val < 0)
            {
                val = val + 100;
            }
        }
        static void Right(ref int val, int add)
        {
            val += add % 100;
            if (val > 99)
            {
                val = val - 100;
            }
        }

        //PART2
        static int Left2(ref int val, int sub)
        {
            bool isval0 = val == 0;
            val -= sub % 100;
            if (val < 0)
            {
                val = val + 100;
                if (!isval0)
                {
                    return sub / 100 + 1;
                }
            }
            if (val == 0)
            {
                return sub / 100 + 1;
            }
            return sub / 100;
        }
        static int Right2(ref int val, int add)
        {
            bool isval0 = val == 0;
            val += add % 100;
            if (val > 99)
            {
                val = val - 100;
                if (!isval0)
                {
                    return add / 100 + 1;
                }

            }
            if (val == 0)
            {
                return add / 100 + 1;
            }
            return add / 100;
        }

        static void Part1()
        {
            int count = 0;
            int val = 50;
            string fileName = "day1_1.txt";

            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string num = line.Substring(1);
                if (line[0] == 'L')
                {
                    Left(ref val, Convert.ToInt32(num));
                }
                else if (line[0] == 'R')
                {
                    Right(ref val, Convert.ToInt32(num));
                }
                if (val == 0)
                {
                    count++;
                }
                //Console.WriteLine(line + "; " + val);
            }
            Console.WriteLine(count);
        }
        
        static void Part2()
        {
            int count = 0;
            int val = 50;
            string fileName = "day1_2.txt";

            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string num = line.Substring(1);
                if (line[0] == 'L')
                {
                    count += Left2(ref val, Convert.ToInt32(num));
                }
                else if (line[0] == 'R')
                {
                    count += Right2(ref val, Convert.ToInt32(num));
                }
                //Console.WriteLine(line + "; " + val+"; "+count);
            }
            Console.WriteLine(count);
        }
        static void Main(string[] args)
        {
            Part1();

            Part2();
        }
    }
}
