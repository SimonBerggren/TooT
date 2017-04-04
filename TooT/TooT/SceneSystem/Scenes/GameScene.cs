using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TooT.Core;
using TooT.Core.Factories;

namespace TooT.SceneSystem
{
    internal class GameScene : Scene
    {
        internal RoomManager RoomManager { get { return mRoomManager; } }
        RoomManager mRoomManager;
        UIManager mUIManager;
        GameManager mGameManager;
        internal GameScene(int _NumberOfPlayers = 1)
        {
            mRoomManager = new RoomManager();
            mUIManager = new UIManager();
            mGameManager = GameManager.Instance;
            mGameManager.GameScene = this;
            for (int i = 0; i < _NumberOfPlayers; i++)
            {
                Pawn tPawn = PawnFactory.Instance.Generate(PawnFactory.PawnType.Dummy, PawnFactory.ControllerType.Player, Vector2.Zero);
                mRoomManager.mCurrentRoom.AddGameObject(tPawn);
            }
        }

        internal override bool HandleTransition(GameTime _GT)
        {
            return base.HandleTransition(_GT);
        }

        internal override void Update(GameTime _GT)
        {
            mRoomManager.Update(_GT);
            mUIManager.Update(_GT);
            base.Update(_GT);
        }

        internal override void Draw(SpriteBatch _SB)
        {
            mRoomManager.Draw(_SB);
            mUIManager.Draw(_SB);
            base.Draw(_SB);
        }
    }
}
