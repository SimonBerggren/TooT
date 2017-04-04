using Microsoft.Xna.Framework;

namespace TooT.Core.Factories
{
    class PawnFactory
    {
        internal enum PawnType
        {
            Dummy,
            Player,
        }

        internal enum ControllerType
        {
            Null,
            Player,
        }

        internal static PawnFactory Instance { get { if (mInstance == null) mInstance = new PawnFactory(); return mInstance; } }
        private static PawnFactory mInstance;

        internal Pawn Generate(PawnType _PT, ControllerType _CT, Vector2 _SpawnPoint, float _Scale = 1.0f, float _Rotation = 0.0f)
        {
            Controller controller = GetController(_CT);
            Pawn pawn = GetPawn(_PT, _SpawnPoint, _Scale, _Rotation);
            controller.Possess(pawn);
            return pawn;
        }

        internal Pawn Generate(PawnType _PT, Controller _Controller, Vector2 _SpawnPoint, float _Scale = 1.0f, float _Rotation = 0.0f)
        {
            Pawn pawn = GetPawn(_PT, _SpawnPoint, _Scale, _Rotation);
            _Controller.Possess(pawn);
            return pawn;
        }


        private Pawn GetPawn(PawnType _PT, Vector2 _SpawnPoint, float _Scale = 1.0f, float _Rotation = 0.0f)
        {
            switch (_PT)
            {
                case PawnType.Dummy:
                    return new DummyPawn(_SpawnPoint, _Scale, _Rotation);
                case PawnType.Player:
                    return new PlayerPawn(_SpawnPoint, _Scale, _Rotation);
                default:
                    throw new System.Exception("Illegal PawnType Specified");
            }
        }

        private Controller GetController(ControllerType _CT)
        {
            switch (_CT)
            {
                case ControllerType.Player:
                    return new PlayerController();
                default:
                    throw new System.Exception("Illegal ControllerType Specified");
            }
        }

    }
}
