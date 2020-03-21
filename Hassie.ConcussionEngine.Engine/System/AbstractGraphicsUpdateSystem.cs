using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.System
{
    /// <summary>
    /// A graphics update system performs graphics functions
    /// using the <see cref="GraphicsDeviceManager"/>.
    /// </summary>
    public abstract class AbstractGraphicsUpdateSystem : IDestroyable, IGraphicsUpdateSystem, ISystem
    {
        protected IEngine engine;
        protected IEventManager eventManager;
        protected IWorldManager worldManager;
        protected GraphicsDeviceManager graphicsDeviceManager;

        protected AbstractGraphicsUpdateSystem() { }

        public abstract void Destory();

        public void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager, 
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
