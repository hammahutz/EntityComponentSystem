using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class World
{
    private ArchetypeRegister _archetypeRegister = new ArchetypeRegister();
    private EntityRegister _entityRegister = new EntityRegister();

    public World RegisterArchetype<T>(T archetype)
    where T : Archetype
    {
        _archetypeRegister.RegisterArchetype(archetype);
        return this;
    }

    public T GetArchetypes<T>()
        where T : Archetype => _archetypeRegister.GetArchetypes<T>();

    public Entity[] AddEntity<T>(int capacity = 1)
        where T : Archetype
    {
        Entity[] entities = new Entity[capacity];
        if (!_archetypeRegister.Contains<T>())
        {
            throw new InvalidOperationException($"Archetype of type {typeof(T).Name} not registered.");
        }
        for (int i = 0; i < capacity; i++)
        {
            entities[i] = GetArchetypes<T>().AddEntity(_entityRegister);
        }
        return entities;
    }


}