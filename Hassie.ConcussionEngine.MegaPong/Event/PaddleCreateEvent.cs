using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong.Event
{
    /// <summary>
    /// Player create event args.
    /// </summary>
    public class PaddleCreateEvent : EventArgs
    {
        /// <summary>
        /// The entity ID of the paddle.
        /// </summary>
        public int PaddleID { get; }

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public int PlayerID { get; }

        /// <summary>
        /// Constructor for the paddle create event.
        /// </summary>
        /// <param name="paddleID">The entity ID of the paddle.</param>
        /// <param name="playerID">The ID of the player.</param>
        public PaddleCreateEvent(int paddleID, int playerID)
        {
            PaddleID = paddleID;
            PlayerID = playerID;
        }
    }
}
