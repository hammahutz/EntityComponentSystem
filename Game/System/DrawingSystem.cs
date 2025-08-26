using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

[Systems]
public class DrawingSystem : ISystemDraw
{
    public void Draw(SpriteBatch spriteBatch, World world)
    {
        world.QueryWith<Position, Sprite>(
            (entitys, position, sprite) =>
            {
                for (int i = 0; i < entitys.Length; i++)
                {
                    spriteBatch.Draw(
                        sprite.Texture,
                        new Vector2(position.X[i], position.Y[i]),
                        null,
                        sprite.Colors[i],
                        sprite.Rotations[i],
                        sprite.Origins[i],
                        sprite.Scale[i],
                        sprite.SpriteEffects[i],
                        sprite.LayerDepths[i]
                    );
                }
            }
        );
    }
}
