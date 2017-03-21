using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{
    abstract class Pawn : GameObject
    {
        public Pawn(Vector2 _Pos, float _Scale) : base(_Pos, _Scale)
        {
        }
    }
}
