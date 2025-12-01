namespace AdventOfCode.Days
{
    public class Day1
    {
        public static int Part1()
        {
            int result = 0;
            int pos = 50;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day1\\input.txt");

            foreach (string input in inputs)
            {
                int rot = int.Parse(input[1..]);
                if (input[0] == 'L')
                {
                    pos = (pos - rot) % 100;
                }
                else if (input[0] == 'R')
                {
                    pos = (pos + rot) % 100;
                }

                if (pos == 0)
                {
                    result++;
                }
            }

            return result;
        }

        public static int Part2()
        {
            int result = 0;
            int pos = 50;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day1\\input.txt");

            foreach (string input in inputs)
            {
                int rot = int.Parse(input[1..]);
                if (input[0] == 'L')
                {
                    pos = (pos - rot);
                }
                else if (input[0] == 'R')
                {
                    pos = (pos + rot);
                }

                if (pos <= 0 && pos + rot != 0)
                {
                    result++;
                }
                result += Math.Abs(pos / 100);
                pos = pos % 100;
                if (pos < 0)
                {
                    pos += 100;
                }
            }

            return result;
        }
    }
}