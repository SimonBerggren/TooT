using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{
    internal class RoomManager
    {
        Room[,] mRooms;
        internal Room mCurrentRoom;
        internal Room mNextRoom;

        internal RoomManager()
        {
            mRooms = MapGenerator.GenerateRoom();
            mCurrentRoom = mRooms[0, 0];
        }

        internal void Update(GameTime _GT)
        {
            mCurrentRoom.Update(_GT);
            if (mNextRoom != null)
                mNextRoom.Update(_GT);
        }

        internal void Draw(SpriteBatch _SB)
        {
            mCurrentRoom.Draw(_SB);
            if (mNextRoom != null)
                mNextRoom.Draw(_SB);
        }
    }
}