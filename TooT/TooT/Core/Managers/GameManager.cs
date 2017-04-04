using System.Collections.Generic;
using TooT.SceneSystem;

namespace TooT
{
   


    class GameManager
    {
        internal static GameManager Instance { get { if (mInstance == null) mInstance = new GameManager(); return mInstance; } }
        private static GameManager mInstance;
        internal GameScene GameScene;
        internal List<PlayerController> Players = new List<PlayerController>();

        GameManager()
        {
        }

        internal void RegisterNewPlayerController(PlayerController _Controller)
        {
            Players.Add(_Controller);
        }
    }
}
