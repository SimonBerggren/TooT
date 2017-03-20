using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    internal enum SceneState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Inactive,
    }
    internal abstract class Scene
    {
        internal bool IsPopup { get; private set; } = false;
        internal bool IsClosing { get; private set; } = false;
        internal bool IsCovered { get; private set; } = false;
        internal bool IsActive { get { return mState == SceneState.Active; } }
        internal bool IsTransitioning { get { return mState == SceneState.TransitionOn || mState == SceneState.TransitionOff; } }

        // time it takes to transition on / off scene in seconds
        protected float mTransitionOffTime = 0.0f;
        protected float mTransitionOnTime = 0.0f;
        protected float mTransitionStatus = 0.0f;   // percentage of transition (1 = active, 0 = inactive)
        protected SceneState mState;

        internal Scene(bool _IsPopup = false)
        {
            IsPopup = _IsPopup;
            mState = SceneState.TransitionOn;

        }

        internal void Set_IsCovered(bool _IsCovered) { IsCovered = _IsCovered; }
        internal void Wake() { mState = SceneState.TransitionOn; }
        internal void Close() { Close(false); }               // helper method so we can bind menu actions without parameters
        internal void GoIdle() { Close(true); }                // helper method so we can bind menu actions without parameters
        private void Close(bool _GoIdle)
        {
            SceneManager.CloseScene(this);
            mState = SceneState.TransitionOff;
            IsClosing = !_GoIdle;
        }

        // can't just check if transition is complete by checking transitionStatus
        // we need to run another round of transitions with transitionStatus full
        private bool finishedTransition = false;
        // return true when finished transitioning
        internal virtual bool HandleTransition(GameTime _GT)
        {
            if (finishedTransition) {
                finishedTransition = false;
                mState++;
                return true;
            }

            float delta = (mState == SceneState.TransitionOn) ?
                (float)_GT.ElapsedGameTime.TotalSeconds / mTransitionOnTime
            :
                delta = -(float)_GT.ElapsedGameTime.TotalSeconds / mTransitionOffTime;

            mTransitionStatus = MathHelper.Clamp(mTransitionStatus + delta, 0.0f, 1.0f);

            if (mTransitionStatus == 0.0f || mTransitionStatus == 1.0f)
                finishedTransition = true;

            return false;
        }

        internal virtual void HandleInput() { }

        internal virtual void Update(GameTime _GT) { }

        internal virtual void Draw(SpriteBatch _SB) { }
    }
}