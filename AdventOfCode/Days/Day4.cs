namespace AdventOfCode.Days
{
    public class Day4
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day4\\input.txt");

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if (inputs[i][j] == '@')
                    {
                        int surrounding = 0;
                        if (i > 0)
                        {
                            if (j > 0 && inputs[i - 1][j - 1] == '@')
                            {
                                surrounding++;
                            }
                            if (inputs[i - 1][j] == '@')
                            {
                                surrounding++;
                            }
                            if (j < inputs[i].Length - 1 && inputs[i - 1][j + 1] == '@')
                            {
                                surrounding++;
                            }
                        }
                        if (i < inputs.Length - 1)
                        {
                            if (j > 0 && inputs[i + 1][j - 1] == '@')
                            {
                                surrounding++;
                            }
                            if (inputs[i + 1][j] == '@')
                            {
                                surrounding++;
                            }
                            if (j < inputs[i].Length - 1 && inputs[i + 1][j + 1] == '@')
                            {
                                surrounding++;
                            }
                        }
                        if (j > 0 && inputs[i][j - 1] == '@')
                        {
                            surrounding++;
                        }
                        if (j < inputs[i].Length - 1 && inputs[i][j + 1] == '@')
                        {
                            surrounding++;
                        }

                        if (surrounding < 4)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        public static long Part2()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day4\\input.txt");

            bool[,] rolls = new bool[inputs.Length, inputs[0].Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if (inputs[i][j] == '@')
                    {
                        rolls[i, j] = true;
                    }
                }
            }

            List<(int, int)> removedRolls = [];
            do
            {
                removedRolls.Clear();
                for (int i = 0; i < inputs.Length; i++)
                {
                    for (int j = 0; j < inputs[i].Length; j++)
                    {
                        if (rolls[i, j])
                        {
                            int surrounding = 0;
                            if (i > 0)
                            {
                                if (j > 0 && rolls[i - 1, j - 1])
                                {
                                    surrounding++;
                                }
                                if (rolls[i - 1, j])
                                {
                                    surrounding++;
                                }
                                if (j < inputs[i].Length - 1 && rolls[i - 1, j + 1])
                                {
                                    surrounding++;
                                }
                            } 
                            if (i < inputs.Length - 1)
                            {
                                if (j > 0 && rolls[i + 1, j - 1])
                                {
                                    surrounding++;
                                }
                                if (rolls[i + 1, j])
                                {
                                    surrounding++;
                                }
                                if (j < inputs[i].Length - 1 && rolls[i + 1, j + 1])
                                {
                                    surrounding++;
                                }
                            }
                            if (j > 0 && rolls[i, j - 1])
                            {
                                surrounding++;
                            }
                            if (j < inputs[i].Length - 1 && rolls[i, j + 1])
                            {
                                surrounding++;
                            }

                            if (surrounding < 4)
                            {
                                removedRolls.Add((i,j));
                            }
                        }
                    }
                }
                foreach ((int, int) removedRoll in removedRolls)
                {
                    rolls[removedRoll.Item1, removedRoll.Item2] = false;
                }
                result += removedRolls.Count;
            } while (removedRolls.Count > 0);

            return result;
        }
    }
}