using System;
using Microsoft.Xna.Framework;

namespace TooT.Core.ParticleSystem
{
    internal class PsPspCircle : IPsParticleSpawnPattern
    {
        internal static PsPspCircle Instance { get { if (mInstance == null) mInstance = new PsPspCircle(); return mInstance; } }
        private static PsPspCircle mInstance;

        public Vector2 GetNextInitialVelocity()
        {
            float Deg = ParticleEngine.Random.Next(0, 361);
            return MathHelper.ToRadians(Deg).ToVector();
        }

        public float GetNextMovementSpeed()
        {
            return ParticleEngine.Random.Next(1, 10);
        }
    }
}
