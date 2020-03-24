using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Event
{
    /// <summary>
    /// Ball create event args.
    /// </summary>
    public class BallCreateEvent : EventArgs
    {
        /// <summary>
        /// The entity ID of the ball.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Constructor for the ball create event.
        /// </summary>
        /// <param name="id">The entity ID of the ball.</param>
        public BallCreateEvent(int id)
        {
            ID = id;
        }
    }
}
