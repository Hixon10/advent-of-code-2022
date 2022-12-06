namespace advent_of_code_2022;

using System.Collections.Generic;

public class Day6
{
    public static void Part1(string[] args)
    {
        string[] lines = File.ReadAllLines("day6-input.txt");
    }

    public static void Solve(string[] args)
    {
        string input = File.ReadAllText("day6-input.txt");

        int firstIndex = 0;
        HashSet<char> set = new HashSet<char>();
        int result = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (set.Count == 14)
            {
                result = i;
                break;
            }

            char current = input[i];
            if (!set.Add(current))
            {
                for (; firstIndex < i; firstIndex++)
                {
                    char prevCh = input[firstIndex];
                    set.Remove(prevCh);
                    if (prevCh == current)
                    {
                        set.Add(current);
                        firstIndex++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(result);
    }
}