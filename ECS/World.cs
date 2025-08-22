using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class World
{
    public EntityRegister Entities { get; private set; }
    public ArchetypeRegister Archetypes { get; private set; }
    public SystemRegister Systems { get; private set; }

    public World(int capacity)
    {
        ComponentRegister.RegisterComponents();
        Entities = new EntityRegister(capacity);
        Archetypes = new ArchetypeRegister();
        Systems = new SystemRegister();
    }

    public World RegisterArchetype(Archetype archetype)
    {
        Archetypes.RegisterArchetypes(archetype);
        return this;
    }
    public World AddEntity<T>(int capacity = 1)
        where T : Archetype
    {
        Archetypes.GetArchetype<T>().AddEntity(Entities, capacity);
        return this;
    }
    public World RegisterSystem(ISystemUpdate system)
    {
        Systems.RegisterSystems(system);
        return this;
    }

    public World RegisterSystem(ISystemDraw system)
    {
        Systems.RegisterSystems(system);
        return this;
    }

    public T GetArchetype<T>()
        where T : Archetype => Archetypes.GetArchetype<T>();


    public void Update(GameTime gameTime) => Systems.Update(gameTime, this);
    public void Draw(SpriteBatch spriteBatch) => Systems.Draw(spriteBatch, this);


    public IEnumerable<(T1, T2)> QueryWith<T1, T2>()
    where T1 : Component
    where T2 : Component => Archetypes.QueryWithEnumerable<T1, T2>();

    public void QueryWith<T1, T2>(Action<Entity[], T1, T2> action)
    where T1 : Component
    where T2 : Component => Archetypes.QueryWithAction(action);

}