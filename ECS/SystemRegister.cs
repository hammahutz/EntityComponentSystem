using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SystemRegister
{
    private DynamicArray<ISystemUpdate> _updateSystems = new DynamicArray<ISystemUpdate>();

    private DynamicArray<ISystemDraw> _drawSystems = new DynamicArray<ISystemDraw>();

    public void RegisterSystems()
    {
        int index = 1;
        string output = $"----------Systems----------\nIndex\tName\t\tTypes\n";

        Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<SystemsAttribute>() != null && !t.IsInterface)
            .ToList()
            .ForEach(t =>
            {
                List<string> inter = new List<string>();

                var instance = Activator.CreateInstance(t);
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(typeof(ISystemUpdate)))
                {
                    _updateSystems.Add(instance as ISystemUpdate);
                    inter.Add($"{nameof(ISystemUpdate)}");
                }

                if (interfaces.Contains(typeof(ISystemDraw)))
                {
                    inter.Add(nameof(ISystemDraw));
                    _drawSystems.Add(instance as ISystemDraw);
                }

                output += $"{index}\t{t.Name}\t";
                output += $"{inter[0]}";
                for (int i = 1; i < inter.Count; i++)
                {
                    output += $"\n\t\t{inter[i]}";
                }
                output += "\n";
            });

        Console.WriteLine(output);
        index++;
        Console.WriteLine();
    }

    public void RegisterSystems(ISystemUpdate system)
    {
        _updateSystems.Add(system);
    }

    public void RegisterSystems(ISystemDraw system)
    {
        _drawSystems.Add(system);
    }

    public void Update(GameTime gameTime, World world) =>
        _updateSystems.ForEach(system => system.Update(gameTime, world));

    public void Draw(SpriteBatch spriteBatch, World world) =>
        _drawSystems.ForEach(system => system.Draw(spriteBatch, world));
}
