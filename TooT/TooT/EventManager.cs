﻿using System;
using System.Collections.Generic;

namespace TooT
{
    public delegate void OnCallback(string param);

    public enum Event
    {
        OnCallback = 0,
    }

    public static class EventManager
    {
        private static Dictionary<Event, MulticastDelegate> mCallbacks;

        public static void Initialize()
        {
            mCallbacks = new Dictionary<Event, MulticastDelegate>();
            mCallbacks.Add(Event.OnCallback, null);
        }

        public static void Fire(Event _EventId, params object[] args)
        {
            MulticastDelegate callback = mCallbacks[_EventId];
            if (callback != null)
            {
                Delegate[] list = callback.GetInvocationList();
                int length = list.GetLength(0);
                for (int i = 0; i < length; i++)
                    list[i].DynamicInvoke(args);
            }
        }

        public static void Subscribe(Event _EventId, MulticastDelegate _Callback)
        {
            mCallbacks[_EventId] = (MulticastDelegate)Delegate.Combine(mCallbacks[_EventId], _Callback);
        }

        public static void Unsubscribe(Event _EventId, MulticastDelegate _Callback)
        {
            mCallbacks[_EventId] = (MulticastDelegate)Delegate.Remove(mCallbacks[_EventId], _Callback);
        }

        public static void ClearSubscriptions(Event _EventId)
        {
            mCallbacks[_EventId] = null;
        }

        public static void ClearSubscriptions()
        {
            mCallbacks.Clear();
        }
    }
}