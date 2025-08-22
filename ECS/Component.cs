[Component]
public abstract class Component
{
    private int _capacity;

    public int Capacity
    {
        get => _capacity;
        private set
        {
            _capacity = value;
            SetArrayCapacity(Capacity);
        }
    }
    public Component(int capacity) => Capacity = capacity;

    protected abstract void SetArrayCapacity(int Capacity);
}