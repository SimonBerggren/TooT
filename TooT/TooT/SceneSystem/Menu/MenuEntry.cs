using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TooT
{
    class EntryDesc
    {
        // text attributes
        internal Color SelectedColor { get; set; } = Color.White;
        internal Color Color { get; set; } = Color.Black;
        internal Color StartColor { get; set; } = Color.Black;

        internal Vector2 StartPosition { get; set; } = Vector2.Zero;
        internal Vector2 EndPosition { get; set; } = Vector2.Zero;

        internal float FadeSpeed { get; set; } = 0.1f;
        internal float GlowSpeed { get; set; } = 0.1f;

        internal SpriteFont Font { get; set; }

        internal EntryDesc(SpriteFont _Font, Vector2 _StartPosition, Vector2? _EndPosition = null)
        {
            Font = _Font;
            StartPosition = _StartPosition;
            EndPosition = (_EndPosition.HasValue) ? _EndPosition.Value : _StartPosition;
        }
        internal EntryDesc(EntryDesc _Desc) : this(_Desc.Font, _Desc.StartPosition, _Desc.EndPosition)
        {
            SelectedColor = _Desc.SelectedColor;
            Color = _Desc.Color;
            FadeSpeed = _Desc.FadeSpeed;
            GlowSpeed = _Desc.GlowSpeed;
        }
    }

    class MenuEntry
    {
        internal Action BoundAction { get; set; }
        internal bool IsSelected { get; set; }
        internal Vector2 Positon { get { return mPosition; } }
        Color mColor;
        string mText;
        Vector2 mPosition;
        Rectangle mBounds;
        Vector2 mOrigin;
        float mScale;
        float mRotation;
        float mLayerDepth;
        EntryDesc mDesc;

        internal MenuEntry(string _Text, EntryDesc _Desc, Action _Action = null)
        {
            mText = _Text;
            mDesc = new EntryDesc(_Desc);
            BoundAction = _Action;
            mPosition = mDesc.StartPosition;
            mScale = 1.0f;
            mRotation = 0.0f;
            mLayerDepth = 1.0f;

            Vector2 size = mDesc.Font.MeasureString(mText) * mScale;
            mOrigin = size / 2.0f;
            mBounds = new Rectangle((int)(mPosition.X - mOrigin.X), (int)(mPosition.Y - mOrigin.Y), (int)(size.X), (int)(size.Y));
        }

        internal void DoAction()
        {
            if (BoundAction != null)
                BoundAction();
        }

        internal void HandleTransition(SceneState _State, float _TransitionStatus)
        {
            mColor = mColor * _TransitionStatus;
            mPosition = Vector2.Lerp(mDesc.StartPosition, mDesc.EndPosition, _TransitionStatus);
            if (_TransitionStatus == 1)
                mPosition = mDesc.EndPosition;
        }

        internal void Update(GameTime _GT)
        {
            if (IsSelected)
                mColor = Color.Lerp(mColor, mDesc.SelectedColor, mDesc.GlowSpeed);
            else
                mColor = Color.Lerp(mColor, mDesc.Color, mDesc.FadeSpeed);
        }

        internal void Draw(SpriteBatch _SB)
        {
            _SB.DrawString(mDesc.Font, mText, mPosition, mColor, mRotation, mOrigin, mScale, SpriteEffects.None, mLayerDepth);
        }
    }
}