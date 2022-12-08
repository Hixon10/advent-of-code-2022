namespace advent_of_code_2022;

using System.Collections.Generic;

public class Day8
{
    public static void Part1(string[] args)
    {
        HashSet<Point> results = new HashSet<Point>();
        
        string[] lines = File.ReadAllLines("day8-input.txt");
        // left -> right
        for (var i = 0; i < lines.Length; i++)
        {
            int currentMax = lines[i][0] - '0';
            for (var j = 0; j < lines[i].Length; j++)
            {
                if (i == 0 || j == 0 || i == (lines.Length - 1) || j == (lines[i].Length - 1))
                {
                    results.Add(new Point(j, i));
                    continue;
                }
                
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                    results.Add(new Point(j, i));
                }
            }
        }
        
        // right -> left
        for (var i = 1; i < lines.Length - 1; i++)
        {
            int currentMax = lines[i][lines[0].Length - 1] - '0';
            for (var j = lines[i].Length - 2; j >= 1; j--)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                    results.Add(new Point(j, i));
                }
            }
        }
        
        // top -> bottom
        for (var j = 1; j < lines[0].Length - 1; j++)
        {
            int currentMax = lines[0][j] - '0';
            for (var i = 1; i < lines.Length - 1; i++)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                    results.Add(new Point(j, i));
                }
            }
        }
        
        // bottom -> top
        for (var j = 1; j < lines[0].Length - 1; j++)
        {
            int currentMax = lines[lines.Length - 1][j] - '0';
            for (var i = lines.Length - 2; i >= 1; i--)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                    results.Add(new Point(j, i));
                }
            }
        }
        
        Console.WriteLine(results.Count);
    }

    public class Point
    {
        public readonly int I;
        public readonly int J;
        
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }

        public Point(int j, int i)
        {
            this.I = i;
            this.J = j;
            Value1 = 0;
            Value2 = 0;
            Value3 = 0;
            Value4 = 0;
        }

        protected bool Equals(Point other)
        {
            return I == other.I && J == other.J;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(I, J);
        }

        public static bool operator ==(Point? left, Point? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point? left, Point? right)
        {
            return !Equals(left, right);
        }
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = File.ReadAllLines("day8-input.txt");
        
        Point[,] ar = new Point[lines.Length, lines[0].Length];
        for (var i = 0; i < ar.Length; i++)
        {
            for (var j = 0; j < lines[0].Length; j++)
            {
                ar[i, j] = new Point(j, i);
            }
        }
        
        // left -> right
        for (var i = 1; i < lines.Length - 1; i++)
        {
            int currentMax = lines[i][0] - '0';
            for (var j = 1; j < lines[i].Length - 1; j++)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                    // ar[i, j].Value1 = 
                    // results.Add(new Point(j, i));
                }
            }
        }
        
        // right -> left
        for (var i = 1; i < lines.Length - 1; i++)
        {
            int currentMax = lines[i][lines[0].Length - 1] - '0';
            for (var j = lines[i].Length - 2; j >= 1; j--)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                }
            }
        }
        
        // top -> bottom
        for (var j = 1; j < lines[0].Length - 1; j++)
        {
            int currentMax = lines[0][j] - '0';
            for (var i = 1; i < lines.Length - 1; i++)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                }
            }
        }
        
        // bottom -> top
        for (var j = 1; j < lines[0].Length - 1; j++)
        {
            int currentMax = lines[lines.Length - 1][j] - '0';
            for (var i = lines.Length - 2; i >= 1; i--)
            {
                int current = lines[i][j] - '0';
                if (currentMax < current)
                {
                    currentMax = current;
                }
            }
        }
        
        Console.WriteLine(0);
    }
}