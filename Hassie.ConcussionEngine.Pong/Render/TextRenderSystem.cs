using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.Render;
using Hassie.ConcussionEngine.Engine.World;
using Hassie.ConcussionEngine.Pong.Component.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Render
{
    /// <summary>
    /// The text render system renders text.
    /// </summary>
    public class TextRenderSystem : AbstractRenderSystem
    {
        // The sprite batch used to render.
        private SpriteBatch spriteBatch;

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager, GraphicsDeviceManager graphicsDeviceManager)
        {
            base.Initialise(engine, eventManager, worldManager, graphicsDeviceManager);

            // Initialise sprite batch if graphics device is not null.
            // Otherwise hook up graphics device create event.
            if (graphicsDeviceManager.GraphicsDevice != null)
            {
                spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            }
            else
            {
                graphicsDeviceManager.DeviceCreated += GraphicsDeviceManager_DeviceCreated;
            }
        }

        /// <summary>
        /// Graphics device manager create event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsDeviceManager_DeviceCreated(object sender, EventArgs e)
        {
            // Initialise sprite batch.
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            // Get running worlds.
            IReadOnlyList<IWorld> worlds = worldManager.GetWorldsInState(WorldState.Running);

            // Iterate through worlds.
            foreach (IWorld world in worlds)
            {
                // Check if the world has the sprite font component.
                if (!world.ComponentManager.ContainsRegistry<TextRenderComponent>())
                {
                    continue;
                }

                // Get component registries.
                IComponentRegistry<PositionComponent> positionComponents =
                    (IComponentRegistry<PositionComponent>)world.ComponentManager.GetRegistry<PositionComponent>();
                IComponentRegistry<TextRenderComponent> spriteFontComponents =
                    (IComponentRegistry<TextRenderComponent>)world.ComponentManager.GetRegistry<TextRenderComponent>();

                // Begin sprite batch.
                spriteBatch.Begin();

                // Iterate through sprite font components and render.
                foreach (TextRenderComponent component in spriteFontComponents)
                {
                    // Get position.
                    PositionComponent position = positionComponents.Get(component.EntityID);

                    // Render text.
                    spriteBatch.DrawString(component.Font, component.Text, new Vector2(position.X, position.Y), component.Colour);
                }

                // End sprite batch.
                spriteBatch.End();
            }
        }
    }
}
