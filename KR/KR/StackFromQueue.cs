namespace KR;

public class StackFromQueue<T>
{
    private int _capacity = 100;
    private int itemsCount = 0;
    
    public StackFromQueue(int cap)
    { 
        _capacity = cap; 
    }

    public StackFromQueue()
    { }

    MyQueue<T> a = new MyQueue<T>();
    MyQueue<T> b = new MyQueue<T>();

    public void Add(T item)
    {
        a.Add(item);
        itemsCount++;
    }

    public T Peek()
    {
        if (itemsCount == 0)
        { 
            throw new Exception();
        }
        return a.Last.Val;
    }

    public T Remove() 
    {
        for (int i = 0; i < itemsCount - 1; i++)
        {
            b.Add(a.Pop());
        }
        for (int i = 0; i < itemsCount - 1; i++)
        {
            a.Add(b.Pop());
        }
        return a.Pop();
    }
}
