using Microsoft.Xna.Framework;

namespace TooT
{
    class AcceptBox : MessageBox
    {
        internal AcceptBox(EntryDesc _Desc, Vector2 _Size) : base(ContentManager.Dot, _Desc, _Size)
        {
            AddEntry("Back", Close);
        }
    }
}