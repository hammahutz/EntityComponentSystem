using System.Numerics;

public class Position : Component
{
    public float[] X;
    public float[] Y;

    public Position(int capacity) : base(capacity)
    {
    }

    protected override void SetCapacity(int capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }
}

