using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    /// <summary>
    /// An interface to change the state of a world.
    /// </summary>
    public interface IWorldState
    {
        /// <summary>
        /// Gets the state.
        /// </summary>
        WorldState State { get; }

        /// <summary>
        /// Pauses the world.
        /// </summary>
        void Pause();

        /// <summary>
        /// Runs the world.
        /// </summary>
        void Run();

        /// <summary>
        /// Stops the world.
        /// </summary>
        /// <param name="reset">Whether to reset the state.</param>
        void Stop(bool reset);
    }
}
