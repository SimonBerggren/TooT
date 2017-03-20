using System;
using System.Collections.Generic;

namespace TooT
{
    internal static class EventManager
    {
        private static Dictionary<Event, Delegate> mCallbacks;

        internal static void Initialize()
        {
            mCallbacks = new Dictionary<Event, Delegate>();
            foreach (Event E in Enum.GetValues(typeof(Event)))
                mCallbacks.Add(E, null);
        }

        internal static void Fire(Event _EventId, params object[] args)
        {
            Delegate callback = mCallbacks[_EventId];
            if (callback != null)
            {
                Delegate[] list = callback.GetInvocationList();
                int length = list.GetLength(0);
                for (int i = 0; i < length; i++)
                    list[i].DynamicInvoke(args);
            }
        }

        internal static void Subscribe(Event _EventId, Delegate _Callback)
        {
            mCallbacks[_EventId] = Delegate.Combine(mCallbacks[_EventId], _Callback);
        }

        internal static void Unsubscribe(Event _EventId, Delegate _Callback)
        {
            mCallbacks[_EventId] = Delegate.Remove(mCallbacks[_EventId], _Callback);
        }

        internal static void ClearSubscriptions(Event _EventId)
        {
            mCallbacks[_EventId] = null;
        }

        internal static void ClearSubscriptions()
        {
            mCallbacks.Clear();
        }
    }
}