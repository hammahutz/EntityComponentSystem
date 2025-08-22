public abstract class Archetype
{
    public int Count { get; private set; }

    public Entity[] Entities { get; set; }

    public Archetype(int capacity)
    {
        Entities = new Entity[capacity];
    }

    protected abstract void AddComponentToEntity(int index);

    public void AddEntity(EntityRegister entityRegister, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Entities[Count] = entityRegister.FetchEntity();
            AddComponentToEntity(Count);
            Count++;
        }
    }

    public abstract T GetComponent<T>()
        where T : Component;

    public abstract ulong Mask { get; }
}
