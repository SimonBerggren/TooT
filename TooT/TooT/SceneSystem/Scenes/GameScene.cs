using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TooT.Core;

namespace TooT.SceneSystem
{
    internal class GameScene : Scene
    {
        RoomManager mRoomManager;
        UIManager mUIManager;
        internal GameScene()
        {
            mRoomManager = new RoomManager();
            mUIManager = new UIManager();
            mRoomManager.mCurrentRoom.AddGameObject(new Player(new Vector2(50, 50), 1.0f));
        }

        internal override bool HandleTransition(GameTime _GT)
        {
            return base.HandleTransition(_GT);
        }

        internal override void Update(GameTime _GT)
        {
            mRoomManager.Update(_GT);
            base.Update(_GT);
        }

        internal override void Draw(SpriteBatch _SB)
        {
            mRoomManager.Draw(_SB);
            base.Draw(_SB);
        }
    }
}
