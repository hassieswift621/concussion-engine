using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Input
{
    /// <summary>
    /// Keyboard input event args.
    /// </summary>
    public class KeyboardInputEvent : EventArgs
    {
        /// <summary>
        /// The pressed keys.
        /// </summary>
        public IReadOnlyList<Keys> PressedKeys { get; }

        /// <summary>
        /// The released keys.
        /// </summary>
        public IReadOnlyList<Keys> ReleasedKeys { get; }

        /// <summary>
        /// Constructor for the keyboard input event.
        /// </summary>
        /// <param name="pressedKeys">The pressed keys.</param>
        /// <param name="releasedKeys">The released keys.</param>
        public KeyboardInputEvent(IReadOnlyList<Keys> pressedKeys, IReadOnlyList<Keys> releasedKeys)
        {
            // Store data.
            PressedKeys = pressedKeys;
            ReleasedKeys = releasedKeys;
        }
    }
}
