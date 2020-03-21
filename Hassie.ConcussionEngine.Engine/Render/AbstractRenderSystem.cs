using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Render
{
    /// <summary>
    /// A render system performs rendering functions.
    /// </summary>
    public abstract class AbstractRenderSystem : IDestroyable, IRenderSystem, ISystem
    {
        protected IEngine engine; // The engine.
        protected IEventManager eventManager; // The event manager.
        protected IWorldManager worldManager; // The world manager.
        protected GraphicsDeviceManager graphicsDeviceManager; // The graphics device manager.

        public abstract void Destory();

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
