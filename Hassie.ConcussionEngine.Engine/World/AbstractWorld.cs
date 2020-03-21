using Hassie.ConcussionEngine.Engine.Component.Manager;
using Hassie.ConcussionEngine.Engine.Entity;
using Hassie.ConcussionEngine.Engine.Event;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    /// <summary>
    /// A world is a self contained environment with its own state.
    /// All defined worlds should extend this class.
    /// </summary>
    public abstract class AbstractWorld : IWorld, IWorldState
    {
        public IComponentManager ComponentManager { get; }

        public ContentManager ContentManager { get; }

        public IEntityManager EntityManager { get; }

        public IEventManager EventManager { get; }

        /// <summary>
        /// Gets or sets the world state.
        /// </summary>
        public WorldState State { get; private set; } = WorldState.None;

        public int ID { get; }

        /// <summary>
        /// Constructor for the world.
        /// </summary>
        /// <param name="id">The ID of the world.</param>
        /// <param name="contentManager">The MonoGame content manager for this world.</param>
        /// <param name="eventManager">The event manager.</param>
        protected AbstractWorld(int id, ContentManager contentManager, IEventManager eventManager)
        {
            // Store ID and dependencies.
            ID = id;
            ContentManager = contentManager;
            EventManager = eventManager;

            // Initialise component manager and entity manager.
            ComponentManager = new ComponentManager();
            EntityManager = new EntityManager((IComponentTerminator)ComponentManager);
        }

        public virtual void Pause()
        {
            State = WorldState.Paused;
        }

        public virtual void Run()
        {
            State = WorldState.Running;
        }

        public virtual void Stop(bool reset)
        {
            State = reset ? WorldState.None : WorldState.Stopped;
        }
    }
}
