using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ComponentRegister
{
    private static Dictionary<Type, ulong> _componentIds = new Dictionary<Type, ulong>();
    private static int _nextComponentBit = 0;

    public static void RegisterComponents()
    {
        int count = 1;
        Console.WriteLine("----------Components----------");
        Console.WriteLine($"Index\tMask\tName");
        Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ComponentAttribute>() != null && !t.IsAbstract)
            .ToList()
            .ForEach(t =>
            {
                _componentIds[t] = 1UL << _nextComponentBit;
                Console.WriteLine($"{count}\t{_componentIds[t]}\t{t.Name}");
                count++;
                _nextComponentBit++;
            });
        Console.WriteLine();
    }

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
        where T1 : Component => GetComponentBit(typeof(T1));

    public static ulong GetComponentBit<T1, T2>()
        where T1 : Component
        where T2 : Component => GetComponentBit(typeof(T1), typeof(T2));

    public static ulong GetComponentBit<T1, T2, T3>()
        where T1 : Component
        where T2 : Component
        where T3 : Component => GetComponentBit(typeof(T1), typeof(T2), typeof(T3));
}

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = true,
    Inherited = true
)]
public class ComponentAttribute : Attribute { }
