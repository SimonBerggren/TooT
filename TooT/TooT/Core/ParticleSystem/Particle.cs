using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core.ParticleSystem
{
    class Particle : GameObject
    {
        internal bool ShouldBeRemoved { get { return mLifeSpanRemaining <= 0; } }
        private double mLifeSpanRemaining;
        private double mLifeSpanInitial;
        private double mLifeSpanElapsed { get { return mLifeSpanInitial - mLifeSpanRemaining; } }

        private Vector2 mVelocity;
        private float mMovementSpeed;
        private float mFriction;
        AnimatedTexture mTexture;

        public Particle(Vector2 _Pos, double _LifeSpan, Vector2 _Velocity, float _InitialSpeed, AnimatedTexture _Texture, float _Friction = 0, float _Scale = 1, float _Rotation = 0) : base(_Pos, _Scale, _Rotation)
        {
            mVelocity = _Velocity;
            mLifeSpanInitial = _LifeSpan;
            mLifeSpanRemaining = mLifeSpanInitial;
            mMovementSpeed = _InitialSpeed;
            mPosition = _Pos;
            mFriction = _Friction;
            mTexture = _Texture;
            mTexture.SetNewOwner(this);
        }


        internal override bool Update(GameTime _GT)
        {
            mLifeSpanRemaining = mLifeSpanRemaining.TimerCountDown(_GT);
            mPosition =  mPosition.ApplyVelocity(mVelocity, _GT, mMovementSpeed, 10.00);
            mMovementSpeed.DecreaseSpeed(mFriction, _GT);
            mTexture.Update(_GT);

            return ShouldBeRemoved;
        }

        internal override void Draw(SpriteBatch _SB)
        {
            mTexture.Draw(_SB);
        }

        internal void Kill()
        {
            mLifeSpanRemaining = 0;
        }
    }
}
