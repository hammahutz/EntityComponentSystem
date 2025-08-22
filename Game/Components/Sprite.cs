using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite : Component
{
    public Texture2D Texture { get; private set; }
    public Color[] Colors;
    public float[] Rotations;
    public Vector2[] Origins;
    public Vector2[] Scale;
    public SpriteEffects[] SpriteEffects;
    public float[] LayerDepths;

    public Sprite(int capacity, Texture2D texture)
        : base(capacity)
    {
        Texture = texture;

        Colors = new Color[capacity];
        Rotations = new float[capacity];
        Origins = new Vector2[capacity];
        Scale = new Vector2[capacity];
        SpriteEffects = new SpriteEffects[capacity];
        LayerDepths = new float[capacity];
    }

    public override void AddToEntity(int index)
    {
        Colors[index] = Color.White;
        Rotations[index] = 0f;
        Origins[index] = Vector2.Zero;
        Scale[index] = Vector2.One;
        SpriteEffects[index] = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
    }
}
