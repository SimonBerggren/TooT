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
            mAnimTextures[0].SwapToAnimation(AnimationName.Idle);
            mAnimTextures[0].AnimationSpeedMultiplier = 0.8;
        }

        internal override void Update(GameTime _GT)
        {
            Console.WriteLine(Position);
            InputManagement(_GT);
            base.Update(_GT);
        }

        private void InputManagement(GameTime _GT)
        {

            //Animation Testing
            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                mAnimTextures[0].SwapToAnimation(AnimationName.Idle);
            }
            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                mAnimTextures[0].SwapToAnimation(AnimationName.SpecialOne);
            }
            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                mAnimTextures[0].SwapToAnimation(AnimationName.SpecialTwo);
            }
            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                mAnimTextures[0].SwapToAnimation(AnimationName.SpecialThree);
            }
            if (InputManager.IsKeyClicked(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                mAnimTextures[0].SwapToAnimation(AnimationName.SpecialFour);
            }
            
            //Aim Debug
            int dirX = 0, dirY = 0;
            if (InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.I))
                dirY -= 1;
            if (InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.J))
                dirX -= 1;
            if (InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.L))
                dirX += 1;
            if (InputManager.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.K))
                dirY += 1;
            float result = 0; 
            if (dirX != 0 || dirY != 0)
            {
                result = (float)Math.Atan2(dirY, dirX); //radians
            }
            mRotation = result;
            mAnimTextures[0].Rotation = result;
            mAnimTextures[0].Rotation += (float)(Math.PI / 2);
            Console.WriteLine(dirX + "," + dirY);



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
