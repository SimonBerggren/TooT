using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal class AnimatedTexture
    {
        private GameObject mOwner;
        internal Vector2 Anchor { get; set; }
        private float mOwnerLastRotation;
        internal Dictionary<AnimationName, Animation> Animations { get; }
        private Animation mCurrentAnimation;
        private Animation CurrentAnimation { get { return mCurrentAnimation; } set { mCurrentAnimation = value; ResetAnimation(); } }
        private AnimationName? mNextAnimationName;
        internal double AnimationSpeedMultiplier = 1.0;
        internal Color Color { get; set; }
        private Texture2D mTexture;
        public Rectangle SourceRec { get; private set; }
        public Vector2 Origin { get; private set; }
        private IntVector2 mFrameSize;
        internal bool ShouldAnimate { get; set; }
        private Vector2 mDrawSize;
        internal Vector2 DrawSize { get { return mDrawSize; } set { mDrawSize = value; CalculateScale(); CalculateOrigin(); } }
        internal Vector2 Scale { get { return mScale; } }
        private Vector2 mScale;
        internal float Rotation;
        internal SpriteEffects Effect;
        internal float LayerDepth;


        ///Animation Variables 
        private double mAnimationTimer;
        private int FrameIndex { get { return mFrameIndex; } set { mFrameIndex = value; UpdateSourceRecPosition(); } }
        private int mFrameIndex;
        private IntVector2 mFramePosition;
        private bool mGoingRight;

        internal AnimatedTexture(Texture2D _Texture, Vector2 _FrameSize, Vector2 _DrawSize)
        {
            mTexture = _Texture;
            mFrameSize = new IntVector2(_FrameSize.intX(), _FrameSize.intY());
            SourceRec = new Rectangle(0, 0, mFrameSize.X, mFrameSize.Y);
            Animations = new Dictionary<AnimationName, Animation>();
            Color = Color.White;
            DrawSize = _DrawSize;
        }

        internal AnimatedTexture(AnimatedTexture _Source, GameObject _Owner, Vector2? _Anchor, bool _StartAnimating = true)
        {
            mTexture = _Source.mTexture;
            mFrameSize = _Source.mFrameSize;
            SourceRec = _Source.SourceRec;
            Animations = _Source.Animations;
            CurrentAnimation = _Source.CurrentAnimation;
            Color = _Source.Color;
            DrawSize = _Source.DrawSize;
            mOwner = _Owner;
            mOwnerLastRotation = mOwner.Rotation;
            if (_Anchor.HasValue)
                Anchor = _Anchor.Value;
            else
                Anchor = Vector2.Zero;
            ShouldAnimate = _StartAnimating;
        }

        internal void Draw(SpriteBatch _SB)
        {
            _SB.Draw(mTexture, mOwner.Position + Anchor, SourceRec, mOwner.OverrideColor.HasValue ? mOwner.OverrideColor.Value : Color, Rotation, Origin, mScale, Effect, mOwner.LayerDepth + LayerDepth);
        }

        internal void Update(GameTime _GT)
        {
            if (ShouldAnimate)
                Animate(_GT);
        }

        internal void Animate(GameTime _GT)
        {
            mAnimationTimer += _GT.ElapsedGameTime.TotalSeconds * AnimationSpeedMultiplier;
            if (mAnimationTimer >= CurrentAnimation.TimerPerFrame)
            {
                mAnimationTimer = 0;
                if (mGoingRight)
                {
                    if (FrameIndex == mCurrentAnimation.FrameIndexBounds)
                    {
                        if (IsAnimationOver) TrySwapToNextAnimation();
                        if (mCurrentAnimation.BoomerangAnimation)
                        {
                            mGoingRight = false;
                            FrameIndex -= 1;
                            return;
                        }
                        else
                        {
                            FrameIndex = 0;
                            return;
                        }
                    }
                    FrameIndex++;
                    return;
                }
                else
                {
                    if (FrameIndex == 0)
                    {
                        if (IsAnimationOver) TrySwapToNextAnimation();
                        if (mCurrentAnimation.BoomerangAnimation)
                        {
                            mGoingRight = true;
                            FrameIndex += 1;
                            return;
                        }
                        else
                        {
                            FrameIndex = mCurrentAnimation.FrameIndexBounds;
                            return;
                        }
                    }
                    FrameIndex--;
                    return;
                }
            }
        }

        private void TrySwapToNextAnimation()
        {
            SwapToAnimation(mNextAnimationName.HasValue ? mNextAnimationName.Value : mCurrentAnimation.Looping ? mCurrentAnimation.Name : AnimationName.Idle);
        }

        private bool IsAnimationOver
        {
            get
            {
                if (mGoingRight &&
                    (CurrentAnimation.BoomerangAnimation && CurrentAnimation.RightToLeft) &&
                    FrameIndex - mCurrentAnimation.FrameIndexBounds == 0)
                    return true;
                if (!mGoingRight &&
                    FrameIndex == 0 &&
                    mCurrentAnimation.RightToLeft &&
                    !mCurrentAnimation.BoomerangAnimation)
                    return true;
                if (mGoingRight &&
                    !mCurrentAnimation.BoomerangAnimation &&
                    FrameIndex == mCurrentAnimation.FrameIndexBounds &&
                    !mCurrentAnimation.RightToLeft)
                    return true;
                if (!mGoingRight &&
                    mCurrentAnimation.BoomerangAnimation &&
                    !mCurrentAnimation.RightToLeft &&
                    FrameIndex == 0)
                    return true;
                return false;
            }
        }

        private void UpdateSourceRecPosition()
        {
            mFramePosition = (mCurrentAnimation.StartingIndex + new IntVector2(FrameIndex, 0)) * mFrameSize;
            SourceRec = new Rectangle(mFramePosition.X, mFramePosition.Y, SourceRec.Width, SourceRec.Height);
        }

        internal bool AddAnimation(AnimationName _Name, Animation _Animation, bool _OverwriteOld = false)
        {
            if (Animations.ContainsKey(_Name))
            {
                if (_OverwriteOld != true)
                    return false;
                Animations[_Name] = _Animation;
                return true;
            }
            else
            {
                Animations.Add(_Name, _Animation);
                if (CurrentAnimation == null)
                    CurrentAnimation = Animations[_Name];
                return true;
            }
        }

        internal bool SwapToAnimation(AnimationName _Name)
        {
            if (!Animations.ContainsKey(_Name)) return false;
            if (CurrentAnimation.AlwaysFinnish && !IsAnimationOver) mNextAnimationName = _Name;
            else
            {
                CurrentAnimation = Animations[_Name];
                mNextAnimationName = null;
            }
            return true;
        }

        private void ResetAnimation()
        {
            FrameIndex = CurrentAnimation.RightToLeft ? CurrentAnimation.FramesInAnimation - 1 : 0;
            mGoingRight = CurrentAnimation.RightToLeft ? false : true;
            mAnimationTimer = 0;
        }

        private void CalculateScale()
        {
            float scaleX, scaleY;
            scaleX = DrawSize.X / mFrameSize.X;
            scaleY = DrawSize.Y / mFrameSize.Y;
            mScale = new Vector2(scaleX, scaleY);
        }

        private void CalculateOrigin()
        {
            Origin = DrawSize / 2;
        }
    }
}