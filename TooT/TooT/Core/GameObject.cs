﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal abstract class GameObject
    {
        internal Room Parent { get { return mParent; } }
        private Room mParent;
        internal Vector2 Position { get {return mPosition; } }
        protected Vector2 mPosition;
        internal Vector2 Center { get { return mCenter; } }
        protected Vector2 mCenter;
        protected List<AnimatedTexture> mAnimTextures;
        internal float LayerDepth { get { return mLayerDepth; } }
        private float mLayerDepth;
        private SpriteEffects mSpriteEffect;
        internal float Scale { get { return mScale; } }
        private float mScale;
        internal float Rotation { get { return mRotation; } }
        protected float mRotation;
        internal Color? OverrideColor = null;

        internal GameObject(Vector2 _Pos, float _Scale = 1.0f, float _Rotation = 0.0f)
        {
            mPosition = _Pos;
            mScale = _Scale;
            mLayerDepth = 1.0f;
            mRotation = _Rotation;
            mAnimTextures = new List<AnimatedTexture>();
        }

        internal virtual void Draw(SpriteBatch _SB)
        {
            foreach (AnimatedTexture ATex in mAnimTextures)
                ATex.Draw(_SB);
        }

        internal virtual bool Update(GameTime _GT)
        {
            foreach (AnimatedTexture ATex in mAnimTextures)
                ATex.Update(_GT);
            return false;
        }

        internal virtual void SetParent(Room _NewParent)
        {
            mParent = _NewParent;
        }

    }
}