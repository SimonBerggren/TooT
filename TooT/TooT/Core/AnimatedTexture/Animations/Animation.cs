using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooT
{
    internal enum AnimationName
    {

        Idle         = 0,
        Walk         = 1,
        Run          = 2,
        Die          = 3,
        SpecialOne   = 4,
        SpecialTwo   = 5,
        SpecialThree = 6,
        SpecialFour  = 7, 
    }

    class Animation
    {
    
        internal AnimationName Name { get; private set; }
        internal bool IsAnimation { get { return FramesInAnimation > 1; } }
        internal int FramesInAnimation { get; private set; }
        internal int FrameIndexBounds { get { return FramesInAnimation - 1; } }
        internal IntVector2 StartingIndex { get; private set; }
        internal double TimerPerFrame { get; private set; }
        internal bool RightToLeft { get; private set; }
        internal bool BoomerangAnimation { get; private set; }
        internal bool AlwaysFinnish { get; private set; }
        internal bool Looping { get; private set; }

        public Animation(AnimationName _Name, IntVector2 _StartingIndex, int _FramesInAnimation, double _TimePerFrame, bool _RightToLeft, bool _BoomerangAnimation, bool _AlwaysFinnish, bool _Looping)
        {
            Name = _Name;
            StartingIndex = _StartingIndex;
            FramesInAnimation = _FramesInAnimation;
            TimerPerFrame = _TimePerFrame;
            RightToLeft = _RightToLeft;
            BoomerangAnimation = _BoomerangAnimation;
            AlwaysFinnish = _AlwaysFinnish;
            Looping = _Looping;
        }
    }
}
