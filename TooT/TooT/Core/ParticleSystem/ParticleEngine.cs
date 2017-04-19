using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core.ParticleSystem
{
    class ParticleEngine
    {
        private List<Particle> mParticles = new List<Particle>();
        private List<Particle> mParticlesToRemove = new List<Particle>();

        internal static Random Random {get{return mRandom;} }
        private static Random mRandom;

        List<ParticleSystem> mParticleSystems;
        internal static ParticleEngine Instance { get { if (mInstance == null) mInstance = new ParticleEngine(); return mInstance; } }
        private static ParticleEngine mInstance;

        private ParticleEngine()
        {
            mRandom = new Random(new DateTime().Millisecond);
            mParticleSystems = new List<ParticleSystem>();
        }

        internal void Update(GameTime _GT)
        {
            foreach (ParticleSystem PS in mParticleSystems)
            {
                PS.Update(_GT);
            }

            foreach (Particle P in mParticles)
                if (P.Update(_GT))
                    mParticlesToRemove.Add(P);
            foreach (Particle P in mParticlesToRemove)
                mParticles.Remove(P);
        }

        internal void Draw(SpriteBatch _SB)
        {
            foreach (Particle P in mParticles)
                P.Draw(_SB);
        }

        internal ParticleSystem SpawnCustomParticleSystem(Vector2 _SpawnPos, List<PsEmitterSpawnInstruction> _Instructions = null, Vector2? _Hook = null)
        {
            ParticleSystem Temp = new ParticleSystem(_SpawnPos, _Instructions, 15);
            mParticleSystems.Add(Temp);
            return Temp;
        }

        internal void AddParticle(Particle _P)
        {
            mParticles.Add(_P);
        }
    }
}
