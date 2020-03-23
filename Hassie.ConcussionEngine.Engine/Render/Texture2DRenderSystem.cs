using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Render
{
    /// <summary>
    /// Renders <see cref="Texture2D"/> components.
    /// </summary>
    public class Texture2DRenderSystem : AbstractRenderSystem, IDestroyable
    {
        // The sprite batch used to render.
        private SpriteBatch spriteBatch;

        public void Destroy()
        {
            // Dispose sprite batch.
            spriteBatch.Dispose();
        }

        public override void Initialise(IEngine engine, IEventManager eventManager, IWorldManager worldManager, GraphicsDeviceManager graphicsDeviceManager)
        {
            base.Initialise(engine, eventManager, worldManager, graphicsDeviceManager);

            // Hook up on create event for graphics device manager.
            graphicsDeviceManager.DeviceCreated += GraphicsDeviceManager_DeviceCreated;
        }

        /// <summary>
        /// Graphics device on create event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsDeviceManager_DeviceCreated(object sender, EventArgs e)
        {
            // Create sprite batch.
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            IReadOnlyList<IWorld> worlds;

            // Get running worlds.
            worlds = worldManager.GetWorldsInState(WorldState.Running);

            // Run through running worlds and render.
            foreach (IWorld world in worlds)
            {
                RenderWorld(world);
            }

            // Get paused worlds.
            worlds = worldManager.GetWorldsInState(WorldState.Paused);

            // Run through paused worlds and render.
            foreach (IWorld world in worlds)
            {
                RenderWorld(world);
            }
        }

        /// <summary>
        /// Renders a world.
        /// </summary>
        /// <param name="world">The world to render.</param>
        private void RenderWorld(IWorld world)
        {
            // Get required component registries.
            IComponentRegistry<PositionComponent> positionComponents =
                (IComponentRegistry<PositionComponent>)world.ComponentManager.GetRegistry<PositionComponent>();
            IComponentRegistry<Texture2DRenderComponent> texture2DComponents =
                (IComponentRegistry<Texture2DRenderComponent>)world.ComponentManager.GetRegistry<Texture2DRenderComponent>();
            IComponentRegistry<TransformComponent> transformComponents =
                (IComponentRegistry<TransformComponent>)world.ComponentManager.GetRegistry<TransformComponent>();

            // Begin sprite batch.
            spriteBatch.Begin();

            // Iterate Texture 2D components.
            for (int i = 0; i < texture2DComponents.Count; i++)
            {
                // Get components.
                Texture2DRenderComponent texture = texture2DComponents[i];
                PositionComponent position = positionComponents.Get(texture.EntityID);
                TransformComponent transform = transformComponents.Get(texture.EntityID);

                // Render.
                spriteBatch.Draw(texture.Texture, new Vector2(position.X, position.Y), null, Color.White,
                    transform.Rotation, new Vector2(0, 0), transform.Scale, SpriteEffects.None, 0);
            }

            // End sprite batch.
            spriteBatch.End();
        }
    }
}
