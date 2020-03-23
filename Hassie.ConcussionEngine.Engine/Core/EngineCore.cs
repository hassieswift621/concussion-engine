using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.Graphics;
using Hassie.ConcussionEngine.Engine.Render;
using Hassie.ConcussionEngine.Engine.System;
using Hassie.ConcussionEngine.Engine.Update;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Core
{
    /// <summary>
    /// The engine provides all of the required components and systems for a game.
    /// This class is to be extended by a game.
    /// </summary>
    public abstract class EngineCore : Game, IEngine
    {
        // Event manager.
        protected readonly IEventManager eventManager;

        // Graphics device manager.
        protected readonly GraphicsDeviceManager graphicsDeviceManager;

        // Graphics update systems.
        protected readonly IList<ISystem> graphicsUpdateSystems;

        // Render systems.
        protected readonly IList<ISystem> renderSystems;

        // Update systems.
        protected readonly IList<ISystem> updateSystems;

        // World manager.
        protected readonly IWorldManager worldManager;

        public ContentManager ContentManager => Content;

        public int ScreenHeight => graphicsDeviceManager.PreferredBackBufferHeight;

        public int ScreenWidth => graphicsDeviceManager.PreferredBackBufferWidth;

        public IServiceProvider ServiceProvider => Services;

        /// <summary>
        /// Constructor for the engine.
        /// </summary>
        protected EngineCore()
        {
            // Initialise graphics device manager.
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Set root content directory.
            ContentManager.RootDirectory = "Content";

            // Initialise event manager.
            eventManager = new EventManager();

            // Initialise world manager.
            worldManager = new WorldManager();

            // Initialise systems lists.
            graphicsUpdateSystems = new List<ISystem>();
            renderSystems = new List<ISystem>();
            updateSystems = new List<ISystem>();
        }

        /// <summary>
        /// Renders the game.
        /// This method must be overriden in order to flush the graphics device.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Update render systems.
            foreach (ISystem system in renderSystems)
            {
                system.Update(gameTime);
            }
        }

        /// <summary>
        /// Initialises the game.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Unloads content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload default content manager.
            ContentManager.Unload();
        }

        public void RegisterSystem(ISystem system)
        {
            // Check system type, add to list and initialise.
            if (system is IGraphicsUpdateSystem)
            {
                graphicsUpdateSystems.Add(system);
                ((IGraphicsUpdateSystem)system).Initialise(this, eventManager, worldManager, graphicsDeviceManager);
            }
            else if (system is IRenderSystem)
            {
                renderSystems.Add(system);
                ((IRenderSystem)system).Initialise(this, eventManager, worldManager, graphicsDeviceManager);
            }
            else if (system is IUpdateSystem)
            {
                updateSystems.Add(system);
                ((IUpdateSystem)system).Initialise(this, eventManager, worldManager);
            }
        }

        public void UnregisterSystem(ISystem system)
        {
            // Check system type and remove from list.
            if (system is IGraphicsUpdateSystem)
            {
                graphicsUpdateSystems.Remove(system);
            }
            else if (system is IRenderSystem)
            {
                renderSystems.Remove(system);
            }
            else if (system is IUpdateSystem)
            {
                updateSystems.Remove(system);
            }

            // Destroy system.
            if (system is IDestroyable)
            {
                ((IDestroyable)system).Destroy();
            }
        }

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update graphics update systems.
            foreach (ISystem system in graphicsUpdateSystems)
            {
                system.Update(gameTime);
            }

            // Update update systems.
            foreach (ISystem system in updateSystems)
            {
                system.Update(gameTime);
            }
        }
    }
}
