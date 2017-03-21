using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT.Core
{
    class Player : Pawn
    {
        private float mMovementSpeed = 1.0f;

        //Debug
        int AnimationDebugIndex = 0;

        public Player(Vector2 _Pos, float _Scale) : base(_Pos, _Scale)
        {
            mAnimTextures.Add(ContentManager.TestSheet(this));
            mAnimTextures[0].SwapToAnimation(AnimationName.SpecialThree);
            mAnimTextures[0].AnimationSpeedMultiplier = 0.1;
        }

        internal override void Update(GameTime _GT)
        {
            Console.WriteLine(Position);
            InputManagement(_GT);
            base.Update(_GT);
        }

        private void InputManagement(GameTime _GT)
        {

            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                    while (true)
                    {
                        if (mAnimTextures[0].SwapToAnimation((AnimationName)(++AnimationDebugIndex)))
                            break;
                    if (AnimationDebugIndex > Enum.GetValues(typeof(AnimationName)).Length)
                        AnimationDebugIndex = 0;
                    }
            }
            float InputX = 0.0f;
            float InputY = 0.0f;
            if (InputManager.PlayerOneJoystickLeft) InputX -= (float)(mMovementSpeed * _GT.ElapsedGameTime.TotalMilliseconds);
            if (InputManager.PlayerOneJoystickRight) InputX += (float)(mMovementSpeed * _GT.ElapsedGameTime.TotalMilliseconds);
            if (InputManager.PlayerOneJoystickUp) InputY -= (float)(mMovementSpeed * _GT.ElapsedGameTime.TotalMilliseconds);
            if (InputManager.PlayerOneJoystickDown) InputY += (float)(mMovementSpeed * _GT.ElapsedGameTime.TotalMilliseconds);
            mPosition = mPosition + new Vector2(InputX, InputY);
        }
    }
}
