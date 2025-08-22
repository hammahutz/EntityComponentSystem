using System;
using System.Collections.Generic;
using System.Linq;

public class EntityRegister
{
    private Queue<int> _availableId;

    public EntityRegister(int count = Global.MAX_ENTITIES) =>
        _availableId = new Queue<int>(Enumerable.Range(0, count));

    public Entity FetchEntity()
    {
        if (_availableId.Count == 0)
            throw new InvalidOperationException("No available entity IDs.");

        int id = _availableId.Dequeue();
        return new Entity(id);
    }

    public void ReleaseEntity(Entity entity)
    {
        _availableId.Enqueue(entity.Id);
    }
}