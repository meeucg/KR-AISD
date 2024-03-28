namespace KR;

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
            if (i >= maxSize)
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
        }//не работает нифига
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
            if (check.Next==null || check.Next.isVisited)
            { 
                return item.isVisited;
            }
            check = check.Next;
            check.isVisited = true;
            Console.WriteLine(check.Val);
        }
        return item.isVisited;
    }
}
