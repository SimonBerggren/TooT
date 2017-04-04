using Microsoft.Xna.Framework;
using TooT.Control;

namespace TooT.Control
{
    internal class Controls
    {
        internal bool Up { get { return mUp; } }
        internal bool Down { get { return mDown; } }
        internal bool Left { get { return mLeft; } }
        internal bool Right { get { return mRight; } }
        internal bool LU { get { return mLU; } }
        internal bool LL { get { return mLL; } }
        internal bool MU { get { return mMU; } }
        internal bool ML { get { return mML; } }
        internal bool RU { get { return mRU; } }
        internal bool RL { get { return mRL; } }
        internal bool AnyKey { get { return mAnyKey; } }
        private bool mUp, mDown, mLeft, mRight, mLU, mLL, mMU, mML, mRU, mRL, mAnyKey;
        internal void Update(int _PlayerIndex)
        {
            if(_PlayerIndex == 1)
            {
                mUp = InputManager.PlayerOneJoystickUp;
                mDown = InputManager.PlayerOneJoystickDown;
                mRight = InputManager.PlayerOneJoystickRight;
                mLeft = InputManager.PlayerOneJoystickLeft;

                mLU = InputManager.PlayerOneButtonLeftUpper;
                mLL = InputManager.PlayerOneButtonLeftLower;
                mMU = InputManager.PlayerOneButtonMiddleUpper;
                mML = InputManager.PlayerOneButtonMiddleLower;
                mRU = InputManager.PlayerOneButtonRightUpper;
                mRL = InputManager.PlayerOneButtonRightLower;
                mAnyKey = InputManager.PlayerOneButtonAnyKey;
            }
            else
            {
                mUp = InputManager.PlayerTwoJoystickUp;
                mDown = InputManager.PlayerTwoJoystickDown;
                mRight = InputManager.PlayerTwoJoystickRight;
                mLeft = InputManager.PlayerTwoJoystickLeft;

                mLU = InputManager.PlayerTwoButtonLeftUpper;
                mLL = InputManager.PlayerTwoButtonLeftLower;
                mMU = InputManager.PlayerTwoButtonMiddleUpper;
                mML = InputManager.PlayerTwoButtonMiddleLower;
                mRU = InputManager.PlayerTwoButtonRightUpper;
                mRL = InputManager.PlayerTwoButtonRightLower;
                mAnyKey = InputManager.PlayerTwoButtonAnyKey;
            }
        }
    }
}

namespace TooT
{
    class PlayerController : Controller
    {
        internal float Score = 0;
        internal int ExtraLives;
        internal int PlayerIndex;

        private Controls mControls = new Controls();
        internal PlayerController()
        {
            PlayerIndex = GameManager.Instance.Players.Count;
            ExtraLives = Diffculty.StartingLives;
            GameManager.Instance.RegisterNewPlayerController(this);
        }

        internal override void Update(GameTime _GT)
        {
            mControls.Update(PlayerIndex);
            if (Pawn is DummyPawn && mControls.AnyKey)
            { EventManager.Fire(Event.OnDummyPawnControlledPlayerClick, this); base.Update(_GT); return; }
            base.Update(_GT);
        }
    }
}
