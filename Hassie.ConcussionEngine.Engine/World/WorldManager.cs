using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    /// <summary>
    /// The world manager manages worlds.
    /// </summary>
    public class WorldManager : IWorldManager
    {
        // Map to store worlds.
        private readonly IDictionary<int, IWorld> worlds;

        /// <summary>
        /// Constructor for the world manager.
        /// </summary>
        public WorldManager()
        {
            // Initialise worlds map.
            worlds = new Dictionary<int, IWorld>();
        }

        public void AddWorld(IWorld world)
        {
            worlds.Add(world.ID, world);
        }

        public IWorld GetWorld(int id)
        {
            return worlds[id];
        }

        public IReadOnlyList<IWorld> GetWorldsInState(WorldState state)
        {
            List<IWorld> foundWorlds = new List<IWorld>();

            // Run through worlds and find worlds in the specified state.
            foreach (IWorld world in worlds.Values)
            {
                 if (((IWorldState)world).State == state)
                {
                    // Add to list.
                    foundWorlds.Add(world);
                }
            }

            return foundWorlds;
        }

        public void PauseWorld(int id)
        {
            ((IWorldState)worlds[id]).Pause();
        }

        public void RemoveWorld(int id)
        {
            worlds.Remove(id);
        }

        public void RunWorld(int id)
        {
            ((IWorldState)worlds[id]).Run();
        }

        public void StopWorld(int id, bool reset)
        {
            ((IWorldState)worlds[id]).Stop(reset);
        }
    }
}
