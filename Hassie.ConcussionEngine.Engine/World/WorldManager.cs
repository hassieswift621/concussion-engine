using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    public class WorldManager : IWorldManager
    {
        private readonly IDictionary<int, IWorld> worlds;

        public WorldManager()
        {
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
