namespace advent_of_code_2022;

public class Day1
{
    public static void SolveFirstPart(string[] args)
    {
        string[] lines = File.ReadAllLines("day1-input.txt");
        int current = 0;
        int currentMax = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrEmpty(line))
            {
                currentMax = Math.Max(currentMax, current);
                current = 0;
                continue;
            }

            current += int.Parse(line);
        }
        currentMax = Math.Max(currentMax, current);
        Console.WriteLine(currentMax);
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day1-input.txt");
        int current = 0;
        int firstMax = 0;
        int secondMax = 0;
        int thirdMax = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrEmpty(line))
            {
                int currentMin;
                firstMax = GetMaxAndOutMin(firstMax, current, out currentMin);
                secondMax = GetMaxAndOutMin(secondMax, currentMin, out currentMin);
                thirdMax = GetMaxAndOutMin(thirdMax, currentMin, out currentMin);
                current = 0;
                continue;
            }

            current += int.Parse(line);
        }
        int currentMinOut;
        firstMax = GetMaxAndOutMin(firstMax, current, out currentMinOut);
        secondMax = GetMaxAndOutMin(secondMax, currentMinOut, out currentMinOut);
        thirdMax = GetMaxAndOutMin(thirdMax, currentMinOut, out currentMinOut);
        Console.WriteLine(firstMax + secondMax + thirdMax);
    }

    private static int GetMaxAndOutMin(int n1, int n2, out int min)
    {
        if (n1 > n2)
        {
            min = n2;
            return n1;
        }
        min = n1;
        return n2;
    }
}