using Hassie.ConcussionEngine.Engine.Collision;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Input;
using Hassie.ConcussionEngine.Engine.Physics;
using Hassie.ConcussionEngine.Engine.Render;
using Hassie.ConcussionEngine.MegaPong.Collision;
using Hassie.ConcussionEngine.MegaPong.Input;
using Hassie.ConcussionEngine.MegaPong.Physics;
using Hassie.ConcussionEngine.MegaPong.Render;
using Hassie.ConcussionEngine.MegaPong.Score;
using Hassie.ConcussionEngine.MegaPong.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.MegaPong
{
    public class Pong : EngineCore
    {
        // Number of pong balls to spawn.
        public static int BallCount = 500;

        public Pong() : base()
        {
            // Set resolution to 1280x720.
            graphicsDeviceManager.PreferredBackBufferWidth = 1280;
            graphicsDeviceManager.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // Register systems.

            // Engine.
            RegisterSystem(new HitboxCollisionSystem());
            RegisterSystem(new KeyboardInputSystem());
            RegisterSystem(new PhysicsSystem());
            RegisterSystem(new Texture2DRenderSystem());

            // Game.
            RegisterSystem(new BallBoundarySystem());
            RegisterSystem(new BallCollisionResponderSystem());
            RegisterSystem(new PlayerInputSystem());
            RegisterSystem(new TextRenderSystem());
            RegisterSystem(new ScoreSystem());

            
            // Create worlds.

            // Create main game world.
            PongWorld mainWorld = new PongWorld(this, (int)WorldID.PongWorld, ContentManager, eventManager);
            worldManager.AddWorld(mainWorld);
            worldManager.RunWorld((int)WorldID.PongWorld);

            // Create HUD world.
            HudWorld hudWorld = new HudWorld(this, (int)WorldID.HudWorld, ContentManager, eventManager);
            worldManager.AddWorld(hudWorld);
            worldManager.RunWorld((int)WorldID.HudWorld);

            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOrange);

            base.Draw(gameTime);
        }
    }
}
