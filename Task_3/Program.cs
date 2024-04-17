using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3;

public class Folder : IComparable<Folder>
{
    public string Title { get; }
    public List<Folder> SubFolders { get; }

    public Folder(string title, List<Folder> subFolders)
    {
        Title = title;
        SubFolders = subFolders;
    }

    public int CompareTo(Folder? other)
    {
        return string.Compare(Title, other?.Title, StringComparison.Ordinal);
    }
}


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Folder? root = null;

        for (int i = 0; i < n; i++)
        {
            string[] path = Console.ReadLine()!.Split('/');
            if (root == null)
            {
                root = new Folder(path[0], new List<Folder>());
            }

            var dummy = root;
            for (int j = 1; j < path.Length; j++)
            {
                if (dummy!.SubFolders.All(f => f.Title != path[j]))
                {
                    dummy.SubFolders.Add(new Folder(path[j], new List<Folder>()));
                }

                dummy = dummy.SubFolders.Find(f => f.Title == path[j]);
            }
        }
        PrintDirectories(root!, 0);
    }
    
    static void PrintDirectories(Folder folder, int indent)
    {
        Console.WriteLine(new string(' ', indent * 2) + folder.Title);

        foreach (var subFolder in folder.SubFolders.OrderBy(d => d))
        {
            PrintDirectories(subFolder, indent + 1);
        }
    }
}