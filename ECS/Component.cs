using System;
using System.Numerics;


public abstract class Component
{
    private int _capacity;
    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Capacity), "Capacity must be non-negative.");
            _capacity = value;
            SetCapacity(_capacity);
        }
    }
    public Component(int capacity) => Capacity = capacity;
    protected abstract void SetCapacity(int capacity);

}
