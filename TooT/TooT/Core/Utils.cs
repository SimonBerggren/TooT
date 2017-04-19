using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TooT
{
    internal static class Utils
    {
        internal static Random Random { get { if (mRandom == null) mRandom = new Random(); return mRandom; } }
        private static Random mRandom;

        internal static int intX(this Vector2 _this)
        {
            return (int)_this.X;
        }
        internal static int intY(this Vector2 _this)
        {
            return (int)_this.Y;
        }
        internal static Vector2 GetSize(this Texture2D _this)
        {
            return new Vector2(_this.Width, _this.Height);
        }
        internal static double TimerCountDown(this double _me, GameTime _GT) {return _me - _GT.ElapsedGameTime.TotalSeconds; }
        internal static Vector2 ApplyVelocity(this Vector2 _me, Vector2 _Velocity, GameTime _GT, float _MovementSpeed, double _SpeedMultiplier = 1.0)
        {
            return _me + _Velocity * (float)((_MovementSpeed * _GT.ElapsedGameTime.TotalSeconds) * _SpeedMultiplier);
        }

        internal static Vector2 ToVector(this float _Radians)
        {
            return new Vector2(
                (float)Math.Cos(_Radians),
                -(float)Math.Sin(_Radians)
                );
        }

        internal static float ToRadians(this Vector2 _Direction)
        {
            return (float)Math.Atan2(_Direction.X, -_Direction.Y);
        }
        internal static void DecreaseSpeed(this float _MovementSpeed, float Fricktion, GameTime _GT) { _MovementSpeed -= (_MovementSpeed * Fricktion * (float)_GT.TotalGameTime.TotalSeconds); }
    }
}
