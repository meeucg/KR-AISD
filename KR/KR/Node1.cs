namespace KR;

public class Node1<T>
{
    public Node1<T>? Next { get; set; }
    public T Val;

    public Node1(Node1<T> next, T val)
    {
        Next = next;
        Val = val;
    }
}
