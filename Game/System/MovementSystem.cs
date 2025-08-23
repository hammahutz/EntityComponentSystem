using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class MovementSystem : ISystemUpdate
{
    public void Update(GameTime gameTime, World world)
    {
        world.QueryWith<Position, Velocity>(
            (entities, position, velocity) =>
            {
                int smidWidth = Vector<float>.Count;
                int n = entities.Length;
                Parallel.For(
                    0,
                    n / smidWidth,
                    chunk =>
                    {
                        int i = chunk * smidWidth;

                        Vector<float> posX = new Vector<float>(position.X, i);
                        Vector<float> posY = new Vector<float>(position.Y, i);
                        Vector<float> velX = new Vector<float>(velocity.X, i);
                        Vector<float> velY = new Vector<float>(velocity.Y, i);

                        posX += velX * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        posY += velY * (float)gameTime.ElapsedGameTime.TotalSeconds;

                        posX.CopyTo(position.X, i);
                        posY.CopyTo(position.Y, i);
                    }
                );

                for (int i = n - n % smidWidth; i < n; i++)
                {
                    position.X[i] += velocity.X[i] * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    position.Y[i] += velocity.Y[i] * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        );
    }
}
