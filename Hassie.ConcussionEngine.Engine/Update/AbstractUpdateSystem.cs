using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
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
    public abstract class AbstractUpdateSystem : ISystem, IUpdateSystem
    {
        protected IEngine engine; // The engine.
        protected IEventManager eventManager; // The event manager.
        protected IWorldManager worldManager; // The world manager.

        protected AbstractUpdateSystem() { }

        public virtual void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            // Store dependencies.
            this.engine = engine;
            this.eventManager = eventManager;
            this.worldManager = worldManager;
        }

        public abstract void Update(GameTime gameTime);
    }
}
