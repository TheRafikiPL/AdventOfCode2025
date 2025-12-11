namespace Day_4
{
    internal class Program
    {
        static bool CheckRollsPart1(List<List<char>> rolls, int i, int j)
        {
            if (rolls[i][j] != '@')
            {
                return false;
            }
            int count = 0;
            //Check LeftUp
            if (i > 0 && j > 0)
            {
                if(rolls[i-1][j-1] == '@')
                {
                    count++;
                }
            }
            //Check Up
            if (i > 0)
            {
                if (rolls[i - 1][j] == '@')
                {
                    count++;
                }
            }
            //Check RightUp
            if (i > 0 && j < rolls[i].Count-1)
            {
                if (rolls[i - 1][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check Right
            if (j < rolls[i].Count - 1)
            {
                if (rolls[i][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check RightDown
            if (i < rolls.Count - 1 && j < rolls[i].Count - 1)
            {
                if (rolls[i + 1][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check Down
            if (i < rolls.Count - 1)
            {
                if (rolls[i + 1][j] == '@')
                {
                    count++;
                }
            }
            //Check DownLeft
            if (i < rolls.Count - 1 && j > 0)
            {
                if (rolls[i + 1][j - 1] == '@')
                {
                    count++;
                }
            }
            //Check Left
            if (j > 0)
            {
                if (rolls[i][j - 1] == '@')
                {
                    count++;
                }
            }
            if (count<4)
            {
                return true;
            }
            return false;
        }
        static void Part1()
        {
            List<List<char>> rolls = new List<List<char>>();
            string fileName = "day4.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                List<char> tmp = new List<char>();
                foreach(char c in s)
                {
                    tmp.Add(c);
                }
                rolls.Add(tmp);
            }
            sr.Close();
            int sum = 0;
            for(int i = 0; i < rolls.Count; i++)
            {
                for (int j = 0; j < rolls[i].Count; j++)
                {
                    if (CheckRollsPart1(rolls, i, j))
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        static bool CheckRollsPart2(List<List<char>> rolls, int i, int j)
        {
            if (rolls[i][j] != '@')
            {
                return false;
            }
            int count = 0;
            //Check LeftUp
            if (i > 0 && j > 0)
            {
                if (rolls[i - 1][j - 1] == '@')
                {
                    count++;
                }
            }
            //Check Up
            if (i > 0)
            {
                if (rolls[i - 1][j] == '@')
                {
                    count++;
                }
            }
            //Check RightUp
            if (i > 0 && j < rolls[i].Count - 1)
            {
                if (rolls[i - 1][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check Right
            if (j < rolls[i].Count - 1)
            {
                if (rolls[i][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check RightDown
            if (i < rolls.Count - 1 && j < rolls[i].Count - 1)
            {
                if (rolls[i + 1][j + 1] == '@')
                {
                    count++;
                }
            }
            //Check Down
            if (i < rolls.Count - 1)
            {
                if (rolls[i + 1][j] == '@')
                {
                    count++;
                }
            }
            //Check DownLeft
            if (i < rolls.Count - 1 && j > 0)
            {
                if (rolls[i + 1][j - 1] == '@')
                {
                    count++;
                }
            }
            //Check Left
            if (j > 0)
            {
                if (rolls[i][j - 1] == '@')
                {
                    count++;
                }
            }
            if (count < 4)
            {
                return true;
            }
            return false;
        }
        static void Part2()
        {
            List<List<char>> rolls = new List<List<char>>();
            string fileName = "day4.txt";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                List<char> tmp = new List<char>();
                foreach (char c in s)
                {
                    tmp.Add(c);
                }
                rolls.Add(tmp);
            }
            sr.Close();
            int sum = 0;
            List<KeyValuePair<int, int>> toRemove;
            do
            {
                toRemove = new List<KeyValuePair<int, int>>();
                for (int i = 0; i < rolls.Count; i++)
                {
                    for (int j = 0; j < rolls[i].Count; j++)
                    {
                        if (CheckRollsPart2(rolls, i, j))
                        {
                            toRemove.Add(new KeyValuePair<int, int>(i, j));
                            sum++;
                        }
                    }
                }
                foreach(KeyValuePair<int,int> ind in toRemove)
                {
                    rolls[ind.Key][ind.Value] = '.';
                }
            } while (toRemove.Count > 0);
            
            
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
