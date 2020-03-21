using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Update
{
    /// <summary>
    /// An update system performs general functions.
    /// </summary>
    public interface IUpdateSystem
    {
        /// <summary>
        /// Initialises the system.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="worldManager">The world manager.</param>
        void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager);
    }
}
