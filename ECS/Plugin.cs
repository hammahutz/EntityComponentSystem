public abstract class Plugin
{
    private World _world;

    public Plugin(int capacity) => _world = new World(capacity);
    public Plugin(World world) => _world = world;

    public virtual Plugin RegisterArchetype(Archetype archetype) => this;

    public virtual Plugin RegisterSystem(ISystemUpdate systemUpdate) => this;
    public virtual Plugin RegisterUpdate(ISystemDraw systemDraw) => this;

    public World Build() => _world;
}