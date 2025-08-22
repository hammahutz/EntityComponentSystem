using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ArchetypeRegister
{
    private List<Archetype> _archetypes = new List<Archetype>();

    public void RegisterArchetypes(Archetype archetype) => _archetypes.Add(archetype);

    public T GetArchetype<T>()
        where T : Archetype
    {
        foreach (var archetype in _archetypes)
        {
            if (archetype is T t)
            {
                return t;
            }
        }
        throw new InvalidOperationException($"Archetype of type {typeof(T).Name} not found.");
    }

    // internal T[] QueryWith<T>() where T : Archetype
    // {
    //     for(int i = 0; i < _archetypes.Count; i++)
    //     {
    //         if (_archetypes[i] is T t)
    //         {
    //             return _archetypes.OfType<T>().ToArray();
    //         }
    //     }
    // }
}