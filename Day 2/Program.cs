namespace Day_2
{
    internal class Program
    {
        static void Part1()
        {
            ulong sum = 0;
            
            string fileName = "day2.txt";
            string str = "";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                str += sr.ReadLine();
            }
            sr.Close();
            string[] boundries = str.Split(',');
            foreach (string bd in boundries)
            {
                string[] ids = bd.Split('-');
                ulong a = ulong.Parse(ids[0]);
                ulong b = ulong.Parse(ids[1]);
                for (ulong i = a; i <= b; i++) 
                {
                    string temp = Convert.ToString(i);
                    if(temp.Length % 2 == 0)
                    {
                        string temp2 = temp.Substring(0, temp.Length / 2);
                        string temp3 = temp.Substring(temp.Length / 2);
                        if (temp2 == temp3)
                        {
                            //Console.WriteLine(i);
                            sum += i;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
        static void Part2()
        {
            ulong sum = 0;

            string fileName = "day2.txt";
            string str = "";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                str += sr.ReadLine();
            }
            sr.Close();
            string[] boundries = str.Split(',');
            foreach (string bd in boundries)
            {
                string[] ids = bd.Split('-');
                ulong a = ulong.Parse(ids[0]);
                ulong b = ulong.Parse(ids[1]);
                for (ulong i = a; i <= b; i++)
                {
                    string temp = Convert.ToString(i);
                    for(int j = 1;j<temp.Length;j++)
                    {
                        if(CheckValue(temp,j))
                        {
                            sum += i;
                            //Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
        static bool CheckValue(string str, int num)
        {
            if (str.Length % num != 0)
            {
                return false;
            }
            List<string> subs = new List<string>();
            for (int i = 0; i < str.Length; i += num)
            {
                subs.Add(str.Substring(i, num));
            }

            for (int i = 1; i < subs.Count; i++)
            {
                if (subs[0] != subs[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Part1();

            Part2();
        }
    }
}
