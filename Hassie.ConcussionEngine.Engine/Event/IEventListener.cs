using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Event
{
    /// <summary>
    /// An event listener listens to events.
    /// </summary>
    /// <typeparam name="T">The type of event the listener listens to.</typeparam>
    public interface IEventListener<in T> where T : EventArgs
    {
        /// <summary>
        /// On event handler.
        /// </summary>
        /// <param name="sender">The event emitter.</param>
        /// <param name="args">The event args.</param>
        void OnEvent(object sender, T args);
    }
}
