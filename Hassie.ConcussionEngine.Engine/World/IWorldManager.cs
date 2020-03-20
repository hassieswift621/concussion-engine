using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    public interface IWorldManager
    {
        void AddWorld(IWorld world);

        IWorld GetWorld(int id);

        IReadOnlyList<IWorld> GetWorldsInState(WorldState state);

        void PauseWorld(int id);

        void RemoveWorld(int id);

        void RunWorld(int id);

        void StopWorld(int id, bool reset);
    }
}
