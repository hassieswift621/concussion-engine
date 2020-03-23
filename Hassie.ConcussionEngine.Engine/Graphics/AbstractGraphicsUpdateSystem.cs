using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Graphics
{
    /// <summary>
    /// A graphics update system performs graphics functions
    /// using the <see cref="GraphicsDeviceManager"/>.
    /// </summary>
    public abstract class AbstractGraphicsUpdateSystem : IGraphicsUpdateSystem, ISystem
    {
        protected IEngine engine; // The engine.
        protected IEventManager eventManager; // The event manager.
        protected IWorldManager worldManager; // The world manager.
        protected GraphicsDeviceManager graphicsDeviceManager; // The graphics device manager.

        protected AbstractGraphicsUpdateSystem() { }

        public virtual void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager,
            GraphicsDeviceManager graphicsDeviceManager)
        {
            // Store dependencies.
            this.engine = engine;
            this.eventManager = eventManager;
            this.worldManager = worldManager;
            this.graphicsDeviceManager = graphicsDeviceManager;
        }

        public abstract void Update(GameTime gameTime);
    }
}
