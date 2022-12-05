namespace advent_of_code_2022;

public class Day5
{
    public static void Part1(string[] args)
    {
        string[] lines = File.ReadAllLines("day5-input.txt");

        int indexOfLineWithStackIndexes = 0;
        string lineWithStackIndexes = lines[indexOfLineWithStackIndexes];
        for (var i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                break;
            }
            indexOfLineWithStackIndexes = i;
            lineWithStackIndexes = lines[indexOfLineWithStackIndexes]; 
        }

        string[] stackIndexes = lineWithStackIndexes.Split("   ");
        SortedDictionary<int, Stack<char>> stacks = new SortedDictionary<int, Stack<char>>();
        for (var i = 0; i < stackIndexes.Length; i++)
        {
            int stackIndex = int.Parse(stackIndexes[i]);
            int matrixIndex = lineWithStackIndexes.IndexOf(Char.Parse(stackIndexes[i].Trim()));
            stacks[stackIndex] = new Stack<char>();
            for (var j = indexOfLineWithStackIndexes - 1; j >= 0; j--)
            {
                var currentCh = lines[j][matrixIndex];
                if (char.IsLetter(currentCh))
                {
                    stacks[stackIndex].Push(currentCh);
                }
            }
        }

        for (int i = indexOfLineWithStackIndexes + 2; i < lines.Length; i++)
        {
            var commandParts = lines[i].Split(" ");
            int count = int.Parse(commandParts[1]);
            int from = int.Parse(commandParts[3]);
            int to = int.Parse(commandParts[5]);
            for (int j = 0; j < count; j++)
            {
                var val = stacks[from].Pop();
                stacks[to].Push(val);
            }
        }
        
        foreach (var (key, value) in stacks)
        {
            Console.Write(value.Pop());
        }
        Console.WriteLine(); 
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day5-input.txt");

        int indexOfLineWithStackIndexes = 0;
        string lineWithStackIndexes = lines[indexOfLineWithStackIndexes];
        for (var i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                break;
            }
            indexOfLineWithStackIndexes = i;
            lineWithStackIndexes = lines[indexOfLineWithStackIndexes]; 
        }

        string[] stackIndexes = lineWithStackIndexes.Split("   ");
        SortedDictionary<int, Stack<char>> stacks = new SortedDictionary<int, Stack<char>>();
        for (var i = 0; i < stackIndexes.Length; i++)
        {
            int stackIndex = int.Parse(stackIndexes[i]);
            int matrixIndex = lineWithStackIndexes.IndexOf(Char.Parse(stackIndexes[i].Trim()));
            stacks[stackIndex] = new Stack<char>();
            for (var j = indexOfLineWithStackIndexes - 1; j >= 0; j--)
            {
                var currentCh = lines[j][matrixIndex];
                if (char.IsLetter(currentCh))
                {
                    stacks[stackIndex].Push(currentCh);
                }
            }
        }

        for (int i = indexOfLineWithStackIndexes + 2; i < lines.Length; i++)
        {
            var commandParts = lines[i].Split(" ");
            int count = int.Parse(commandParts[1]);
            int from = int.Parse(commandParts[3]);
            int to = int.Parse(commandParts[5]);
            Stack<char> tmp = new Stack<char>();
            for (int j = 0; j < count; j++)
            {
                var val = stacks[from].Pop();
                tmp.Push(val);
            }

            while (tmp.Count > 0)
            {
                stacks[to].Push(tmp.Pop());
            }
        }
        
        foreach (var (key, value) in stacks)
        {
            Console.Write(value.Pop());
        }
        Console.WriteLine();
    }
}