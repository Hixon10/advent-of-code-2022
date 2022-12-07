namespace advent_of_code_2022;

using System.Collections.Generic;

public class Day7
{
    public static void Part1(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("day7-input.txt");
        File current = null;
        File root = null;
        
        foreach (var line in lines)
        {
            if (line.StartsWith("$ cd "))
            {
                string dirOrDot = line.Replace("$ cd ", "").Trim();
                if (dirOrDot == "..")
                {
                    if (current == null)
                    {
                        // we are inside `/`
                        continue;
                    }
                    current = current.Parent;
                } else if (dirOrDot == "/")
                {
                    if (root == null)
                    {
                        root = new File("/", true, null);
                    }

                    current = root;
                }
                else
                {
                    current = current.Children[dirOrDot];
                }
            } else if (line.StartsWith("$ ls"))
            {
                // ignore
            }
            else
            {
                File newChildren;
                if (line.StartsWith("dir "))
                {
                    string folderName = line.Substring("dir ".Length);
                    newChildren = new File(folderName, true, current);
                }
                else
                {
                    string[] parts = line.Split(" ");
                    newChildren = new File(parts[1], false, current, int.Parse(parts[0]));
                }
                current.AddChildren(newChildren);
            }
        }

        while (current.Parent != null)
        {
            current = current.Parent;
        }
        
        TraversalTask1(current);
        Console.WriteLine(task1Resut);
    }

    public class File
    {
        private readonly string name;
        private readonly Dictionary<string, File>? children;
        private readonly bool isDir;
        private readonly int? size;
        private readonly File? parent;

        public File(string name, bool isDir, File? parent, int? size = null)
        {
            this.name = name;
            this.isDir = isDir;
            this.parent = parent;
            this.size = size;

            this.children = isDir ? new Dictionary<string, File>() : null;
            this.size = isDir ? null : size;
        }

        public void AddChildren(File dir)
        {
            if (!isDir)
            {
                throw new Exception("files cannot have children");
            }
            children.Add(dir.name, dir);
        }

        public int GetSizeWithoutNested()
        {
            return children.Values
                .Where(f => !f.isDir)
                .Sum(f => f.size)
                .Value;
        }

        public string Name => name;

        public Dictionary<string, File>? Children => children;

        public bool IsDir => isDir;

        public int? Size => size;

        public File? Parent => parent;

    }

    public static long task1Resut = 0;

    public static long TraversalTask1(File? r)
    {
        if (r == null || !r.IsDir)
        {
            return 0L;
        }

        long sizeWithoutNested = r.GetSizeWithoutNested();
        foreach (var childrenValue in r.Children.Values)
        {
            sizeWithoutNested += TraversalTask1(childrenValue);
        }

        if (sizeWithoutNested <= 100000)
        {
            task1Resut += sizeWithoutNested;
        }

        return sizeWithoutNested;
    }

    public static SortedDictionary<long, File> sizesToFiles = new SortedDictionary<long, File>();
     
    public static long TraversalTask2(File? r)
    {
        if (r == null || !r.IsDir)
        {
            return 0L;
        }

        long sizeWithoutNested = r.GetSizeWithoutNested();
        foreach (var childrenValue in r.Children.Values)
        {
            sizeWithoutNested += TraversalTask2(childrenValue);
        }

        sizesToFiles[sizeWithoutNested] = r;
        
        return sizeWithoutNested;
    }
    
    public static void Solve(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("day7-input.txt");
        File current = null;
        File root = null;
        
        foreach (var line in lines)
        {
            if (line.StartsWith("$ cd "))
            {
                string dirOrDot = line.Replace("$ cd ", "").Trim();
                if (dirOrDot == "..")
                {
                    if (current == null)
                    {
                        // we are inside `/`
                        continue;
                    }
                    current = current.Parent;
                } else if (dirOrDot == "/")
                {
                    if (root == null)
                    {
                        root = new File("/", true, null);
                    }

                    current = root;
                }
                else
                {
                    current = current.Children[dirOrDot];
                }
            } else if (line.StartsWith("$ ls"))
            {
                // ignore
            }
            else
            {
                File newChildren;
                if (line.StartsWith("dir "))
                {
                    string folderName = line.Substring("dir ".Length);
                    newChildren = new File(folderName, true, current);
                }
                else
                {
                    string[] parts = line.Split(" ");
                    newChildren = new File(parts[1], false, current, int.Parse(parts[0]));
                }
                current.AddChildren(newChildren);
            }
        }

        while (current.Parent != null)
        {
            current = current.Parent;
        }
        
        TraversalTask2(current);
        long totalSize = sizesToFiles.Last().Key;
        long freeSpace = 70000000 - totalSize;
        long needRemove = 30000000 - freeSpace;
        if (needRemove < 0)
        {
            throw new Exception("don't need to remove anything");
        }
        
        foreach (var (size, f) in sizesToFiles)
        {
            if (size >= needRemove)
            {
                Console.WriteLine(size);
                return;
            }
        }

        throw new Exception("why are we here??");
    }
}