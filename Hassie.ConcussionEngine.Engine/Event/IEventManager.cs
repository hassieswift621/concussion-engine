using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Event
{
    /// <summary>
    /// An event manager handles the events for the engine and the game.
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Emits an event.
        /// </summary>
        /// <typeparam name="T">The type of event.</typeparam>
        /// <param name="data">The event data.</param>
        void Emit<T>(T args) where T : EventArgs;

        /// <summary>
        /// Subscribes an event listener.
        /// </summary>
        /// <typeparam name="T">The type of event the listener listens to.</typeparam>
        /// <param name="listener">The event listener.</param>
        void Subscribe<T>(EventHandler<T> listener) where T : EventArgs;

        /// <summary>
        /// Unsubscribes an event listener.
        /// </summary>
        /// <typeparam name="T">The type of event the listener listens to.</typeparam>
        /// <param name="listener">The event listener.</param>
        void Unsubscribe<T>(EventHandler<T> listener) where T : EventArgs;
    }
}
