
using Microsoft.Xna.Framework.Graphics;

[Component]
public class Sprite : Component
{

    public Texture2D[] Textures;
    public Sprite(int Capacity) : base(Capacity){}

    protected override void SetArrayCapacity(int capacity)
    {
        Textures = new Texture2D[capacity];
    }
}

