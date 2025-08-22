
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Actor : Archetype
{

    public Position Position;
    public Velocity Velocity;
    public Sprite Sprite;

    public override ulong Mask => ComponentRegister.GetComponentBit<Position, Velocity>();

    public Actor(int capacity) : base(capacity)
    {
        Position = new Position(capacity);
        Velocity = new Velocity(capacity);
        Sprite = new Sprite(capacity);
    }

    public override T GetComponent<T>() => typeof(T) switch
    {
        Type t when t == typeof(Position) => Position as T,
        Type t when t == typeof(Velocity) => Velocity as T,
        Type t when t == typeof(Sprite) => Sprite as T,
        _ => null
    };
}

