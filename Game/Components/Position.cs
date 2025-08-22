using System;

public class Position : Component
{
    public float[] X;
    public float[] Y;

    public Position(int capacity)
        : base(capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }

    public override void AddToEntity(int index)
    {
        X[index] = Random.Shared.Next(0, 800);
        Y[index] = Random.Shared.Next(0, 600);
    }
}
