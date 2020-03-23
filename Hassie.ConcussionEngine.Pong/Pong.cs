using Hassie.ConcussionEngine.Engine.Core;
using Hassie.ConcussionEngine.Engine.Render;
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
            // Register texture 2D render system.
            RegisterSystem(new Texture2DRenderSystem());

            // Create main game world.
            PongWorld mainWorld = new PongWorld(this, 1, new ContentManager(ServiceProvider, "Content"), eventManager);
            worldManager.AddWorld(mainWorld);
            worldManager.RunWorld(1);

            base.Initialize();
        }
    }
}
