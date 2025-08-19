using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Register
{
    private static Dictionary<Type, ulong> _componentIds = new Dictionary<Type, ulong>();
    private Dictionary<ulong, Archetype> _archetypeIds = new Dictionary<ulong, Archetype>();
    private static int _nextComponentBit = 0;
    public ulong this[Type t] => _componentIds[t];

    public Register()
    {
        RegisterComponents();
    }

    private static void RegisterComponents() => Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ComponentAttribute>() != null)
            .ToList()
            .ForEach(t =>
            {
                _componentIds[t] = 1UL << _nextComponentBit;
                _nextComponentBit++;
            });



    public Register RegisterArchetype(Archetype archetype)
    {
        if (_archetypeIds.ContainsKey(archetype.Bit))
        {
            throw new InvalidOperationException($"Archetype with bit {archetype.Bit} already registered.");
        }
        _archetypeIds[archetype.Bit] = archetype;
        return this;
    }

    private T GetArchetypes<T> ()
        where T : Archetype
    {
        if (_archetypeIds.TryGetValue(Activator.CreateInstance<T>().Bit, out Archetype archetype))
        {
            return (T)archetype;
        }
        else
        {
            throw new InvalidOperationException($"Archetype of type {typeof(T).Name} not found.");
        }

    }


    public Archetype GetArchetype(ulong bit)
    {
        if (_archetypeIds.TryGetValue(bit, out Archetype archetype))
        {
            return archetype;
        }
        else
        {
            throw new InvalidOperationException($"Archetype with bit {bit} not found.");
        }
    }
    public Archetype GetArchetype<T1>()
        where T1 : Component => GetArchetype(GetComponentBit<T1>());
    public Archetype GetArchetype<T1, T2>()
        where T1 : Component where T2 : Component => GetArchetype(GetComponentBit<T1, T2>());

    public static ulong GetComponentBit(params Type[] types)
    {
        ulong bit = 0;
        foreach (var type in types)
        {
            if (_componentIds.TryGetValue(type, out ulong componentBit))
            {
                bit |= componentBit;
            }
            else
            {
                throw new InvalidOperationException($"Component type {type.Name} not registered.");
            }
        }
        return bit;
    }


    public static ulong GetComponentBit<T1>()
    where T1 : Component
    {
        if (_componentIds.TryGetValue(typeof(T1), out ulong bit))
        {
            return bit;
        }
        else
        {
            throw new InvalidOperationException(
                $"Could not register component type {typeof(T1).Name}."
            );
        }
    }

    public static ulong GetComponentBit<T1, T2>()
    where T1 : Component where T2 : Component => GetComponentBit<T1>() | GetComponentBit<T2>();
}