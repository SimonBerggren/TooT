using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TooT.Core.ParticleSystem
{
    class PsExplosion : ParticleSystem
    {
        public PsExplosion(Vector2 _SpawnPos, List<PsEmitterSpawnInstruction> _Instructions, double _LifeLength) : base(_SpawnPos, _Instructions, _LifeLength)
        {
        }
    }
}
