using Microsoft.Xna.Framework.Graphics;

public class DrawingSystem : ISystemDraw
{
    public void Draw(SpriteBatch spriteBatch, World world)
    {
        world.QueryWith<Position, Sprite>((position, sprite) =>
        {
            System.Console.WriteLine(position);
        });
    }
}