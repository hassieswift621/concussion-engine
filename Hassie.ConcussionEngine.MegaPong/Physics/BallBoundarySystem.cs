using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Update;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.MegaPong.Event;
using Hassie.ConcussionEngine.MegaPong.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong.Physics
{
    /// <summary>
    /// The ball boundary system replaces the ball in the middle of the screen if the ball goes off screen.
    /// The system also fires score events when the ball goes off the screen.
    /// </summary>
    public class BallBoundarySystem : AbstractUpdateSystem, IDestroyable, IEventListener<BallCreateEvent>
    {
        private int[] ballIDs; // The entity IDs of the balls.

        public void Destroy()
        {
            // Unsubscribe event listeners.
            eventManager.Unsubscribe<BallCreateEvent>(OnEvent);
        }

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            base.Initialise(engine, eventManager, worldManager);

            // Subscribe event listeners.
            eventManager.Subscribe<BallCreateEvent>(OnEvent);
        }

        public void OnEvent(object sender, BallCreateEvent args)
        {
            // Store entity IDs of the balls.
            ballIDs = args.IDs;
        }

        public override void Update(GameTime gameTime)
        {
            // Get pong world.
            IWorld world = worldManager.GetWorld((int)WorldID.PongWorld);

            // Iterate ball IDs.
            foreach (int id in ballIDs)
            {
                // Get ball position and physics.
                PhysicsComponent physics = world.ComponentManager.GetComponent<PhysicsComponent>(id);
                PositionComponent position = world.ComponentManager.GetComponent<PositionComponent>(id);

                // Flag to store whether the ball has been reset.
                bool reset = false;

                // If the ball is off screen on x axis, replace in middle, reset velocity and emit score event.
                if (position.X <= 0 && Math.Sign(physics.VelocityX) == -1)
                {
                    physics.VelocityX = 150;
                    eventManager.Emit(new ScoreEvent(1, 2));
                    reset = true;
                }
                else if (position.X >= engine.ScreenWidth && Math.Sign(physics.VelocityX) == 1)
                {
                    physics.VelocityX = -150;
                    eventManager.Emit(new ScoreEvent(1, 1));
                    reset = true;
                }

                // Check flag
                if (reset)
                {
                    // Get ball texture.
                    Texture2DRenderComponent texture = world.ComponentManager.GetComponent<Texture2DRenderComponent>(id);

                    // Update position.
                    position.X = (engine.ScreenWidth / 2) - (texture.Texture.Width / 2);
                    position.Y = (engine.ScreenHeight / 2) - (texture.Texture.Height / 2);

                    // Update components.
                    world.ComponentManager.SetComponent(physics);
                    world.ComponentManager.SetComponent(position);
                }

                // If ball is off y axis, flip direction.
                if (position.Y >= engine.ScreenHeight && Math.Sign(physics.VelocityY) == 1)
                {
                    physics.VelocityY = -150;
                    world.ComponentManager.SetComponent(physics);
                }
                else if (position.Y <= 0 && Math.Sign(physics.VelocityY) == -1)
                {
                    physics.VelocityY = 150;
                    world.ComponentManager.SetComponent(physics);
                }
            }
        }
    }
}