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

        internal static bool PlayerOneButtonMiddleLower { get { return mPlayerOneButtonMiddleLower; } }
        internal static bool PlayerOneButtonLeftLower { get { return mPlayerOneButtonLeftLower; } }
        internal static bool PlayerOneButtonRightLower { get { return mPlayerOneButtonRightLower; } }
        private static bool mPlayerOneButtonLeftLower;
        private static bool mPlayerOneButtonRightLower;
        private static bool mPlayerOneButtonMiddleLower;

        internal static bool PlayerOneButtonLeftUpper { get { return mPlayerOneButtonLeftUpper; } }
        internal static bool PlayerOneButtonMiddleUpper { get { return mPlayerOneButtonMiddleUpper; } }
        internal static bool PlayerOneButtonRightUpper { get { return mPlayerOneButtonRightUpper; } }
        private static bool mPlayerOneButtonLeftUpper;
        private static bool mPlayerOneButtonMiddleUpper;
        private static bool mPlayerOneButtonRightUpper;

        internal static bool PlayerOneButtonAnyKey
        {
            get
            {
                return
                    (
                        mPlayerOneButtonLeftLower ||
                        mPlayerOneButtonLeftUpper ||
                        mPlayerOneButtonMiddleLower ||
                        mPlayerOneButtonMiddleUpper ||
                        mPlayerOneButtonRightLower ||
                        mPlayerOneButtonRightUpper
                    );
            }
        }
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

        internal static bool PlayerTwoButtonMiddleLower { get { return mPlayerTwoButtonMiddleLower; } }
        internal static bool PlayerTwoButtonLeftLower { get { return mPlayerTwoButtonLeftLower; } }
        internal static bool PlayerTwoButtonRightLower { get { return mPlayerTwoButtonRightLower; } }
        private static bool mPlayerTwoButtonLeftLower;
        private static bool mPlayerTwoButtonRightLower;
        private static bool mPlayerTwoButtonMiddleLower;

        internal static bool PlayerTwoButtonLeftUpper { get { return mPlayerTwoButtonLeftUpper; } }
        internal static bool PlayerTwoButtonMiddleUpper { get { return mPlayerTwoButtonMiddleUpper; } }
        internal static bool PlayerTwoButtonRightUpper { get { return mPlayerTwoButtonRightUpper; } }
        private static bool mPlayerTwoButtonLeftUpper;
        private static bool mPlayerTwoButtonMiddleUpper;
        private static bool mPlayerTwoButtonRightUpper;

        internal static bool PlayerTwoButtonAnyKey
        {
            get
            {
                return
                    (
                        mPlayerTwoButtonLeftLower ||
                        mPlayerTwoButtonLeftUpper ||
                        mPlayerTwoButtonMiddleLower ||
                        mPlayerTwoButtonMiddleUpper ||
                        mPlayerTwoButtonRightLower ||
                        mPlayerTwoButtonRightUpper
                    );
            }
        }
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

            mPlayerOneButtonLeftUpper = IsKeyClicked(Keys.NumPad4);
            mPlayerOneButtonLeftLower = IsKeyPressed(Keys.NumPad1);
            mPlayerOneButtonMiddleUpper = IsKeyClicked(Keys.NumPad5);
            mPlayerOneButtonMiddleLower = IsKeyPressed(Keys.NumPad2);
            mPlayerOneButtonRightUpper = IsKeyClicked(Keys.NumPad6);
            mPlayerOneButtonRightLower = IsKeyPressed(Keys.NumPad3);
            mPlayerOneJoystickUp = IsKeyPressed(Keys.Up);
            mPlayerOneJoystickDown = IsKeyPressed(Keys.Down);
            mPlayerOneJoystickLeft = IsKeyPressed(Keys.Left);
            mPlayerOneJoystickRight = IsKeyPressed(Keys.Right);

            mPlayerTwoButtonLeftUpper = IsKeyClicked(Keys.U);
            mPlayerTwoButtonLeftLower = IsKeyPressed(Keys.G);
            mPlayerTwoButtonMiddleUpper = IsKeyClicked(Keys.I);
            mPlayerTwoButtonMiddleLower = IsKeyPressed(Keys.H);
            mPlayerTwoButtonRightUpper = IsKeyClicked(Keys.O);
            mPlayerTwoButtonRightLower = IsKeyPressed(Keys.J);
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