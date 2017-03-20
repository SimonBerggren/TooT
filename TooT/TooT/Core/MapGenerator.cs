using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooT.Core
{
    internal static class MapGenerator
    {
        internal static Room[,] GenerateRoom(float _Difficulty=1)
        {
            Room[,] result = new Room[1, 1];
            result[0, 0] = new Room();
            return result; 
        }
    }
}
