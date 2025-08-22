using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class World
{
    private EntityRegister _entityRegister = new EntityRegister();
    private ArchetypeRegister _archetypeRegister = new ArchetypeRegister();
    private SystemRegister _systemRegister = new SystemRegister();

    public World RegisterArchetype(Archetype archetype)
    {
        _archetypeRegister.RegisterArchetypes(archetype);
        return this;
    }
    public World AddEntity<T>(int capacity = 1)
        where T : Archetype
    {
        _archetypeRegister.GetArchetype<T>().AddEntity(_entityRegister, capacity);
        return this;
    }
    public World RegisterSystem(ISystemUpdate system)
    {
        _systemRegister.RegisterSystems(system);
        return this;
    }

    public World RegisterSystem(ISystemDraw system)
    {
        _systemRegister.RegisterSystems(system);
        return this;
    }

    public T GetArchetype<T>()
        where T : Archetype => _archetypeRegister.GetArchetype<T>();


    public void Update(GameTime gameTime) => _systemRegister.Update(gameTime, this);
    public void Draw(SpriteBatch spriteBatch) => _systemRegister.Draw(spriteBatch, this);

    // public T[] QueryWith<T> ()
    //     where T : Archetype
    // {
    //     return _archetypeRegister.QueryWith<T>();
    // }
}