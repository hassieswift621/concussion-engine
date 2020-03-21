using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    /// <summary>
    /// A world manager manages game worlds.
    /// </summary>
    public interface IWorldManager
    {
        /// <summary>
        /// Adds a world.
        /// </summary>
        /// <param name="world">The world to add.</param>
        void AddWorld(IWorld world);

        /// <summary>
        /// Gets a world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        /// <returns>The world.</returns>
        IWorld GetWorld(int id);

        /// <summary>
        /// Gets worlds in a specific state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>A read only list of worlds.</returns>
        IReadOnlyList<IWorld> GetWorldsInState(WorldState state);

        /// <summary>
        /// Pauses a world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        void PauseWorld(int id);

        /// <summary>
        /// Removes a world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        void RemoveWorld(int id);

        /// <summary>
        /// Runs a world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        void RunWorld(int id);

        /// <summary>
        /// Stops a world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        /// <param name="reset">Whether to reset the state.</param>
        void StopWorld(int id, bool reset);
    }
}
