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
    /// A world is a self contained environment.
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// Gets the component manager for this world.
        /// </summary>
        IComponentManager ComponentManager { get; }

        /// <summary>
        /// Gets the MonoGame content manager for this world.
        /// </summary>
        ContentManager ContentManager { get; }

        /// <summary>
        /// Gets the entity manager for this world.
        /// </summary>
        IEntityManager EntityManager { get; }

        /// <summary>
        /// Gets the event manager.
        /// </summary>
        IEventManager EventManager { get; }

        /// <summary>
        /// Gets the ID of the world.
        /// </summary>
        int ID { get; }
    }
}
