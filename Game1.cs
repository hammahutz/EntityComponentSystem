using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EntityComponentSystem;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;
    private int amount = 230_000;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _world = new World(amount)
            .RegisterArchetype(new Actor(amount, Content.Load<Texture2D>("pip")))
            .RegisterSystem(new MovementSystem())
            .RegisterSystem(new DrawingSystem())
            .AddEntity<Actor>(amount);

        Stats.LoadContent(Content.Load<SpriteFont>("font"));
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        // TODO: Add your update logic here
        Stats.Update(gameTime);

        _world.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _world.Draw(_spriteBatch);
        Stats.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
