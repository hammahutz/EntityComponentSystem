[Component]
public abstract class Component
{
    public int Capacity { get; private set; }

    public Component(int capacity)
    {
        Capacity = capacity;
    }

    public abstract void AddToEntity(int index);
}

