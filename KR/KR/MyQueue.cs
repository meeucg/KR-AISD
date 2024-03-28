namespace KR;

public class MyQueue<T>
{
    private Node1<T>? _first;
    private Node1<T>? _last;
    public Node1<T>? Last { get => _last; }

    public T Current
    {
        get
        {
            if (_first == null)
            {
                throw new Exception();
            }
            return _first.Val;
        }
        set
        {
            if (_first == null)
            {
                throw new Exception();
            }
            _first.Val = value;
        }
    }

    public MyQueue()
    {
        _first = null;
        _last = null;
    }

    public void Add(T item)
    {
        if (_last == null)
        {
            _first = new Node1<T>(null, item);
            _last = _first;
            return;
        }
        _last.Next = new Node1<T>(null, item);
        _last = _last.Next;
    }

    public T Pop()
    {
        if (_first == null)
        {
            throw new Exception();
        }
        T temp = _first.Val;
        _first = _first.Next;
        return temp;
    }
}
