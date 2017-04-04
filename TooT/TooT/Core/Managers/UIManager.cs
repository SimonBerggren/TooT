using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{

    internal class UIManager
    {
    private static UIManager mInstance;
        internal static UIManager Instance { get { if(mInstance == null) mInstance = new UIManager(); return mInstance; } }
        
         
        internal void Update(GameTime _GT)
        {
        }

        internal void Draw(SpriteBatch _SB)
        {
        }
    }
}