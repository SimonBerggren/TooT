using Toot.Core.Multiplier;

namespace Toot.Core.Multiplier
{
    internal struct Multiplier // struct bcauz nice colors
    {
        internal float PlayerHealthMod;
        internal float MobHealthMod;
        internal int StartingLives;
        internal Multiplier(float _PlayerHpMod, float _MobHpMod, int _StartLives)
        {
            StartingLives = _StartLives;
            PlayerHealthMod = _PlayerHpMod;
            MobHealthMod = _MobHpMod;
        }
    }
}
namespace TooT
{
    internal static class Diffculty
    {
        internal static float PlayerHealthMod { get { return Current.PlayerHealthMod; } }
        internal static float MobHealthMod { get { return Current.MobHealthMod; } }
        internal static int StartingLives { get { return Current.StartingLives; } }

        private static Multiplier Easy = new Multiplier(1.5f, 0.5f, 6);
        private static Multiplier Normal = new Multiplier(1.0f, 1.0f, 4);
        private static Multiplier Hard = new Multiplier(0.5f, 2.0f, 2);
        internal static Multiplier Current = Normal;
        internal static void SetDifficulty(int _value)
        {
            if (_value == 0)
                Current = Easy;
            else if (_value == 2)
                Current = Hard;
            else
                Current = Normal;
        }
    }
}
