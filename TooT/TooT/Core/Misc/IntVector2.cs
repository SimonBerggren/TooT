using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TooT
{
    class IntVector2
    {
        internal int X, Y;
        internal IntVector2(int _X, int _Y) { X = _X; Y = _Y; }
        public static IntVector2 operator +(IntVector2 _v1, IntVector2 _v2) => new IntVector2(_v1.X+ _v2.X, _v1.Y+ _v2.Y);
        public static IntVector2 operator *(IntVector2 _v1, IntVector2 _v2) => new IntVector2(_v1.X * _v2.X, _v1.Y* _v2.Y);
    }
}
