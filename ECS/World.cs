using System;
using System.Collections.Generic;

public class World
{
    private int _nextEntityId = 0;
    // private readonly Dictionary<int, Dictionary<Type, IComponent>> _entities = new();


    // public Entity CreateEntity()
    // {
    //     var entity = new Entity(_nextEntityId++);
    //     _entities[entity.Id] = new Dictionary<Type, IComponent>();
    //     return entity;
    // }

    // public void AddComponent<T>(Entity e, T component) where T : struct, IComponent => _entities[e.Id][typeof(T)] = component;
    // public T GetComponent<T>(Entity e) where T : struct, IComponent => (T)_entities[e.Id][typeof(T)];
    // public IEnumerable<(Entity, T1, T2)> Query<T1, T2>()
    //             where T1 : struct, IComponent
    //             where T2 : struct , IComponent
    // {
    //     foreach (var kvp in _entities)
    //     {
    //         var comps = kvp.Value;
    //         if (comps.ContainsKey(typeof(T1)) && comps.ContainsKey(typeof(T2)))
    //         {
    //             yield return (new Entity(kvp.Key), (T1)comps[typeof(T1)], (T2)comps[typeof(T2)]);
    //         }
    //     }
    // }
}
