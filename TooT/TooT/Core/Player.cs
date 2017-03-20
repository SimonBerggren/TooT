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
        internal Player(Vector2 _Pos, float _Scale, Texture2D _Texture) : base(_Pos, _Scale, _Texture)
        {
        }

        internal override void Update(GameTime _GT)
        {
            InputManagement(_GT);
            base.Update(_GT);
        }

        private void InputManagement(GameTime _GT)
        {
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
