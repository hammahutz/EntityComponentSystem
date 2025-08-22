using System;

public class Velocity : Component
{
    public float[] X;
    public float[] Y;

    public Velocity(int capacity)
        : base(capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }

    public override void AddToEntity(int index)
    {
        X[index] = Random.Shared.Next(-100, 100);
        Y[index] = Random.Shared.Next(-100, 100);
    }
}
