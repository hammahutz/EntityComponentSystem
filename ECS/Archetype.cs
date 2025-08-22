using System;
using System.Collections.Generic;

public abstract class Archetype
{
    public Archetype() { }

    public List<Entity> Entities { get; protected set; } = new List<Entity>();
    public Entity[] AddEntity(EntityRegister entityRegister, int amount = 1)
    {
        Entity[] entities = new Entity[amount];
        for (int i = 0; i < amount; i++)
        {
            Entities.Add(entityRegister.FetchEntity());
        }
        return entities;
    }
   
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class ArchetypeAttribute : Attribute
{ }
