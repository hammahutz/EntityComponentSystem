using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ArchetypeRegister
{
    private Dictionary<Type, Archetype> _archetypeIds = new Dictionary<Type, Archetype>();


    public void RegisterArchetype<T>(T archetype)
    where T: Archetype
    {
        _archetypeIds[typeof(T)] = archetype;
    }

    public T GetArchetypes<T>()
        where T : Archetype
    {
        if (_archetypeIds.TryGetValue(typeof(T), out Archetype archetype))
        {
            return (T)archetype;
        }
        else
        {
            throw new InvalidOperationException($"Archetype of type {typeof(T).Name} not found.");
        }
    }

    public bool Contains<T>()
        where T : Archetype
    {
        return _archetypeIds.ContainsKey(typeof(T));
    }
}