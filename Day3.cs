namespace advent_of_code_2022;

public class Day3
{
    public static void Part1(string[] args)
    {
        string[] lines = File.ReadAllLines("day3-input.txt");
        int result = 0;
        
        foreach (var line in lines)
        {
            bool[] presence = new bool[53];
            for (var i = 0; i < (line.Length / 2); i++)
            {
                int code = GetIntByChar(line[i]);
                presence[code] = true;
            }
            
            for (var i = (line.Length / 2); i < line.Length; i++)
            {
                int code = GetIntByChar(line[i]);
                if (presence[code])
                {
                    result += code;
                    break;
                }
            }
        }
        Console.WriteLine(result);
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day3-input.txt");
        int result = 0;
        
        for (var i = 0; i < lines.Length; i+=3)
        {
            bool[] presence1 = new bool[53];
            for (var j = 0; j < lines[i].Length; j++)
            {
                int code = GetIntByChar(lines[i][j]);
                presence1[code] = true;
            }
            
            bool[] presence2 = new bool[53];
            for (var j = 0; j < lines[i + 1].Length; j++)
            {
                int code = GetIntByChar(lines[i + 1][j]);
                presence2[code] = true;
            }
            
            bool[] presence3 = new bool[53];
            for (var j = 0; j < lines[i + 2].Length; j++)
            {
                int code = GetIntByChar(lines[i + 2][j]);
                if (presence1[code] && presence2[code] && !presence3[code])
                {
                    presence3[code] = true;
                    result += code;
                }
            }
        }
        Console.WriteLine(result);
    }

    private static int GetIntByChar(char ch)
    {
        if (char.IsUpper(ch))
        {
            return ch - 'A' + 1 + 26;
        }

        return ch - 'a' + 1;
    }
}