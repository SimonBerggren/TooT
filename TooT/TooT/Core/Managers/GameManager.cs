using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooT.Core
{
    class GameManager
    {
        RoomManager mRoomManager;
        UIManager mUIManager;
        internal void Update(GameTime _GT)
        {
            mRoomManager.Update(_GT);
            mUIManager.Update(_GT);
        }

        internal void Draw(SpriteBatch _SB)
        {
            mRoomManager.Draw(_SB);
            mUIManager.Draw(_SB);
        }
    }
}
