using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.Update;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.Pong.Component.Data;
using Hassie.ConcussionEngine.Pong.Event;
using Hassie.ConcussionEngine.Pong.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Score
{
    /// <summary>
    /// The score system keeps track of the player's scores
    /// and updates the renderable text components with the current score.
    /// </summary>
    public class ScoreSystem : AbstractUpdateSystem, IEventListener<ScoreEvent>, IEventListener<ScoreTextCreateEvent>
    {
        // Lsit to store score events.
        private readonly IList<ScoreEvent> scoreEvents;

        private int player1Score; // Player 1 score.
        private int player2Score; // Player 2 score.
        private int player1Text; // Player 1 score text entity ID.
        private int player2Text; // Player 2 score text entity ID.

        /// <summary>
        /// Initialises the score system.
        /// </summary>
        public ScoreSystem()
        {
            // Initialise list.
            scoreEvents = new List<ScoreEvent>();
        }

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager)
        {
            base.Initialise(engine, eventManager, worldManager);

            // Hook up event listeners.
            eventManager.Subscribe<ScoreEvent>(OnEvent);
            eventManager.Subscribe<ScoreTextCreateEvent>(OnEvent);
        }

        public void OnEvent(object sender, ScoreEvent args)
        {
            // Store event.
            scoreEvents.Add(args);
        }

        public void OnEvent(object sender, ScoreTextCreateEvent args)
        {
            // Store text entity ID.
            if (args.Player == 1)
            {
                player1Text = args.ID;
            }
            else
            {
                player2Text = args.ID;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Check if there events to process.
            if (scoreEvents.Count == 0)
            {
                return;
            }

            // Get HUD world.
            IWorld world = worldManager.GetWorld((int)WorldID.HudWorld);

            // Get text render component registry.
            IComponentRegistry<TextRenderComponent> textRenders =
                (IComponentRegistry<TextRenderComponent>)world.ComponentManager.GetRegistry<TextRenderComponent>();

            foreach (ScoreEvent score in scoreEvents)
            {
                // Update score and text.
                if (score.Player == 1)
                {
                    player1Score += score.Amount;
                    TextRenderComponent component = textRenders.Get(player1Text);
                    component.Text = player1Score.ToString();
                    textRenders.Set(component);
                }
                else
                {
                    player2Score += score.Amount;
                    TextRenderComponent component = textRenders.Get(player2Text);
                    component.Text = player2Score.ToString();
                    textRenders.Set(component);
                }
            }

            // Clear list.
            scoreEvents.Clear();
        }
    }
}
