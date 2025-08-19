using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

public abstract class Archetype
{
    public List<Entity> Entities { get; protected set; } = new List<Entity>();
}

[Archetype(typeof(Position), typeof(Velocity))]
public class PosVes : Archetype
{

    public Position Position { get; private set; }
    public Velocity Velocity { get; private set; }


    public PosVes(int capacity)
    {
        Position = new Position(capacity);
        Velocity = new Velocity(capacity);
    }

    public IEnumerable<((float, float), (float, float))> QueryEnumerableSingel()
    {
        for (int i = 0; i < Entities.Count; i++)
        {
            yield return (Position[Entities[i].Id], Velocity[Entities[i].Id]);
        }
    }

    public void QueryActionSingle(Action<(float, float), (float, float)> action)
    {
        for (int i = 0; i < Entities.Count; i++)
        {
            action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
        }
    }

    public void QueryActionSingleSMID(Action<Vector<float>, Vector<float>, Vector<float>, Vector<float>> action)
    {
        int smidWidth = Vector<float>.Count;
        int n = Entities.Count;
        for (int i = 0; i < n / smidWidth; i++)
        {
            int index = i * smidWidth;
            action(new Vector<float>(Position.X, index),
                   new Vector<float>(Position.Y, index),
                   new Vector<float>(Velocity.Dx, index),
                   new Vector<float>(Velocity.Dy, index));
        }

        for (int i = n - n % smidWidth; i < n; i++)
        {
            action(new Vector<float>(Position.X, i),
                   new Vector<float>(Position.Y, i),
                   new Vector<float>(Velocity.Dx, i),
                   new Vector<float>(Velocity.Dy, i));
        }
    }
    public void QueryActionParallel(Action<(float, float), (float, float)> action)
    {
        Parallel.For(0, Entities.Count, i =>
        {
            action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
        });
    }
    public void QueryActionParallelSMID(Action<Vector<float>, Vector<float>, Vector<float>, Vector<float>> action)
    {
        int smidWidth = Vector<float>.Count;
        int n = Entities.Count;
        Parallel.For(0, n / smidWidth, chunk =>
        {
            int i = chunk * smidWidth;

            Vector<float> posX = new Vector<float>(Position.X, i);
            Vector<float> posY = new Vector<float>(Position.Y, i);
            Vector<float> velX = new Vector<float>(Velocity.Dx, i);
            Vector<float> velY = new Vector<float>(Velocity.Dy, i);

            action(new Vector<float>(Position.X, i),
                   new Vector<float>(Position.Y, i),
                   new Vector<float>(Velocity.Dx, i),
                   new Vector<float>(Velocity.Dy, i));
        });

        for (int i = n - n % smidWidth; i < n; i++)
        {
            action(new Vector<float>(Position.X, i),
                   new Vector<float>(Position.Y, i),
                   new Vector<float>(Velocity.Dx, i),
                   new Vector<float>(Velocity.Dy, i));
        }
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class ArchetypeAttribute : Attribute
{
    public ulong Bit { get; }

    public ArchetypeAttribute(params Type[] types)
    {
        Bit = Register.GetComponentBit(types);
    }
}