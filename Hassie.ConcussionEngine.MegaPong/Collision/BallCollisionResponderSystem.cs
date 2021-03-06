﻿using Hassie.ConcussionEngine.Engine.Collision;
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

namespace Hassie.ConcussionEngine.MegaPong.Collision
{
    public class BallCollisionResponderSystem : AbstractUpdateSystem, IDestroyable,
        IEventListener<BallCreateEvent>, IEventListener<CollisionEvent>, IEventListener<PaddleCreateEvent>
    {
        private int[] ballIDs; // The entity IDs of the balls.
        private int paddleAID; // The entity ID of player one's paddle.
        private int paddleBID; // The entity ID of player two's paddle.

        private IList<CollisionEvent> collisionEvents; // Collision event args.

        /// <summary>
        /// Initialises the ball collision responder system.
        /// </summary>
        public BallCollisionResponderSystem()
        {
            // Initialise collision events list.
            collisionEvents = new List<CollisionEvent>();
        }

        public void Destroy()
        {
            // Unsubscribe event listeners.
            eventManager.Unsubscribe<BallCreateEvent>(OnEvent);
            eventManager.Unsubscribe<CollisionEvent>(OnEvent);
            eventManager.Unsubscribe<PaddleCreateEvent>(OnEvent);
        }

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            base.Initialise(engine, eventManager, worldManager);

            // Subscribe event listeners.
            eventManager.Subscribe<BallCreateEvent>(OnEvent);
            eventManager.Subscribe<CollisionEvent>(OnEvent);
            eventManager.Subscribe<PaddleCreateEvent>(OnEvent);
        }

        public void OnEvent(object sender, BallCreateEvent args)
        {
            // Store entity ID.
            ballIDs = args.IDs;
        }

        public void OnEvent(object sender, CollisionEvent args)
        {
            // If the collider is not a ball, return.
            if (!ballIDs.Contains(args.Collider))
            {
                return;
            }

            // Store args.
            collisionEvents.Add(args);
        }

        public void OnEvent(object sender, PaddleCreateEvent args)
        {
            // Store entity ID.
            if (args.PlayerID == 1)
            {
                paddleAID = args.PaddleID;
            }
            else
            {
                paddleBID = args.PaddleID;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // If there are no new events, return.
            if (collisionEvents.Count == 0)
            {
                return;
            }

            // Get pong world.
            IWorld world = worldManager.GetWorld((int)WorldID.PongWorld);

            // Iterate events.
            foreach (CollisionEvent collisionEvent in collisionEvents)
            {
                // Get ball physics component.
                PhysicsComponent physics = world.ComponentManager.GetComponent<PhysicsComponent>(collisionEvent.Collider);

                // If the colliding entity was paddle A, set velocity to positive and increase its velocity.
                if (collisionEvent.Collidable == paddleAID && Math.Sign(physics.VelocityX) == -1)
                {
                    physics.VelocityX *= -1.25f;
                }
                // Else if colliding entity was paddle B, set velocity to negative and increase velocity.
                else if (collisionEvent.Collidable == paddleBID && Math.Sign(physics.VelocityX) == 1)
                {
                    physics.VelocityX *= -1.25f;
                }

                // Update component.
                world.ComponentManager.SetComponent(physics);
            }

            // Clear event list.
            collisionEvents.Clear();
        }
    }
}
