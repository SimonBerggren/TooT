using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal class GameObject
    {
        private Room mParent;
        internal Vector2 Position { get {return mPosition; } }
        protected Vector2 mPosition;
        AnimatedTexture mTexture;
        private float mLayerDepth;
        private SpriteEffects mSpriteEffect;
        private float mScale;
        private Vector2 mOrigin;
        private float mRotation;
        private Color mColor;

        internal GameObject(Vector2 _Pos, float _Scale, Texture2D _Texture)
        {
            mPosition = _Pos;
            mScale = _Scale;
            mTexture = new AnimatedTexture(_Texture, _Texture.GetSize());
            mLayerDepth = 1.0f;
            mSpriteEffect = SpriteEffects.None;
            mScale = 1.0f;
            mOrigin = mTexture.Origin;
            mRotation = 0.0f;
            mColor = Color.White;
        }

        internal virtual void Draw(SpriteBatch _SB)
        {
            if (mParent == null) return;
            _SB.Draw(mTexture.Texture, Position + mParent.Anchor, mTexture.SourceRec, mColor, mRotation, mOrigin, mScale, mSpriteEffect, mLayerDepth);
        }

        internal virtual void Update(GameTime _GT)
        {
            mTexture.Animate(_GT);
        }

        internal virtual void SetParent(Room _NewParent)
        {
            mParent = _NewParent;
        }

    }
}