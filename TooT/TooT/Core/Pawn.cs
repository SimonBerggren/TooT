using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    abstract class Pawn /*poop*/: GameObject
    {
        internal Controller Controller;
        internal Pawn(Vector2 _Pos, float _Scale = 1.0f, float _Rotation = 1.0f) : base(_Pos, _Scale, _Rotation)
        {

        }

        internal override void Update(GameTime _GT)
        {
            if (Controller != null)
                Controller.Update(_GT);
            base.Update(_GT);
        }

        internal virtual void Possessed(Controller _Controller)
        {
            Controller = _Controller;
        }

        internal virtual void UnPossessed()
        {
            Controller = null;
        }

        internal override void Draw(SpriteBatch _SB)
        {
            if (Controller != null)
                Controller.Draw(_SB);
            base.Draw(_SB);
        }

        internal virtual void Attack()
        {

        }

        internal void Move(Vector2 _MoveVec, bool _FaceTravel = false)
        {
            if (_FaceTravel)
                AimInDirection(_MoveVec);
        }

        internal void AimInDirection(Vector2 _Dir)
        {

        }
    }
}
