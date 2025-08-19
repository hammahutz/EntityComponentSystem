using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EntityComponentSystem;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MovementSystem _movementSystem;
    private Register _register = new Register();

private World _world;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _register = new Register();
        _register.RegisterArchetype(new PosVes(1000));
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    _world = new World();

        // var entity = _world.CreateEntity();
        // _world.AddComponent(entity, new Position { X = 0, Y = 0 });
        // _world.AddComponent(entity, new Velocity { Speed = 100, DirectionX = 1, DirectionY = 0 });

        // Initialize the MovementSystem
        _movementSystem = new MovementSystem();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _movementSystem.Update(gameTime, _world);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
