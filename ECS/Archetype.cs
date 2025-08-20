using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public abstract class Archetype
{
    public List<Entity> Entities { get; protected set; } = new List<Entity>();
    public Entity AddEntity(EntityRegister entityRegister)
    {
        var entity = entityRegister.FetchEntity();
        Entities.Add(entity);
        return entity;
    }
}


