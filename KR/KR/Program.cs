using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
namespace KR;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, world!");
        var seq = Sequence(new int[] { 0, 1, 2, 2 });
        Console.WriteLine($"{seq.Item1} { seq.Item2}");

        var a = new MyLinkedList<int>();
        a.Add(1);
        a.Add(2);
        a.Add(3);
        a.Add(4);
        a.AddNode(a[1]);

        Console.WriteLine(a.IsLooping(1));
        Console.WriteLine(a.IsLooping(2));
        Console.WriteLine(a.IsLooping(3));
        Console.WriteLine(a.IsLooping(4));
        Console.WriteLine(a.IsLooping(5));
    }

    static ValueTuple<int, int> Sequence(int[] arr)
    {
        int n = arr.Length - 1;
        bool[] vals = new bool[n + 1];
        int sumTrue = (n * n + n) / 2;
        int sumCurrent = arr.Sum();
        int diff = sumTrue - sumCurrent;
        foreach (int i in arr)
        {
            if (vals[i])
            {
                return (i, i + diff);
            }
            vals[i] = true;
        }
        return (1, 1);
    }
}
