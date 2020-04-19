using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong.Event
{
    /// <summary>
    /// Ball create event args.
    /// </summary>
    public class BallCreateEvent : EventArgs
    {
        /// <summary>
        /// The entity IDs of the balls.
        /// </summary>
        public int[] IDs { get; }

        /// <summary>
        /// Constructor for the ball create event.
        /// </summary>
        /// <param name="ids">The entity IDs of the balls.</param>
        public BallCreateEvent(int[] ids)
        {
            IDs = ids;
        }
    }
}
