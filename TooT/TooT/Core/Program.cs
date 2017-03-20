using System;

namespace TooT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TooTGame())
                game.Run();
        }
    }
}