namespace AdventOfCode.Days
{
    public class Day7
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day7\\input.txt");

            int[][] grid = Enumerable.Range(0, inputs.Length)
                      .Select(x => Enumerable.Repeat(0, inputs[0].Length).ToArray())
                      .ToArray();

            for (int i = 0; i < inputs[0].Length; i++)
            {
                if (inputs[0][i] == 'S')
                {
                    grid[1][i] = 1;
                }
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if (inputs[i][j] == '^')
                    {
                        if (grid[i - 1][j] != 0)
                        {
                            result++;
                        }
                        grid[i + 1][j - 1] += grid[i - 1][j];
                        grid[i + 1][j + 1] += grid[i - 1][j];
                    }
                    else if (i > 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                    }
                }
            }

            return result;
        }

        public static long Part2()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day7\\input.txt");

            long[][] grid = Enumerable.Range(0, inputs.Length)
                      .Select(x => Enumerable.Repeat((long)0, inputs[0].Length).ToArray())
                      .ToArray();

            for (int i = 0; i < inputs[0].Length; i++)
            {
                if (inputs[0][i] == 'S')
                {
                    grid[1][i] = 1;
                }
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if (inputs[i][j] == '^')
                    {
                        grid[i + 1][j - 1] += grid[i - 1][j];
                        grid[i + 1][j + 1] += grid[i - 1][j];
                    }
                    else if (i > 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                    }
                }
            }

            result = grid[^1].Sum();

            return result;
        }
    }
}