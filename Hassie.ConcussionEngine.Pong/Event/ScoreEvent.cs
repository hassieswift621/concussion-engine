using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Event
{
    /// <summary>
    /// Score event args.
    /// </summary>
    public class ScoreEvent : EventArgs
    {
        /// <summary>
        /// The amount to adjust the score by.
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// The player no.
        /// </summary>
        public int Player { get; }

        /// <summary>
        /// Initialises the score event.
        /// </summary>
        /// <param name="amount">The amount to adjust the score by.</param>
        /// <param name="player">The player to modify the score for.</param>
        public ScoreEvent(int amount, int player)
        {
            Amount = amount;
            Player = player;
        }
    }
}
