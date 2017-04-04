using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{
    class PlayerPawn : Pawn
    {
        public PlayerPawn(Vector2 _Pos, float _Scale = 1.0f, float _Rotation = 1.0f) : base(_Pos, _Scale, _Rotation)
        {
            mAnimTextures.Add(ContentManager.TestSheet(this));
            mAnimTextures[0].SwapToAnimation(AnimationName.Idle);
            mAnimTextures[0].AnimationSpeedMultiplier = 0.8;
        }

        internal override void Update(GameTime _GT)
        {
            base.Update(_GT);
        }

    }
}
