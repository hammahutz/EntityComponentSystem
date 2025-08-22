using System;
using System.Collections.Generic;

public static class ResourceRegister
{
    public static Dictionary<(Type, string), object> _resource = new();

    public static void Register<T>(string name, T resource)
    {
        var key = (typeof(T), name);
        if (_resource.ContainsKey(key))
        {
            throw new InvalidOperationException(
                $"Resource '{name}' of type {typeof(T)} already registered."
            );
        }

        _resource[key] = resource!;
    }

    public static T Get<T>(string name)
    {
        var key = (typeof(T), name);
        if (_resource.TryGetValue(key, out var resource))
        {
            return (T)resource;
        }
        throw new KeyNotFoundException($"Resource '{name}' of type {typeof(T)} not found.");
    }
}

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = true,
    Inherited = true
)]
public class ResourceAttribute : Attribute { }
