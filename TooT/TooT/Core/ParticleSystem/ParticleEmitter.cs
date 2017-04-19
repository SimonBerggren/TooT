using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core.ParticleSystem
{
    class ParticleEmitter
    {
        Vector2 mPosition;
        internal bool ShouldBeRemoved { get { return mLifeSpanRemaining <= 0; } }
        private double mBurstTimer;
        private double mLifeSpanRemaining;
        private double mLifeSpanInitial;
        private double mLifeSpanElapsed { get { return mLifeSpanInitial - mLifeSpanRemaining; } }
        PsEmitterSettings mSettings;
        ParticleEngine Engine = ParticleEngine.Instance;
        internal ParticleEmitter(Vector2 _SpawnPos, PsEmitterSpawnInstruction _Instructions)
        {
            mSettings = _Instructions.EmitterSettings;
            mBurstTimer = mSettings.TimerPerParticleBurst;
            mLifeSpanInitial = mSettings.EmitterLifeSpan;
            mLifeSpanRemaining = mLifeSpanInitial;
            mPosition = _SpawnPos;
        }

        internal void Update(GameTime _GT)
        {
            mLifeSpanRemaining = mLifeSpanRemaining.TimerCountDown(_GT);
            mBurstTimer = mBurstTimer.TimerCountDown(_GT);
            if(mBurstTimer<= 0)
            {
                mBurstTimer = mSettings.TimerPerParticleBurst;
                for (int i = 0; i < mSettings.ParticlesPerBurst; i++)
                Engine.AddParticle(new Particle(mPosition, mSettings.ParticleLifeSpan, mSettings.Pattern.GetNextInitialVelocity(), mSettings.Pattern.GetNextMovementSpeed(), new AnimatedTexture(mSettings.ParticleTexture)));
            }
        }
    }
}
