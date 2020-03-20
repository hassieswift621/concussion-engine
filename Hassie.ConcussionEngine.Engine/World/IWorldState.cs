using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    public interface IWorldState
    {
        WorldState State { get; }

        void Pause();

        void Run();

        void Stop(bool reset);
    }
}
