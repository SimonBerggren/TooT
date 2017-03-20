using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooT
{
    internal delegate void OnObjectFlaggedRemove(GameObject _Caller);

    internal enum Event
    {
        OnCallback = 0,
        OnNextRoom = 1,
        OnObjectFlaggedRemove = 2,
        OnObjectRemove = 3,
    }
}
