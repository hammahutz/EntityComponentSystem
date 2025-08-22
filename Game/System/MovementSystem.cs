using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class MovementSystem : ISystemUpdate
{
    public void Update(GameTime gameTime, World world)
    {
        var posVel = world.GetArchetype<PosVel>();

        int smidWidth = Vector<float>.Count;
        int n = posVel.Entities.Count;
        Parallel.For(0, n / smidWidth, chunk =>
        {
            int i = chunk * smidWidth;

            Vector<float> posX = new Vector<float>(posVel.Position.X, i);
            Vector<float> posY = new Vector<float>(posVel.Position.Y, i);
            Vector<float> velX = new Vector<float>(posVel.Velocity.X, i);
            Vector<float> velY = new Vector<float>(posVel.Velocity.Y, i);

            posX += velX * gameTime.ElapsedGameTime.Milliseconds;
            posY += velY * gameTime.ElapsedGameTime.Milliseconds;

            posX.CopyTo(posVel.Position.X, i);
            posY.CopyTo(posVel.Position.Y, i);
            System.Console.WriteLine($"Updated Position: ({posVel.Position.X[i]}, {posVel.Position.Y[i]})");
        });

        for (int i = n - n % smidWidth; i < n; i++)
        {
            posVel.Position.X[i] += posVel.Velocity.X[i] * gameTime.ElapsedGameTime.Milliseconds;
            posVel.Position.Y[i] += posVel.Velocity.Y[i] * gameTime.ElapsedGameTime.Milliseconds;

            System.Console.WriteLine($"Updated Position: ({posVel.Position.X[i]}, {posVel.Position.Y[i]})");
        }
    }

}