using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Event
{
    /// <summary>
    /// Score text create event args.
    /// </summary>
    public class ScoreTextCreateEvent : EventArgs
    {
        /// <summary>
        /// The ID of the text entity.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// The player no.
        /// </summary>
        public int Player { get; }

        /// <summary>
        /// Initialises the score text create event.
        /// </summary>
        /// <param name="id">The ID of the text entity.</param>
        /// <param name="player">The player no.</param>
        public ScoreTextCreateEvent(int id, int player)
        {
            ID = id;
            Player = player;
        }
    }
}
