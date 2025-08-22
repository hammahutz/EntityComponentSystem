using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Position : Component
{

    public float[] X;
    public float[] Y;

    public Position(int Capacity) : base(Capacity){}

    protected override void SetArrayCapacity(int capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }
}

