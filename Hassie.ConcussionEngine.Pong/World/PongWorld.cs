using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.Pong.Event;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.World
{
    /// <summary>
    /// Main game world.
    /// </summary>
    public class PongWorld : AbstractWorld
    {
        // The engine.
        private readonly IEngine engine;

        /// <summary>
        /// Constructor for the pong world.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="id"></param>
        /// <param name="contentManager"></param>
        /// <param name="eventManager"></param>
        public PongWorld(IEngine engine, int id, ContentManager contentManager, IEventManager eventManager) : base(id, contentManager, eventManager)
        {
            // Store engine.
            this.engine = engine;

            // Register component registry types.
            ComponentManager
                .RegisterType<CollidableComponent, CollidableComponentCR>()
                .RegisterType<HitboxCollisionComponent, HitboxCollisionCR>()
                .RegisterType<PhysicsComponent, PhysicsComponentCR>()
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>()
                .RegisterType<TransformComponent, TransformCR>();
        }

        public override void Run()
        {
            // If there is no state, setup world.
            if (State == WorldState.None)
            {
                // Create ball.
                int ballID = EntityManager.CreateEntity();

                // Load texture.
                Texture2D ballTexture = ContentManager.Load<Texture2D>("square");

                // Create components.
                HitboxCollisionComponent ballHitbox = new HitboxCollisionComponent(ballID);
                PhysicsComponent ballPhysics = new PhysicsComponent(ballID, 0, 0, 0, 0, 1, 150, 150);
                PositionComponent ballPosition = new PositionComponent(ballID, 
                    (engine.ScreenWidth / 2) - (ballTexture.Width / 2), (engine.ScreenHeight / 2) - (ballTexture.Height / 2));
                Texture2DRenderComponent ballRender = new Texture2DRenderComponent(ballID, 1, ballTexture);
                TransformComponent ballTransform = new TransformComponent(ballID, ballTexture.Height, 0, 1, ballTexture.Width);

                // Add components.
                ComponentManager
                    .SetComponent(ballHitbox)
                    .SetComponent(ballPhysics)
                    .SetComponent(ballPosition)
                    .SetComponent(ballRender)
                    .SetComponent(ballTransform);

                // Emit ball create event.
                EventManager.Emit(new BallCreateEvent(ballID));


                // Create player one paddle.
                int paddleAID = EntityManager.CreateEntity();

                // Load texture.
                Texture2D paddleATexture = ContentManager.Load<Texture2D>("paddle");

                // Create components.
                CollidableComponent paddleACollidable = new CollidableComponent(paddleAID);
                PhysicsComponent paddleAPhysics = new PhysicsComponent(paddleAID, 0, 0, 0, 0, 1, 0, 0);
                PositionComponent paddleAPosition = new PositionComponent(paddleAID, 0, (engine.ScreenHeight / 2) - (paddleATexture.Height / 2));
                Texture2DRenderComponent paddleARender = new Texture2DRenderComponent(paddleAID, 2, paddleATexture);
                TransformComponent paddleATransform = new TransformComponent(paddleAID, paddleATexture.Height, 0, 1, paddleATexture.Width);

                // Add components.
                ComponentManager
                    .SetComponent(paddleACollidable)
                    .SetComponent(paddleAPhysics)
                    .SetComponent(paddleAPosition)
                    .SetComponent(paddleARender)
                    .SetComponent(paddleATransform);

                // Emit paddle create event.
                EventManager.Emit(new PaddleCreateEvent(paddleAID, 1));


                // Create player two paddle.
                int paddleBID = EntityManager.CreateEntity();

                // Load texture.
                Texture2D paddleBTexture = ContentManager.Load<Texture2D>("paddle");

                // Create components.
                CollidableComponent paddleBCollidable = new CollidableComponent(paddleBID);
                PhysicsComponent paddleBPhysics = new PhysicsComponent(paddleBID, 0, 0, 0, 0, 1, 0, 0);
                PositionComponent paddleBPosition = new PositionComponent(paddleBID, (engine.ScreenWidth - paddleBTexture.Width), 
                    (engine.ScreenHeight / 2) - (paddleBTexture.Height / 2));
                Texture2DRenderComponent paddleBRender = new Texture2DRenderComponent(paddleBID, 2, paddleBTexture);
                TransformComponent paddleBTransform = new TransformComponent(paddleBID, paddleBTexture.Height, 0, 1, paddleBTexture.Width);

                // Add components.
                ComponentManager
                    .SetComponent(paddleBCollidable)
                    .SetComponent(paddleBPhysics)
                    .SetComponent(paddleBPosition)
                    .SetComponent(paddleBRender)
                    .SetComponent(paddleBTransform);

                // Emit paddle create event.
                EventManager.Emit(new PaddleCreateEvent(paddleBID, 2));
            }

            base.Run();
        }

        public override void Stop(bool reset)
        {
            // If reset, destroy all entities.
            if (reset)
            {
                EntityManager.DestroyEntities();
            }

            base.Stop(reset);
        }
    }
}
