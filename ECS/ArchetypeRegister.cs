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


    public IEnumerable<T1> QueryWith<T1>() where T1 : Component
    {
        ulong queryMask = ComponentRegister.GetComponentBit<T1>();
        for (int i = 0; i < _archetypes.Count; i++)
        {
            if ((_archetypes[i].Mask & queryMask) == queryMask)
            {
                yield return _archetypes[i].GetComponent<T1>();
            }
        }
    }

    public IEnumerable<(T1, T2)> QueryWithEnumerable<T1, T2>()
        where T1 : Component
        where T2 : Component
    {
        ulong queryMask = ComponentRegister.GetComponentBit<T1, T2>();
        for (int i = 0; i < _archetypes.Count; i++)
        {
            if ((_archetypes[i].Mask & queryMask) == queryMask)
            {
                yield return (_archetypes[i].GetComponent<T1>(), _archetypes[i].GetComponent<T2>());
            }
        }
    }

    public void QueryWithAction<T1, T2>(Action<Entity[], T1, T2> action)
        where T1 : Component
        where T2 : Component
    {
        ulong queryMask = ComponentRegister.GetComponentBit<T1, T2>();
        for (int i = 0; i < _archetypes.Count; i++)
        {
            if ((_archetypes[i].Mask & queryMask) == queryMask)
            {
                action(_archetypes[i].Entities, _archetypes[i].GetComponent<T1>(), _archetypes[i].GetComponent<T2>());
            }
        }
    }
}