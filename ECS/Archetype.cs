using System;
using System.Collections.Generic;


public abstract class Archetype
{
    private int current = 0;


    public Entity[] Entities { get; set; }
    public Archetype(int capacity)
    {
        Entities = new Entity[capacity];
    }
    public void AddEntity(EntityRegister entityRegister, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Entities[current] = entityRegister.FetchEntity();
            current++;
        }
    }

    public abstract T GetComponent<T>() where T : Component;




    public abstract ulong Mask { get; }

}
