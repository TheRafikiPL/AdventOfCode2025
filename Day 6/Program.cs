using System;

namespace Day_6
{
    internal class Program
    {
        static void Part1()
        {
            List<List<string>> list = new List<List<string>>();
            string fileName = "day6.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                List<string> ls = new List<string>();
                string tmp = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        if (!String.IsNullOrWhiteSpace(tmp))
                        {
                            ls.Add(tmp);
                        }
                        tmp = "";
                        continue;
                    }
                    tmp += s[i];
                }
                if (!String.IsNullOrWhiteSpace(tmp))
                {
                    ls.Add(tmp);
                }
                list.Add(ls);
            }
            sr.Close();
            ulong sum = 0;
            for(int i = 0; i < list[0].Count; i++)
            {
                ulong calc = 0;
                switch (list[list.Count - 1][i])
                {
                    case "*":
                        calc = Convert.ToUInt64(list[0][i]);
                        for (int j = 1; j < list.Count - 1; j++)
                        {
                            calc *= Convert.ToUInt64(list[j][i]);
                        }
                        break;
                    case "+":
                        for (int j = 0; j < list.Count - 1; j++)
                        {
                            calc += Convert.ToUInt64(list[j][i]);
                        }
                        break;
                }
                //Console.WriteLine(calc);
                sum += calc;
            }
            Console.WriteLine(sum);
        }
        static void Part2()
        {
            List<string> list = new List<string>();
            string fileName = "day6.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            sr.Close();

            ulong sum = 0;
            ulong calc = 0;
            List<ulong> arguments = new List<ulong>();
            for (int i = list[0].Length-1; i >= 0; i--)
            {
                string tmp = "";
                for (int j = 0; j < list.Count; j++)
                {
                    switch (list[j][i])
                    {
                        case '*':
                            arguments.Add(Convert.ToUInt64(tmp));
                            calc = 1;
                            foreach(ulong argument in arguments)
                            {
                                calc *= Convert.ToUInt64(argument);
                            }
                            //Console.WriteLine(calc);
                            sum += calc;
                            arguments = new List<ulong>();
                            tmp = "";
                            break;
                        case '+':
                            arguments.Add(Convert.ToUInt64(tmp));
                            calc = 0;
                            foreach (ulong argument in arguments)
                            {
                                calc += Convert.ToUInt64(argument);
                            }
                            //Console.WriteLine(calc); 
                            sum += calc;
                            arguments = new List<ulong>();
                            tmp = "";
                            break;
                        case ' ':
                            break;
                        default:
                            tmp += list[j][i];
                            break;
                    }
                }
                if(!String.IsNullOrEmpty(tmp))
                {
                    arguments.Add(Convert.ToUInt64(tmp));
                }
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
