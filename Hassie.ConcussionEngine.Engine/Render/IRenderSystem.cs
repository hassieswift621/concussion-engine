using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.ConcussionEngine.Engine.Core;

namespace Hassie.ConcussionEngine.Engine.Render
{
    /// <summary>
    /// A render system performs rendering functions.
    /// </summary>
    public interface IRenderSystem
    {
        /// <summary>
        /// Initialises the system.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="worldManager">The world manager.</param>
        /// <param name="graphicsDeviceManager">The graphics device manager.</param>
        void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager,
            GraphicsDeviceManager graphicsDeviceManager);
    }
}
