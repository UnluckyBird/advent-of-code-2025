namespace AdventOfCode.Days
{
    public class Day5
    {
        public static long Part1()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day5\\input.txt");

            bool isIds = false;
            List<(long, long)> ranges = [];
            foreach (string input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    isIds = true;
                    continue;
                }
                if (isIds == false)
                {
                    int split = input.IndexOf('-');
                    ranges.Add((long.Parse(input[..split]), long.Parse(input[(split+1)..])));
                }
                else
                {
                    long id = long.Parse(input);
                    if (ranges.Any(r => id >= r.Item1 && id <= r.Item2))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static long Part2()
        {
            long result = 0;

            string[] inputs = File.ReadAllLines(AppContext.BaseDirectory + "\\Data\\Day5\\input.txt");

            List<(long, long)> ranges = [];
            foreach (string input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                int split = input.IndexOf('-');
                ranges.Add((long.Parse(input[..split]), long.Parse(input[(split + 1)..])));
            }

            bool anyCombines;
            do
            {
                anyCombines = false;
                for (int i = 0; i < ranges.Count; i++)
                {
                    (long, long) newRange = (0, 0);
                    for (int j = i + 1; j < ranges.Count; j++)
                    {
                        if (ranges[i].Item1 <= ranges[j].Item1 && ranges[i].Item2 >= ranges[j].Item2)
                        {
                            ranges.Remove(ranges[j]);
                            j--;
                            anyCombines = true;
                        }
                        else if (ranges[j].Item1 <= ranges[i].Item1 && ranges[j].Item2 >= ranges[i].Item2)
                        {
                            ranges.Remove(ranges[i]);
                            i--;
                            j = i;
                            anyCombines = true;
                        }
                        else if ((ranges[i].Item1 < ranges[j].Item1 && ranges[i].Item2 >= ranges[j].Item1 && ranges[i].Item2 <= ranges[j].Item2) || (ranges[j].Item1 < ranges[i].Item1 && ranges[j].Item2 >= ranges[i].Item1 && ranges[j].Item2 <= ranges[i].Item2))
                        {
                            newRange.Item1 = ranges[i].Item1 < ranges[j].Item1 ? ranges[i].Item1 : ranges[j].Item1;
                            newRange.Item2 = ranges[i].Item2 > ranges[j].Item2 ? ranges[i].Item2 : ranges[j].Item2;
                            ranges.Remove(ranges[j]);
                            ranges.Remove(ranges[i]);
                            ranges.Add(newRange);
                            i--;
                            j = i;
                            anyCombines = true;
                        }
                    }
                }
            } while (anyCombines);

            foreach ((long, long) range in ranges)
            {
                result += range.Item2 - range.Item1 + 1;
            }
            return result;
        }
    }
}