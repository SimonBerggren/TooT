using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core.ParticleSystem
{
    enum PreMadeSystem
    {
        Explosion,
    }

    struct PsEmitterSpawnInstruction
    {
        internal float HowManySecondsUntillActivation;
        internal float HowManySecondsUntillDeActivation;
        internal PsEmitterSettings EmitterSettings;

        public PsEmitterSpawnInstruction(float _HowManySecondsUntillActivation, float _HowManySecondsUntillDeActivation, PsEmitterSettings _EmitterSettings)
        {
            HowManySecondsUntillActivation = _HowManySecondsUntillActivation;
            HowManySecondsUntillDeActivation = _HowManySecondsUntillDeActivation;
            EmitterSettings = _EmitterSettings;
        }
    }

    struct PsEmitterSettings
    {
        internal double EmitterLifeSpan;
        internal double ParticleLifeSpan;
        internal double TimerPerParticleBurst;
        internal int ParticlesPerBurst;
        internal IPsParticleSpawnPattern Pattern;
        internal AnimatedTexture ParticleTexture;
        internal Vector2 Offset;

        internal PsEmitterSettings(double _EmitterLifeSpan, double _ParticleLifeSpan, double _TimePerParticleBurst, int _ParticlesPerBurst, IPsParticleSpawnPattern _Pattern, AnimatedTexture _ParticleTexture, Vector2? _Offset = null)
        {
            EmitterLifeSpan = _EmitterLifeSpan;
            ParticleLifeSpan = _ParticleLifeSpan;
            TimerPerParticleBurst = _TimePerParticleBurst;
            ParticlesPerBurst = _ParticlesPerBurst;
            Pattern = _Pattern;
            ParticleTexture = _ParticleTexture;
            if (_Offset.HasValue)
                Offset = _Offset.Value;
            else
                Offset = Vector2.Zero;
        }
    }

    interface IPsParticleSpawnPattern
    {
        Vector2 GetNextInitialVelocity();
        float GetNextMovementSpeed();
    }

    class ParticleSystem
    {
        List<PsEmitterSpawnInstruction> mInstructions;
        List<ParticleEmitter> mEmitters;
        List<ParticleEmitter> mEmittersToRemove;
        internal bool ShouldBeRemoved { get { return mLifeSpanRemaining <= 0; } }
        private double mLifeSpanRemaining;
        private double mLifeSpanInitial;
        private double mLifeSpanElapsed { get { return mLifeSpanInitial - mLifeSpanRemaining; } }
        internal Vector2 Hook { get; private set; }
        internal Vector2 Position { get; private set; }

        internal ParticleSystem(Vector2 _SpawnPos, List<PsEmitterSpawnInstruction> _Instructions, double _LifeLength)
        {
            mInstructions = _Instructions;
            mEmitters = new List<ParticleEmitter>();
            mEmittersToRemove = new List<ParticleEmitter>();
            Position = _SpawnPos;
            mInstructions = _Instructions;
            mLifeSpanInitial = _LifeLength;
            mLifeSpanRemaining = mLifeSpanInitial;
        }
        internal void Update(GameTime _GT)
        {
            mLifeSpanRemaining = mLifeSpanRemaining.TimerCountDown(_GT);
            foreach (ParticleEmitter PE in mEmitters)
            {
                PE.Update(_GT);
                if (PE.ShouldBeRemoved)
                    mEmittersToRemove.Add(PE);
            }
            foreach (ParticleEmitter PE in mEmittersToRemove)
            {
                mEmitters.Remove(PE);
            }
            mEmittersToRemove.Clear();
            ManageInstructions(_GT);
        }

        private void ManageInstructions(GameTime _GT)
        {
            List<PsEmitterSpawnInstruction> T = new List<PsEmitterSpawnInstruction>();
            foreach (PsEmitterSpawnInstruction PsEsi in mInstructions)
                if (mLifeSpanElapsed >= PsEsi.HowManySecondsUntillActivation)
                {
                    mEmitters.Add(new ParticleEmitter(Position, PsEsi));
                    T.Add(PsEsi);
                }
            foreach (PsEmitterSpawnInstruction PsEsi in T)
                mInstructions.Remove(PsEsi);
        }
    }
}
