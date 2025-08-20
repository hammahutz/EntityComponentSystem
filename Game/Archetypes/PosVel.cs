using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

public class PosVes : Archetype
{

    public Position Position { get; private set; }
    public Velocity Velocity { get; private set; }

    public PosVes(int capacity)
    {
        Position = new Position(capacity);
        Velocity = new Velocity(capacity);

        for (int i = 0; i < capacity; i++)
        {
            Velocity.X[i] = 1f;
            Velocity.Y[i] = 2f;
        }
    }


    // public PosVes(int capacity)
    // {
    //     Position = new Position(capacity);
    //     Velocity = new Velocity(capacity);
    //     for (int i = 0; i < capacity; i++)
    //     {
    //         Velocity.Set(i, 1f, 2f);
    //     }
    // }

    // public IEnumerable<((float, float), (float, float))> QueryEnumerableSingel()
    // {
    //     for (int i = 0; i < Entities.Count; i++)
    //     {
    //         yield return (Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     }
    // }
    // public IEnumerable<(Vector<float>, Vector<float>, Vector<float>, Vector<float>)> QueryEnumerableSingelSMID()
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     for (int i = 0; i < n / smidWidth; i++)
    //     {
    //         int index = i * smidWidth;
    //         var (x,y) = Position.GetVector(index);
    //         var (xD,yD) = Velocity.GetVector(index);
    //         yield return (x, y, xD, yD);
    //     }

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         var (x,y) = Position.GetVector(i);
    //         var (xD,yD) = Velocity.GetVector(i);
    //         yield return (x, y, xD, yD);
    //     }
    // }

    // public void QueryActionSingle(Action<(float, float), (float, float)> action)
    // {
    //     for (int i = 0; i < Entities.Count; i++)
    //     {
    //         action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     }
    // }

    // public void QueryActionSingleSMID(Func<Vector<float>, Vector<float>, Vector<float>> queryX, Func<Vector<float>, Vector<float>, Vector<float>> queryY)
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     for (int i = 0; i < n / smidWidth; i++)
    //     {
    //         int index = i * smidWidth;
    //         var resultX = queryX(new Vector<float>(Position._x, index), new Vector<float>(Velocity.Dx, index));
    //         var resultY = queryY(new Vector<float>(Position._y, index), new Vector<float>(Velocity.Dy, index));

    //         Position.SetVector(index, resultX, resultY);
    //     }

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         var resultX = queryX(new Vector<float>(Position._x, i), new Vector<float>(Velocity.Dx, i));
    //         var resultY = queryY(new Vector<float>(Position._y, i), new Vector<float>(Velocity.Dy, i));

    //         Position.SetVector(i, resultX, resultY);
    //     }
    //     System.Console.WriteLine($"Updated Position: ({Position._x[0]}, {Position._y[0]})");
    // }
    // public void QueryActionParallel(Action<(float, float), (float, float)> action)
    // {
    //     Parallel.For(0, Entities.Count, i =>
    //     {
    //         action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     });
    // }
    // public void QueryActionParallelSMID(Action<Vector<float>, Vector<float>, Vector<float>, Vector<float>> action)
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     Parallel.For(0, n / smidWidth, chunk =>
    //     {
    //         int i = chunk * smidWidth;

    //         Vector<float> posX = new Vector<float>(Position._x, i);
    //         Vector<float> posY = new Vector<float>(Position._y, i);
    //         Vector<float> velX = new Vector<float>(Velocity.Dx, i);
    //         Vector<float> velY = new Vector<float>(Velocity.Dy, i);

    //         action(new Vector<float>(Position._x, i),
    //                new Vector<float>(Position._y, i),
    //                new Vector<float>(Velocity.Dx, i),
    //                new Vector<float>(Velocity.Dy, i));
    //     });

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         action(new Vector<float>(Position._x, i),
    //                new Vector<float>(Position._y, i),
    //                new Vector<float>(Velocity.Dx, i),
    //                new Vector<float>(Velocity.Dy, i));
    //     }
    // }
    // public IEnumerable<((float, float), (float, float))> QueryEnumerableSingel()
    // {
    //     for (int i = 0; i < Entities.Count; i++)
    //     {
    //         yield return (Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     }
    // }
    // public IEnumerable<(Vector<float>, Vector<float>, Vector<float>, Vector<float>)> QueryEnumerableSingelSMID()
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     for (int i = 0; i < n / smidWidth; i++)
    //     {
    //         int index = i * smidWidth;
    //         var (x,y) = Position.GetVector(index);
    //         var (xD,yD) = Velocity.GetVector(index);
    //         yield return (x, y, xD, yD);
    //     }

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         var (x,y) = Position.GetVector(i);
    //         var (xD,yD) = Velocity.GetVector(i);
    //         yield return (x, y, xD, yD);
    //     }
    // }

    // public void QueryActionSingle(Action<(float, float), (float, float)> action)
    // {
    //     for (int i = 0; i < Entities.Count; i++)
    //     {
    //         action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     }
    // }

    // public void QueryActionSingleSMID(Func<Vector<float>, Vector<float>, Vector<float>> queryX, Func<Vector<float>, Vector<float>, Vector<float>> queryY)
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     for (int i = 0; i < n / smidWidth; i++)
    //     {
    //         int index = i * smidWidth;
    //         var resultX = queryX(new Vector<float>(Position._x, index), new Vector<float>(Velocity.Dx, index));
    //         var resultY = queryY(new Vector<float>(Position._y, index), new Vector<float>(Velocity.Dy, index));

    //         Position.SetVector(index, resultX, resultY);
    //     }

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         var resultX = queryX(new Vector<float>(Position._x, i), new Vector<float>(Velocity.Dx, i));
    //         var resultY = queryY(new Vector<float>(Position._y, i), new Vector<float>(Velocity.Dy, i));

    //         Position.SetVector(i, resultX, resultY);
    //     }
    //     System.Console.WriteLine($"Updated Position: ({Position._x[0]}, {Position._y[0]})");
    // }
    // public void QueryActionParallel(Action<(float, float), (float, float)> action)
    // {
    //     Parallel.For(0, Entities.Count, i =>
    //     {
    //         action(Position[Entities[i].Id], Velocity[Entities[i].Id]);
    //     });
    // }
    // public void QueryActionParallelSMID(Action<Vector<float>, Vector<float>, Vector<float>, Vector<float>> action)
    // {
    //     int smidWidth = Vector<float>.Count;
    //     int n = Entities.Count;
    //     Parallel.For(0, n / smidWidth, chunk =>
    //     {
    //         int i = chunk * smidWidth;

    //         Vector<float> posX = new Vector<float>(Position._x, i);
    //         Vector<float> posY = new Vector<float>(Position._y, i);
    //         Vector<float> velX = new Vector<float>(Velocity.Dx, i);
    //         Vector<float> velY = new Vector<float>(Velocity.Dy, i);

    //         action(new Vector<float>(Position._x, i),
    //                new Vector<float>(Position._y, i),
    //                new Vector<float>(Velocity.Dx, i),
    //                new Vector<float>(Velocity.Dy, i));
    //     });

    //     for (int i = n - n % smidWidth; i < n; i++)
    //     {
    //         action(new Vector<float>(Position._x, i),
    //                new Vector<float>(Position._y, i),
    //                new Vector<float>(Velocity.Dx, i),
    //                new Vector<float>(Velocity.Dy, i));
    //     }
    // }
}