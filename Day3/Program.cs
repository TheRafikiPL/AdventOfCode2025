namespace Day_3
{
    internal class Program
    {
        static int CheckDigitsPart1(string s)
        {
            int max = 0;
            for (int i = 0; i < s.Length-1; i++) 
            { 
                for(int j = i+1; j < s.Length; j++)
                {
                    int tmp = Convert.ToInt32($"{s[i]}{s[j]}");
                    if (max < tmp)
                    {
                        max = tmp;
                    }
                }
            }
            //Console.WriteLine(max);
            return max;
        }
        static void Part1()
        {
            string fileName = "day3.txt";
            StreamReader sr = new StreamReader(fileName);
            int sum = 0;
            while (!sr.EndOfStream)
            {
                sum += CheckDigitsPart1(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine(sum);
        }
        static ulong CheckDigitsPart2(string s)
        {
            string tmp = "";
            int index = 0;
            for(int i=11; i >= 0; i--)
            {
                index = GetNumberFromString(s,index,i);
                tmp += Convert.ToString(s[index]);
                index++;
            }
            //Console.WriteLine(tmp);
            return Convert.ToUInt64(tmp);
        }
        static int GetNumberFromString(string s, int start, int num)
        {
            int index = start;
            for (int i = start; i < s.Length - num; i++)
            {
                int a = Convert.ToInt32(s[index]);
                int b = Convert.ToInt32(s[i]);
                if (a < b)
                {
                    index = i;
                }
            }
            return index;
        }
        static void Part2()
        {
            string fileName = "day3.txt";
            StreamReader sr = new StreamReader(fileName);
            ulong sum = 0;
            while (!sr.EndOfStream)
            {
                sum += CheckDigitsPart2(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
