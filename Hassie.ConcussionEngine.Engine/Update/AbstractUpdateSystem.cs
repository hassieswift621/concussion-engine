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
    public abstract class AbstractUpdateSystem : IDestroyable, ISystem, IUpdateSystem
    {
        protected IEngine engine;
        protected IEventManager eventManager;
        protected IWorldManager worldManager;

        public abstract void Destory();

        public void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            // Store dependencies.
            this.engine = engine;
            this.eventManager = eventManager;
            this.worldManager = worldManager;
        }

        public abstract void Update(GameTime gameTime);
    }
}
