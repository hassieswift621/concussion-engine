using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Event
{
    /// <summary>
    /// The event manager handles the events for the engine and the game.
    /// </summary>
    public class EventManager : IEventManager
    {
        // Map of event listeners.
        // The key is the type of event the listener handles, which extend from EventArgs.
        // The value is the event handler, stored as a generic object to allow for a generic event manager.
        private readonly IDictionary<Type, object> listeners;

        /// <summary>
        /// Constructor for the event manager.
        /// </summary>
        public EventManager()
        {
            // Initialise listeners map.
            listeners = new Dictionary<Type, object>();
        }

        public void Emit<T>(T data) where T : EventArgs
        {
            // If there aren't listeners for the type, return.
            if (!listeners.ContainsKey(typeof(T)))
            {
                return;
            }

            // Emit event.
            if (listeners.ContainsKey(typeof(T)))
            {
                EventHandler<T> handler = (EventHandler<T>)listeners[typeof(T)];
                handler?.Invoke(this, data);
            }
        }

        public void Subscribe<T>(EventHandler<T> listener) where T : EventArgs
        {
            // Check if are there listeners for this event.
            // If true, subscribe.
            // Else, add as a new event listener.
            if (listeners.ContainsKey(typeof(T)))
            {
                EventHandler<T> handler = (EventHandler<T>)listeners[typeof(T)];
                handler += listener;
                listeners[typeof(T)] = handler;
            }
            else
            {
                listeners[typeof(T)] = listener;
            }
        }

        public void Unsubscribe<T>(EventHandler<T> listener) where T : EventArgs
        {
            // If there aren't listeners for the event type, return.
            if (!listeners.ContainsKey(typeof(T)))
            {
                return;
            }

            // Get event listener and unsubscribe.
            EventHandler<T> handler = (EventHandler<T>)listeners[typeof(T)];
            handler -= listener;
            listeners[typeof(T)] = handler;
        }
    }
}
