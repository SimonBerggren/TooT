using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TooT.Core.Factories;
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
            EventManager.Subscribe(Event.OnDummyPawnControlledPlayerClick, new Action<PlayerController>(TrySpawnPlayer));
        }

        internal void TrySpawnPlayer(PlayerController _Controller)
        {
            Console.WriteLine("Bazinga");
            Vector2 roomAnchor = GameScene.RoomManager.mCurrentRoom.Anchor;
            Pawn p = PawnFactory.Instance.Generate(PawnFactory.PawnType.Player, _Controller, roomAnchor + new Vector2(150, 150));
            GameScene.RoomManager.mCurrentRoom.AddGameObject(p);
        }
}
}
