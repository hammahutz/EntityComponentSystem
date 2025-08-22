using System.Collections.Generic;

public class Velocity : Component
{
    public float[] X;
    public float[] Y ;

    public Velocity(int Capacity) : base(Capacity){}

    protected override void SetArrayCapacity(int capacity)
    {
        X = new float [capacity];
        Y = new float[capacity];
    }
}


