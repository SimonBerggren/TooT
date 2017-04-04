using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TooT
{
    /// <summary>
    /// Im a dummy pawn, only used to force update/draw onto my controller.
    /// </summary>
    class DummyPawn : Pawn
    {
        public DummyPawn(Vector2 _Pos, float _Scale = 1, float _Rotation = 1) : base(_Pos, _Scale, _Rotation)
        {
        }
    }
}
