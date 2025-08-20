using System;
using System.Collections.Generic;
using System.Linq;

public class EntityRegister
{
    private Queue<int> _availableId;

    public EntityRegister() =>
        _availableId = new Queue<int>(Enumerable.Range(0, 5000));

    public Entity FetchEntity()
    {
        if (_availableId.Count == 0)
            throw new InvalidOperationException("No available entity IDs.");

        int id = _availableId.Dequeue();
        return new Entity((int)id);
    }

    public void ReleaseEntity(Entity entity)
    {
        _availableId.Enqueue(entity.Id);
    }
}