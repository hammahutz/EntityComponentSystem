using System.Numerics;

public struct Position
{
    public Position(int capacity = 1)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }

    public float[] X;
    public float[] Y;

}

