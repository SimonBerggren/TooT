using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal static class ContentManager
    {
        public static AnimatedTexture Circle(GameObject _Owner) { return new AnimatedTexture(mCircle, _Owner, null); }
        private static AnimatedTexture mCircle;
        public static AnimatedTexture TestSheet(GameObject _Owner) { return new AnimatedTexture(mTestSheet, _Owner, null); }
        private static AnimatedTexture mTestSheet;
        internal static Texture2D Dot { get; private set; }
        internal static SpriteFont Font { get; private set; }
        internal static Texture2D MenuBackground { get; private set; }

        internal static void LoadContent(Microsoft.Xna.Framework.Content.ContentManager _Content)
        {
            MenuBackground = _Content.Load<Texture2D>("MenuBackground");
            Dot = _Content.Load<Texture2D>("Dot");
            Font = _Content.Load<SpriteFont>("PixelFont");
            mCircle = new AnimatedTexture(_Content.Load<Texture2D>("FancyCircle"), new Vector2(594, 594), new Vector2(100, 100));
            mCircle.AddAnimation(AnimationName.Idle, new Animation(new IntVector2(0, 0), 1, 1, false, false, false, true));

            mTestSheet = new AnimatedTexture(_Content.Load<Texture2D>("TestSheet"), new Vector2(100, 100), new Vector2(100, 100));
            mTestSheet.AddAnimation(AnimationName.SpecialOne, new Animation(new IntVector2(0, 0),6, 0.1, false, false, false, true));
            mTestSheet.AddAnimation(AnimationName.SpecialTwo, new Animation(new IntVector2(0, 1),7, 0.1, false, true, false, true));
            mTestSheet.AddAnimation(AnimationName.SpecialThree, new Animation(new IntVector2(0, 2),7, 0.1, true, false, false, true));

        }
    }
}
