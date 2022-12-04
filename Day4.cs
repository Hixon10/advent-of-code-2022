namespace advent_of_code_2022;

public class Day4
{
    public static void Part1(string[] args)
    {
        string[] lines = File.ReadAllLines("day4-input.txt");
        int result = 0; 
        
        foreach (var line in lines)
        {
            var pairs = line.Split(',');
            
            var firstParts = pairs[0].Split('-');
            int firstLeft = int.Parse(firstParts[0]);
            int firstRight = int.Parse(firstParts[1]);
            
            var secondParts = pairs[1].Split('-');
            int secondLeft = int.Parse(secondParts[0]);
            int secondRight = int.Parse(secondParts[1]);

            if (firstLeft <= secondLeft && firstRight >= secondRight)
            {
                Console.WriteLine(line);
                result++;
                continue;
            }

            if (secondLeft <= firstLeft && secondRight >= firstRight)
            {
                result++;
                Console.WriteLine(line);
            }
        }

        Console.WriteLine(result);
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day4-input.txt");
        int notOverlap = 0; 
        
        foreach (var line in lines)
        {
            var pairs = line.Split(',');
            
            var firstParts = pairs[0].Split('-');
            int firstLeft = int.Parse(firstParts[0]);
            int firstRight = int.Parse(firstParts[1]);
            
            var secondParts = pairs[1].Split('-');
            int secondLeft = int.Parse(secondParts[0]);
            int secondRight = int.Parse(secondParts[1]);

            if (firstRight < secondLeft || secondRight < firstLeft)
            {
                notOverlap++;
            }
        }
        Console.WriteLine(lines.Length - notOverlap);
    }
}