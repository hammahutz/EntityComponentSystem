using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class MovementSystem
{
    public void Update(GameTime gameTime, World world)
    {
        var posves = world.GetArchetypes<PosVes>();

        int smidWidth = Vector<float>.Count;
        int n = posves.Entities.Count;
        Parallel.For(0, n / smidWidth, chunk =>
        {
            int i = chunk * smidWidth;

            Vector<float> posX = new Vector<float>(posves.Position.X, i);
            Vector<float> posY = new Vector<float>(posves.Position.Y, i);
            Vector<float> velX = new Vector<float>(posves.Velocity.X, i);
            Vector<float> velY = new Vector<float>(posves.Velocity.Y, i);

            posX += velX * gameTime.ElapsedGameTime.Milliseconds;
            posY += velY * gameTime.ElapsedGameTime.Milliseconds;

            posX.CopyTo(posves.Position.X, i);
            posY.CopyTo(posves.Position.Y, i);
        });

        for (int i = n - n % smidWidth; i < n; i++)
        {
            posves.Position.X[i] += posves.Velocity.X[i] * gameTime.ElapsedGameTime.Milliseconds;
            posves.Position.Y[i] += posves.Velocity.Y[i] * gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}