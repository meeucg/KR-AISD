using System;
namespace KR;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, world!");
        var seq = Sequence(new int[] { 0, 1, 2, 2 });
        Console.WriteLine($"{seq.Item1} { seq.Item2}");
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