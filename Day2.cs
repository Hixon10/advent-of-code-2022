namespace advent_of_code_2022;

public class Day2
{
    public static void Part1(string[] args)
    {
        string[] lines = File.ReadAllLines("day2-input.txt");
        int total = 0;
        foreach (var line in lines)
        {
            char opponent = line[0];
            char my = line[2];
            if (opponent == 'A') // Rock
            {
                if (my == 'X') // Rock
                {
                    total += 1;
                    total += 3; // draw
                } else if (my == 'Y') // Paper
                {
                    total += 2;
                    total += 6;
                } else if (my == 'Z') // Scissors
                {
                    total += 3;
                    total += 0;
                }
            } else if (opponent == 'B') // Paper
            {
                if (my == 'X') // Rock
                {
                    total += 1;
                    total += 0;
                } else if (my == 'Y') // Paper
                {
                    total += 2;
                    total += 3; // draw
                } else if (my == 'Z') // Scissors
                {
                    total += 3;
                    total += 6;
                }
            } else if (opponent == 'C') // Scissors
            {
                if (my == 'X') // Rock
                {
                    total += 1;
                    total += 6;
                } else if (my == 'Y') // Paper
                {
                    total += 2;
                    total += 0;
                } else if (my == 'Z') // Scissors
                {
                    total += 3;
                    total += 3; // draw
                }
            }
        }
        Console.WriteLine(total);
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day2-input.txt");
        int total = 0;
        
        // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock
        // 1 for Rock, 2 for Paper, and 3 for Scissors
        // 0 if you lost, 3 if the round was a draw, and 6 if you won
        foreach (var line in lines)
        {
            char opponent = line[0];
            char my = line[2];
            if (opponent == 'A') // Rock
            {
                if (my == 'X') // you need to lose
                {
                    // my Scissors
                    total += 3;
                    total += 0;
                } else if (my == 'Y') // you need to end the round in a draw
                {
                    // my Rock
                    total += 1;
                    total += 3;
                } else if (my == 'Z') // you need to win
                {
                    // my Paper
                    total += 2;
                    total += 6;
                }
            } else if (opponent == 'B') // Paper
            {
                if (my == 'X') // you need to lose
                {
                    // my Rock
                    total += 1;
                    total += 0;
                } else if (my == 'Y') // you need to end the round in a draw
                {
                    // my Paper
                    total += 2;
                    total += 3;
                } else if (my == 'Z') // you need to win
                {
                    // my Scissors
                    total += 3;
                    total += 6;
                }
            } else if (opponent == 'C') // Scissors
            {
                if (my == 'X') // you need to lose
                {
                    // my Paper
                    total += 2;
                    total += 0;
                } else if (my == 'Y') // you need to end the round in a draw
                {
                    // my Scissors
                    total += 3;
                    total += 3;
                } else if (my == 'Z') // you need to win
                {
                    // my Rock
                    total += 1;
                    total += 6;
                }
            }
        }
        Console.WriteLine(total);
    }
}