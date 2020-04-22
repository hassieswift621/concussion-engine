using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.MegaPong.Component.Data;
using Hassie.ConcussionEngine.MegaPong.Component.Registry;
using Hassie.ConcussionEngine.MegaPong.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong.World
{
    /// <summary>
    /// The HUD displays "Pong" and the player scores.
    /// </summary>
    public class HudWorld : AbstractWorld
    {
        // The engine.
        private readonly IEngine engine;

        /// <summary>
        /// Initialises the HUD world.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="id"></param>
        /// <param name="contentManager"></param>
        /// <param name="eventManager"></param>
        public HudWorld(IEngine engine, int id, ContentManager contentManager, IEventManager eventManager) : base(id, contentManager, eventManager)
        {
            // Store engine.
            this.engine = engine;

            // Register component registry types.
            ComponentManager
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<TextRenderComponent, TextRenderCR>();
        }

        public override void Run()
        {
            // If there is no state, setup world.
            if (State == WorldState.None)
            {
                // Create a renderable text entity for "Pong".
                int pongTextID = EntityManager.CreateEntity();

                // Load font.
                SpriteFont pongFont = ContentManager.Load<SpriteFont>("Exo-2-SemiBold");

                // Create components.
                PositionComponent pongTextPosition = new PositionComponent(pongTextID, engine.ScreenWidth / 2 - 80, 50);
                TextRenderComponent pongTextSpriteFont = new TextRenderComponent(pongTextID, Color.Black, pongFont, "MEGA PONG");

                // Add components.
                ComponentManager
                    .SetComponent(pongTextPosition)
                    .SetComponent(pongTextSpriteFont);


                // Create renderable text entity for player 1 score.
                int player1ID = EntityManager.CreateEntity();

                // Load font.
                SpriteFont player1Font = ContentManager.Load<SpriteFont>("Exo-2-SemiBold");

                // Create components.
                PositionComponent player1Position = new PositionComponent(player1ID, 50, 50);
                TextRenderComponent player1SpriteFont = new TextRenderComponent(player1ID, Color.Black, player1Font, "0");

                // Add components.
                ComponentManager
                    .SetComponent(player1Position)
                    .SetComponent(player1SpriteFont);

                // Emit event.
                EventManager.Emit(new ScoreTextCreateEvent(player1ID, 1));


                // Create renderable text entity for player 2 score.
                int player2ID = EntityManager.CreateEntity();

                // Load font.
                SpriteFont player2Font = ContentManager.Load<SpriteFont>("Exo-2-SemiBold");

                // Create components.
                PositionComponent player2Position = new PositionComponent(player2ID, engine.ScreenWidth - 75, 50);
                TextRenderComponent player2SpriteFont = new TextRenderComponent(player2ID, Color.Black, player2Font, "0");

                // Add components.
                ComponentManager
                    .SetComponent(player2Position)
                    .SetComponent(player2SpriteFont);

                // Emit event.
                EventManager.Emit(new ScoreTextCreateEvent(player2ID, 2));
            }

            base.Run();
        }

        public override void Stop(bool reset)
        {
            if (reset)
            {
                // Destroy entities.
                EntityManager.DestroyEntities();
            }

            base.Stop(reset);
        }
    }
}
