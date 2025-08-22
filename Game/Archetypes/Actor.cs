using System;
using Microsoft.Xna.Framework.Graphics;

public class Actor : Archetype
{
    public Position Position;
    public Velocity Velocity;
    public Sprite Sprite;

    public override ulong Mask => ComponentRegister.GetComponentBit<Position, Velocity, Sprite>();

    public Actor(int capacity, Texture2D texture)
        : base(capacity)
    {
        Position = new Position(capacity);
        Velocity = new Velocity(capacity);
        Sprite = new Sprite(capacity, texture);
    }

    public override T GetComponent<T>() =>
        typeof(T) switch
        {
            Type t when t == typeof(Position) => Position as T,
            Type t when t == typeof(Velocity) => Velocity as T,
            Type t when t == typeof(Sprite) => Sprite as T,
            _ => null
        };

    protected override void AddComponentToEntity(int index)
    {
        Position.AddToEntity(index);
        Velocity.AddToEntity(index);
        Sprite.AddToEntity(index);
    }
}
