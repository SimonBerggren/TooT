using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TooT
{
    internal static class InputManager
    {
        #region PlayerOne
        internal static bool PlayerOneJoystickUp { get { return mPlayerOneJoystickUp; } }
        internal static bool PlayerOneJoystickDown { get { return mPlayerOneJoystickDown; } }
        internal static bool PlayerOneJoystickLeft { get { return mPlayerOneJoystickLeft; } }
        internal static bool PlayerOneJoystickRight { get { return mPlayerOneJoystickRight; } }
        private static bool mPlayerOneJoystickUp;
        private static bool mPlayerOneJoystickDown;
        private static bool mPlayerOneJoystickLeft;
        private static bool mPlayerOneJoystickRight;

        internal static bool PlayerOneButtonMoveJump { get { return mPlayerOneButtonMoveJump; } }
        internal static bool PlayerOneButtonMoveLeft { get { return mPlayerOneButtonMoveLeft; } }
        internal static bool PlayerOneButtonMoveRight { get { return mPlayerOneButtonMoveRight; } }
        private static bool mPlayerOneButtonMoveLeft;
        private static bool mPlayerOneButtonMoveRight;
        private static bool mPlayerOneButtonMoveJump;

        internal static bool PlayerOneButtonSpawnOne { get { return mPlayerOneButtonSpawnOne; } }
        internal static bool PlayerOneButtonSpawnTwo { get { return mPlayerOneButtonSpawnTwo; } }
        internal static bool PlayerOneButtonSpawnThree { get { return mPlayerOneButtonSpawnThree; } }
        private static bool mPlayerOneButtonSpawnOne;
        private static bool mPlayerOneButtonSpawnTwo;
        private static bool mPlayerOneButtonSpawnThree;
        #endregion

        #region PlayerTwo
        internal static bool PlayerTwoJoystickUp { get { return mPlayerTwoJoystickUp; } }
        internal static bool PlayerTwoJoystickDown { get { return mPlayerTwoJoystickDown; } }
        internal static bool PlayerTwoJoystickLeft { get { return mPlayerTwoJoystickLeft; } }
        internal static bool PlayerTwoJoystickRight { get { return mPlayerTwoJoystickRight; } }
        private static bool mPlayerTwoJoystickUp;
        private static bool mPlayerTwoJoystickDown;
        private static bool mPlayerTwoJoystickLeft;
        private static bool mPlayerTwoJoystickRight;

        internal static bool PlayerTwoButtonMoveJump { get { return mPlayerTwoButtonMoveJump; } }
        internal static bool PlayerTwoButtonMoveLeft { get { return mPlayerTwoButtonMoveLeft; } }
        internal static bool PlayerTwoButtonMoveRight { get { return mPlayerTwoButtonMoveRight; } }
        private static bool mPlayerTwoButtonMoveLeft;
        private static bool mPlayerTwoButtonMoveRight;
        private static bool mPlayerTwoButtonMoveJump;

        internal static bool PlayerTwoButtonSpawnOne { get { return mPlayerTwoButtonSpawnOne; } }
        internal static bool PlayerTwoButtonSpawnTwo { get { return mPlayerTwoButtonSpawnTwo; } }
        internal static bool PlayerTwoButtonSpawnThree { get { return mPlayerTwoButtonSpawnThree; } }
        private static bool mPlayerTwoButtonSpawnOne;
        private static bool mPlayerTwoButtonSpawnTwo;
        private static bool mPlayerTwoButtonSpawnThree;
        #endregion

        #region Both
        internal static bool EitherJoystickUp { get { return mPlayerOneJoystickUp || mPlayerTwoJoystickUp; } }
        internal static bool EitherJoystickDown { get { return mPlayerOneJoystickDown || mPlayerTwoJoystickDown; } }
        internal static bool EitherJoystickLeft { get { return mPlayerOneJoystickLeft || mPlayerTwoJoystickLeft; } }
        internal static bool EitherJoystickRight { get { return mPlayerOneJoystickRight || mPlayerTwoJoystickRight; } }
        #endregion

        private static KeyboardState mOldKeyboardState, mKeyboardState;
        private static MouseState mOldMouseState, mMouseState;

        internal static void Update()
        {
            mOldKeyboardState = mKeyboardState;
            mOldMouseState = mMouseState;
            mKeyboardState = Keyboard.GetState();
            mMouseState = Mouse.GetState();

            mPlayerOneButtonMoveJump = IsKeyPressed(Keys.NumPad2);
            mPlayerOneButtonMoveLeft = IsKeyPressed(Keys.NumPad1);
            mPlayerOneButtonMoveRight = IsKeyPressed(Keys.NumPad3);
            mPlayerOneButtonSpawnOne = IsKeyClicked(Keys.NumPad4);
            mPlayerOneButtonSpawnTwo = IsKeyClicked(Keys.NumPad5);
            mPlayerOneButtonSpawnThree = IsKeyClicked(Keys.NumPad6);
            mPlayerOneJoystickUp = IsKeyPressed(Keys.Up);
            mPlayerOneJoystickDown = IsKeyPressed(Keys.Down);
            mPlayerOneJoystickLeft = IsKeyPressed(Keys.Left);
            mPlayerOneJoystickRight = IsKeyPressed(Keys.Right);

            mPlayerTwoButtonMoveJump = IsKeyPressed(Keys.H);
            mPlayerTwoButtonMoveLeft = IsKeyPressed(Keys.G);
            mPlayerTwoButtonMoveRight = IsKeyPressed(Keys.J);
            mPlayerTwoButtonSpawnOne = IsKeyClicked(Keys.U);
            mPlayerTwoButtonSpawnTwo = IsKeyClicked(Keys.I);
            mPlayerTwoButtonSpawnThree = IsKeyClicked(Keys.O);
            mPlayerTwoJoystickUp = IsKeyPressed(Keys.W);
            mPlayerTwoJoystickDown = IsKeyPressed(Keys.S);
            mPlayerTwoJoystickLeft = IsKeyPressed(Keys.A);
            mPlayerTwoJoystickRight = IsKeyPressed(Keys.D);
        }

        internal static bool IsKeyClicked(Keys _Key)
        {
            return (mKeyboardState.IsKeyDown(_Key) && mOldKeyboardState.IsKeyUp(_Key)) ;
        }

        internal static bool IsKeyPressed(Keys _Key)
        {
            return mKeyboardState.IsKeyDown(_Key);
        }

        internal static bool IsLeftButtonDown()
        {
            return mMouseState.LeftButton == ButtonState.Pressed;
        }

        internal static bool IsLeftButtonUp()
        {
            return mMouseState.LeftButton == ButtonState.Released;
        }

        internal static bool LeftButtonClicked()
        {
            return mOldMouseState.LeftButton == ButtonState.Released && mMouseState.LeftButton == ButtonState.Pressed;
        }

        internal static bool IsLeftButtonReleased()
        {
            return mOldMouseState.LeftButton == ButtonState.Pressed && mMouseState.LeftButton == ButtonState.Released;
        }

        internal static Vector2 MousePosition()
        {
            return mMouseState.Position.ToVector2();
        }

        internal static Point MousePoint()
        {
            return mMouseState.Position;
        }
    }
}