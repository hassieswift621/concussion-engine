using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.System
{
    /// <summary>
    /// An engine system handles a single part of the engine.
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// Updates the system.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void Update(GameTime gameTime);
    }
}
