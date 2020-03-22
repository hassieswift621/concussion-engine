using Hassie.ConcussionEngine.Engine.Update;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Input
{
    /// <summary>
    /// The keyboard input system handles keyboard input.
    /// </summary>
    public class KeyboardInputSystem : AbstractUpdateSystem
    {
        // Previous keyboard state.
        private IList<Keys> state;

        /// <summary>
        /// Constructor for the keyboard input system.
        /// </summary>
        public KeyboardInputSystem()
        {
            // Initialise state to empty list.
            state = new List<Keys>();
        }

        public override void Destroy()
        {
            // Do nothing.
        }

        public override void Update(GameTime gameTime)
        {
            // Get keyboard state.
            IList<Keys> keys = Keyboard.GetState().GetPressedKeys().ToList();

            // Vars to hold pressed and released keys.
            List<Keys> pressedKeys = new List<Keys>();
            List<Keys> releasedKeys;

            // Run through new keyboard state and compare with old state.
            foreach (Keys key in keys)
            {
                // If key is not in the previous state, this is a newly pressed key.
                if (!state.Contains(key))
                {
                    pressedKeys.Add(key);
                }
                // Else, remove key from previous state.
                else
                {
                    state.Remove(key);
                }
            }

            // At this point, the previous state will contain the released keys, if any.
            releasedKeys = state.ToList();

            // Store new state.
            state = keys;

            // If pressed keys > 0 or released keys > 0, emit event.
            if (pressedKeys.Count > 0 || releasedKeys.Count > 0)
            {
                eventManager.Emit(new KeyboardInputEvent(pressedKeys, releasedKeys));
            }
        }
    }
}
