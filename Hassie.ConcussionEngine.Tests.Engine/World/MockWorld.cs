using Hassie.ConcussionEngine.Engine.Event;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework.Content;

namespace Hassie.ConcussionEngine.Tests.Engine.World
{
    /// <summary>
    /// Mockup world for tests.
    /// </summary>
    public class MockWorld : AbstractWorld
    {
        public MockWorld(int id, ContentManager contentManager, IEventManager eventManager) : base(id, contentManager, eventManager)
        {
        }
    }
}
