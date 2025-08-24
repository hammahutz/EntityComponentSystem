using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class Stats
{
    public const int ROLLING_SIZE = 60;
    private static Queue<float> _rollingFPS = new Queue<float>();

    public static float FPS { get; private set; } = 0.0f;
    public static float MinFPS { get; private set; } = 0.0f;
    public static float MaxFPS { get; private set; } = 0.0f;
    public static float AverageFPS { get; private set; } = 0.0f;
    public static bool IsRunningSlow { get; private set; } = false;
    public static int NbUpdateCalled { get; private set; } = 0;
    public static int NbDrawCalled { get; private set; } = 0;
    public static string TotalTime { get; private set; } = "";

    private static SpriteFont _spriteFont;
    private static string _output = string.Empty;

    public static void LoadContent(SpriteFont spriteFont) => _spriteFont = spriteFont;

    public static void Update(GameTime gameTime)
    {
        NbUpdateCalled++;
        FPS = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;
        _rollingFPS.Enqueue(FPS);

        if (_rollingFPS.Count > ROLLING_SIZE)
        {
            _rollingFPS.Dequeue();
            var sum = 0.0f;
            MaxFPS = float.MinValue;
            MinFPS = float.MaxValue;

            foreach (var fps in _rollingFPS)
            {
                sum += fps;
                if (fps > MaxFPS)
                    MaxFPS = fps;
                if (fps < MinFPS)
                    MinFPS = fps;
            }
            AverageFPS = sum / _rollingFPS.Count;
        }
        else
        {
            AverageFPS = FPS;
            MinFPS = FPS;
            MaxFPS = FPS;
        }

        IsRunningSlow = gameTime.IsRunningSlowly;
        TotalTime = gameTime.TotalGameTime.ToString();

        _output =
            $"FPS: {FPS:F2}\n"
            + $"Average FPS: {AverageFPS:F2}\n\n"
            + $"Is Running Slow: {IsRunningSlow}\n\n"
            + $"Nb Update Called: {NbUpdateCalled}\n"
            + $"Nb Draw Called: {NbDrawCalled}\n"
            + $"Nb diff {NbUpdateCalled - NbDrawCalled}\n\n"
            + $"Total Time{TotalTime}\n";
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        NbDrawCalled++;

        spriteBatch.DrawString(
            _spriteFont,
            _output,
            new Vector2(10, 10),
            IsRunningSlow ? Color.Red : Color.Green
        );
    }
}
