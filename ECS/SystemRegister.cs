using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SystemRegister
{
    private List<ISystemUpdate> _updateSystems = [];
    private List<ISystemDraw> _drawSystems = [];

    public void RegisterSystems(ISystemUpdate system) => _updateSystems.Add(system);
    public void RegisterSystems(ISystemDraw system) => _drawSystems.Add(system);

    public void Update(GameTime gameTime, World world) => _updateSystems.ForEach(system => system.Update(gameTime, world));
    public void Draw(SpriteBatch spriteBatch, World world) => _drawSystems.ForEach(system => system.Draw(spriteBatch, world));
}