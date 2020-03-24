using Hassie.ConcussionEngine.Engine.Collision;
using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Input;
using Hassie.ConcussionEngine.Engine.Physics;
using Hassie.ConcussionEngine.Engine.Render;
using Hassie.ConcussionEngine.Pong.Collision;
using Hassie.ConcussionEngine.Pong.Input;
using Hassie.ConcussionEngine.Pong.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong
{
    public class Pong : EngineCore
    {
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
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
            RegisterSystem(new BallCollisionResponder());
            RegisterSystem(new PlayerInputSystem());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create main game world.
            PongWorld mainWorld = new PongWorld(this, (int)WorldID.PongWorld, new ContentManager(ServiceProvider, "Content"), eventManager);
            worldManager.AddWorld(mainWorld);
            worldManager.RunWorld((int)WorldID.PongWorld);

            base.LoadContent();
        }
    }
}
