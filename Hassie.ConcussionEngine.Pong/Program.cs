using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Pong())
            {
                game.Run();
            }
        }
    }
}
