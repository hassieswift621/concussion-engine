using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.Input;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Update;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.MegaPong.Event;
using Hassie.ConcussionEngine.MegaPong.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong.Input
{
    /// <summary>
    /// Player input system.
    /// </summary>
    public class PlayerInputSystem : AbstractUpdateSystem, IDestroyable, IEventListener<PaddleCreateEvent>, IEventListener<KeyboardInputEvent>
    {
        private int playerA; // Entity ID of paddle A.
        private int playerB; // Entity ID of paddle B.

        private KeyboardInputEvent inputEvent; // Input event args.
        private bool processed = true; // Whether input has been processed.

        public void Destroy()
        {
            // Unsubscribe event listeners.
            eventManager.Unsubscribe<KeyboardInputEvent>(OnEvent);
            eventManager.Unsubscribe<PaddleCreateEvent>(OnEvent);
        }

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            base.Initialise(engine, eventManager, worldManager);

            // Subscribe event listeners.
            eventManager.Subscribe<KeyboardInputEvent>(OnEvent);
            eventManager.Subscribe<PaddleCreateEvent>(OnEvent);
        }

        public void OnEvent(object sender, KeyboardInputEvent args)
        {
            // Store event.
            inputEvent = args;
            processed = false;
        }

        public void OnEvent(object sender, PaddleCreateEvent args)
        {
            // Store entity ID of paddle.
            if (args.PlayerID == 1)
            {
                playerA = args.PaddleID;
            }
            else
            {
                playerB = args.PaddleID;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // If there is no new input, return.
            if (processed)
            {
                return;
            }

            // Get pong world.
            IWorld world = worldManager.GetWorld((int)WorldID.PongWorld);

            // Get paddle physics components.
            PhysicsComponent paddleA = world.ComponentManager.GetComponent<PhysicsComponent>(playerA);
            PhysicsComponent paddleB = world.ComponentManager.GetComponent<PhysicsComponent>(playerB);

            // Player 1.
            if (inputEvent.PressedKeys.Contains(Keys.W))
            {
                // Move paddle upwards.
                paddleA.VelocityY = -200;
            }
            else if (inputEvent.PressedKeys.Contains(Keys.S))
            {
                // Move paddle downwards.
                paddleA.VelocityY = 200;
            }
            else if (inputEvent.ReleasedKeys.Contains(Keys.W) || inputEvent.ReleasedKeys.Contains(Keys.S))
            {
                // Stop moving paddle.
                paddleA.VelocityY = 0;
            }

            // Player 2.
            if (inputEvent.PressedKeys.Contains(Keys.Up))
            {
                // Move paddle upwards.
                paddleB.VelocityY = -200;
            }
            else if (inputEvent.PressedKeys.Contains(Keys.Down))
            {
                // Move paddle downwards.
                paddleB.VelocityY = 200;
            }
            else if (inputEvent.ReleasedKeys.Contains(Keys.Up) || inputEvent.ReleasedKeys.Contains(Keys.Down))
            {
                // Stop moving paddle.
                paddleB.VelocityY = 0;
            }

            // Update components.
            world.ComponentManager.SetComponent(paddleA);
            world.ComponentManager.SetComponent(paddleB);

            // Set input processed to true.
            processed = true;
        }
    }
}
