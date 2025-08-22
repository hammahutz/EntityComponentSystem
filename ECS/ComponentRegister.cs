using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

public static class ComponentRegister
{
    private static Dictionary<Type, ulong> _componentIds = new Dictionary<Type, ulong>();
    private static int _nextComponentBit = 0;


    public static void RegisterComponents()
    {
        Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ComponentAttribute>() != null)
            .ToList()
            .ForEach(t =>
            {
                _componentIds[t] = 1UL << _nextComponentBit;
                _nextComponentBit++;
            });
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
    where T1 : Component where T2 : Component => GetComponentBit<T1>() | GetComponentBit<T2>();
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
public class ComponentAttribute : Attribute
{
}