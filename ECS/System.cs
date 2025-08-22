using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ISystemUpdate
{
    public void Update(GameTime gameTime, World world);
}

public interface ISystemDraw
{
    public void Draw(SpriteBatch spriteBatch, World world);
}
