using System;

namespace TooT
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TooTGame())
                game.Run();
        }
    }
}