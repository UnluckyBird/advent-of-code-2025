namespace AdventOfCode.Days
{
    public class Day2
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day2\\input.txt");

            var ranges = inputs[0].Split(',').Select(r => r.Split('-').Select(long.Parse).ToArray()).ToArray();

            foreach (var range in ranges)
            {
                for (long i = range[0]; i <= range[1]; i++)
                {
                    string id = i.ToString();
                    if (id.Length %  2 == 0 && id[..(id.Length/2)] == id[(id.Length / 2)..])
                    {
                        result += i;
                    }
                }
            }

            return result;
        }

        public static long Part2()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day2\\input.txt");

            var ranges = inputs[0].Split(',').Select(r => r.Split('-').Select(long.Parse).ToArray()).ToArray();

            foreach (var range in ranges)
            {
                for (long i = range[0]; i <= range[1]; i++)
                {
                    string id = i.ToString();
                    for (int j = 1; j < id.Length; j++)
                    {
                        if (id.Length % j == 0)
                        {
                            var chunks = Enumerable.Range(0, id.Length / j).Select(i => id.Substring(i * j, j)).ToHashSet();
                            if (chunks.Count == 1)
                            {
                                result += i;
                                break;
                            }        
                        }
                    }
                }
            }

            return result;
        }
    }
}