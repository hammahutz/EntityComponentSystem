using Microsoft.Xna.Framework;

public class MovementSystem
{
    public void Update(GameTime gameTime, World world)
    {
        // foreach (var (entity, position, velocity) in world.Query<Position, Velocity>())
        // {
        //     // Create a local copy of position to modify
        //     var updatedPosition = position;

        //     // Update the position based on velocity and elapsed time
        //     updatedPosition.X += velocity.Speed * velocity.DirectionX * (float)gameTime.ElapsedGameTime.TotalSeconds;
        //     updatedPosition.Y += velocity.Speed * velocity.DirectionY * (float)gameTime.ElapsedGameTime.TotalSeconds;

        //     // Update the entity's position component in the world
        //     world.AddComponent(entity, updatedPosition);

        //     System.Console.WriteLine($"Entity {entity.Id} moved to Position({updatedPosition.X}, {updatedPosition.Y})");
        // }
    }
}