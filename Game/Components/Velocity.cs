
public class Velocity : Component
{
    public float[] X;
    public float[] Y;

    public Velocity(int capacity) : base(capacity)
    {
    }

    protected override void SetCapacity(int capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }
}


