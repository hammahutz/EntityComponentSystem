using System;

public abstract class Component
{
    public int Capacity { get; protected set; }
    public Component(int capacity)
    {
        Capacity = capacity;
    }
}

public abstract class Component<T> : Component
{
    public Component(int capacity) : base(capacity) { }

    public abstract T this[int index] { get; }
}

public abstract class Component<T, Y> : Component
{
    protected Component(int capacity) : base(capacity) { }

    public abstract (T, Y) this[int index] { get; }

}

[Component]
public class Position : Component<float, float>
{
    public float[] X { get; set; }
    public float[] Y { get; set; }

    public Position(int capacity) : base(capacity)
    {
        X = new float[capacity];
        Y = new float[capacity];
    }

    public override (float, float) this[int index] => (X[index], Y[index]);
}

[Component]
public class Velocity : Component<float, float>
{
    public float[] Dx { get; set; }
    public float[] Dy { get; set; }

    public Velocity(int capacity) : base(capacity)
    {
        Dx = new float[capacity];
        Dy = new float[capacity];
    }

    public override (float, float) this[int index] => (Dx[index], Dy[index]);


}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class ComponentAttribute : Attribute
{
}
