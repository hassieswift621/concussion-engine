using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
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
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<TransformComponent, TransformCR>()
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>();
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
                PositionComponent positionComponent = new PositionComponent(ballID, engine.ScreenWidth / 2, engine.ScreenHeight / 2);
                Texture2DRenderComponent renderComponent = new Texture2DRenderComponent(ballID, 1, ballTexture);
                TransformComponent transformComponent = new TransformComponent(ballID, ballTexture.Height, 0, 1f, ballTexture.Width);

                // Add components.
                ComponentManager
                    .SetComponent(positionComponent)
                    .SetComponent(renderComponent)
                    .SetComponent(transformComponent);
            }

            base.Run();
        }
    }
}
