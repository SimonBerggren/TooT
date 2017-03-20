using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal static class ContentManager
    {
        public static Texture2D Circle { get; private set; }
        internal static Texture2D Dot { get; private set; }
        internal static SpriteFont Font { get; private set; }
        internal static Texture2D MenuBackground { get; private set; }

        internal static void LoadContent(Microsoft.Xna.Framework.Content.ContentManager _Content)
        {
            MenuBackground = _Content.Load<Texture2D>("MenuBackground");
            Dot = _Content.Load<Texture2D>("Dot");
            Font = _Content.Load<SpriteFont>("PixelFont");
            Circle = _Content.Load<Texture2D>("FancyCircle");
        }
    }
}
