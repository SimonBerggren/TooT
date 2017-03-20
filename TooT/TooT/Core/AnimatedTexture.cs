using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal class AnimatedTexture
    {
        public Texture2D Texture { get; private set; }
        public Rectangle SourceRec { get; private set; }
        public Vector2 Origin { get; private set; }
        private Vector2 mFrameSize;

        internal AnimatedTexture(Texture2D _Texture, Vector2 _FrameSize)
        {
            Texture = _Texture;
            mFrameSize = new Vector2(_FrameSize.intX(), _FrameSize.intY());
            Origin = mFrameSize / 2;
            SourceRec = new Rectangle(0, 0, mFrameSize.intX(), mFrameSize.intY());
        }

        internal Rectangle GetSourceRec()
        {
            throw new NotImplementedException();
        }

        internal void Animate(GameTime _GT)
        {
           // throw new NotImplementedException();
        }
    }
}