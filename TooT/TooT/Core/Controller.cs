using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal abstract class Controller
    {
        internal Pawn Pawn;

        internal Controller()
        {
        }

        internal virtual void Update(GameTime _GT)
        {

        }

        internal virtual void Draw(SpriteBatch _SB)
        {

        }

        internal virtual void Possess(Pawn _NewPawn)
        {
            if (Pawn != null)
                Pawn.UnPossessed();

            Pawn = _NewPawn;
            Pawn.Possessed(this);
        }

    }
}
