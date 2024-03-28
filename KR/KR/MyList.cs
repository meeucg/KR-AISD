using System;
using System.Collections;

namespace KR;

public class MyList<T> : IEnumerable<T>
{
    private int _size = 0;
    private T[] _items;
    public int Count { get => _size; }

    public MyList()
    {
        _items = new T[4];
    }

    public MyList(int size)
    {
        _items = new T[size];
    }

    public MyList(IEnumerable<T> arr)
    {
        _items = new T[4];
        foreach (var i in arr)
        {
            this.Add(i);
        }
    }

    public T this[int i]
    {
        get => _items[i];
        set
        {
            if (i >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            _items[i] = value;
        }
    }

    public void Add(T item)
    {
        if (_items.Length > _size)
        {
            _items[_size] = item;
            _size++;
        }
        else
        {
            AddResize(item);
        }
    }

    private void AddResize(T item)
    {
        _size++;
        var newItems = new T[_size];
        for (int i = 0; i < _size - 1; i++)
        {
            newItems[i] = _items[i];
        }
        newItems[_size - 1] = item;
        _items = newItems;
    }

    public bool RemoveAt(int i)
    {
        if (i >= _size)
        {
            return false;
        }
        _size -= 1;
        for (; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnum<T>(_items, _size);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    class MyListEnum<V>(V[] array, int size) : IEnumerator<V>
    {
        private int index = -1;

        object IEnumerator.Current => array[index];

        public V Current => array[index];

        public bool MoveNext()
        {
            if (index == size - 1) { return false; }
            index++;
            return true;
        }

        public void Reset()
        {
            index = 0;
        }

        public void Dispose() { }
    }
}