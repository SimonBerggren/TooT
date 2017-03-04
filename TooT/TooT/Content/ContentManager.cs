using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    public static class ContentManager
    {
        public static Texture2D Dot { get; private set; }
        public static SpriteFont Font { get; private set; }
        public static Texture2D MenuBackground { get; private set; }

        public static void LoadContent(Microsoft.Xna.Framework.Content.ContentManager _Content)
        {
            MenuBackground = _Content.Load<Texture2D>("MenuBackground");
            Dot = _Content.Load<Texture2D>("Dot");
            Font = _Content.Load<SpriteFont>("PixelFont");
        }
    }
}
