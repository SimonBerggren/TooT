using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooT
{
    internal static class Utils
    {
        internal static int intX(this Vector2 _this)
        {
            return (int)_this.X;
        }
        internal static int intY(this Vector2 _this)
        {
            return (int)_this.Y;
        }
        internal static Vector2 GetSize(this Texture2D _this)
        {
            return new Vector2(_this.Width, _this.Height);
        }
    }
}
