using System;

public class DynamicArray<T>
{
    private T[] _data = new T[1];
    private int _count = 0;

    public int Count => _count;
    public int Capacity => _data.Length;

    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }

    public DynamicArray() { }

    public void Add(T data)
    {
        if (_count >= _data.Length)
        {
            Array.Resize(ref _data, _data.Length * 2);
        }
        _data[_count] = data;
        _count++;
    }

    public void RemoveAt(int index)
    {
        if (index > _count)
            throw new ArgumentOutOfRangeException();

        _count--;
        _data[index] = _data[_count];
        _data[_count] = default!;
    }

    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < _count; i++)
        {
            action(_data[i]);
        }
    }
}
