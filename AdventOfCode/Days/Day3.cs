namespace AdventOfCode.Days
{
    public class Day3
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day3\\input.txt");

            foreach (string input in inputs)
            {
                int first = 0;
                int second = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    int num = int.Parse(input.AsSpan(i,1));
                    if (num > first && i != input.Length - 1)
                    {
                        first = num;
                        second = int.Parse(input.AsSpan(i + 1, 1));
                    }
                    else if (num > second)
                    {
                        second = num;
                    }
                }
                result += int.Parse($"{first}{second}");
            }

            return result;
        }

        public static long Part2()
        {
            long result = 0;
            int numberLength = 12;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day3\\input.txt");

            foreach (string input in inputs)
            {
                List<int> resultNums = Enumerable.Repeat(0, numberLength).ToList();

                for (int i = 0; i < input.Length; i++)
                {
                    int inputNum = int.Parse(input.AsSpan(i, 1));
                    for (int j = 0; j < numberLength; j++)
                    {
                        if (resultNums[j] < inputNum && numberLength - j <= input.Length - i)
                        {
                            resultNums[j] = inputNum;
                            for (int k = 1; k < numberLength - j; k++)
                            {
                                resultNums[j + k] = 0;
                            }
                            break;
                        }
                    }
                }

                result += long.Parse(string.Join("", resultNums));
            }

            return result;
        }
    }
}