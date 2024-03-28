using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
namespace KR;


//доп знчение isVisited
public class Node<T>
{
    public Node<T> Next { get; set; }    
    public T Val { get; set; }
    public bool isVisited { get; set; }

    public Node(Node<T> next, T val)
    { 
        Next = next;
        Val = val;
        isVisited = false;
    }
}


//лист обрезанный конкретно под эту задачу
public class MyLinkedList<T>
{
    Node<T>? _first;
    Node<T>? _last;
    Node<T>? _current;
    private int maxSize = 0;

    public MyLinkedList()
    {
        _first = null;
        _last = null;
        _current = null;
    }

    public MyLinkedList(Node<T> node)
    {
        _first = node;
        _last = node;
        _current = node;
    }

    public Node<T>? this[int i]
    {
        get 
        {
            if (i > maxSize)
            {
                return null;
            }
            _current = _first;
            for (; i > 0; i--)
            { 
                /*if (_current.Next == null)
                {
                    return _current;
                }*/
                _current = _current.Next;
            }
            return _current;
        }

        set 
        {
            _current = _first;
            for (; i > 0; i--)
            {
                if (_current.Next == null)
                {
                    return;
                }
                _current = _current.Next;
            }
            _current = value;
        }
    }

    public void AddNode(Node<T> node)
    {
        if (_last == null)
        {
            _first = node;
            _last = _first;
        }
        _last.Next = node;
        _last = _last.Next;
        maxSize++;
    }

    public void Add(T val)
    {
        if (_last == null)
        {
            _first = new Node<T>(null, val);
            _last = _first;
        }
        _last.Next = new Node<T>(_last, val);
        _last = _last.Next;
        maxSize++;
    }

    public bool IsLooping(int i)
    {
        var item = this[i];
        if (item == null)
        {
            return false;
        }
        Node<T> check = item;
        for (int j = 0; j < maxSize; j++)
        {
            if (check.Next.isVisited)
            { 
                return !item.isVisited;
            }
        }
        return !item.isVisited;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, world!");
        var seq = Sequence(new int[] { 0, 1, 2, 2 });
        Console.WriteLine($"{seq.Item1} { seq.Item2}");

        var a = new MyLinkedList<int>();
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

    static 
}