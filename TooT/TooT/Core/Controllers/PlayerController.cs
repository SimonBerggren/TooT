namespace TooT
{
    class PlayerController : Controller
    {
        internal float Score = 0;
        internal int ExtraLives;
        internal int PlayerIndex;
        internal PlayerController()
        {
            PlayerIndex = GameManager.Instance.Players.Count;
            ExtraLives = Diffculty.StartingLives;
            GameManager.Instance.RegisterNewPlayerController(this);
        }


    }
}
