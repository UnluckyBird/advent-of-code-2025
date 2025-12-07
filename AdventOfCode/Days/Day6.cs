using System.Text;

namespace AdventOfCode.Days
{
    public class Day6
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day6\\input.txt");

            List<List<string>> lists = inputs.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
            for (int i = 0; i < lists[0].Count; i++)
            {
                long num = lists[^1][i] == "*" ? 1 : 0;
                for (int j = 0; j < lists.Count - 1; j++)
                {
                    num = lists[^1][i] == "*" ? num * long.Parse(lists[j][i]) : num + long.Parse(lists[j][i]);
                }
                result += num;
            }
            
            return result;
        }

        public static long Part2()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day6\\input.txt");

            List<int> toCalc = [];
            for (int j = inputs[0].Length - 1; j >= 0; j--)
            {
                StringBuilder sb = new();
                for (int i = 0; i < inputs.Length - 1; i++)
                {
                    if (inputs[i][j] != ' ')
                    {
                        sb.Append(inputs[i][j]);
                    }
                }
                toCalc.Add(int.Parse(sb.ToString()));
                if (inputs[^1][j] == '*')
                {
                    long num = 1;
                    foreach (int number in toCalc)
                    {
                        num *= number;
                    }
                    result += num;
                    toCalc.Clear();
                    j--;
                }
                else if (inputs[^1][j] == '+')
                {
                    long num = 0;
                    foreach (int number in toCalc)
                    {
                        num += number;
                    }
                    result += num;
                    toCalc.Clear();
                    j--;
                }
            }

            return result;
        }
    }
}