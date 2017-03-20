using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{
    class Pawn : GameObject
    {
        public Pawn(Vector2 _Pos, float _Scale, Texture2D _Texture) : base(_Pos, _Scale, _Texture)
        {
        }
    }
}
