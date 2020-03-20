using Hassie.ConcussionEngine.Engine.Component.Manager;
using Hassie.ConcussionEngine.Engine.Entity;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.World
{
    public interface IWorld
    {
        IComponentManager ComponentManager { get; }

        ContentManager ContentManager { get; }

        IEntityManager EntityManager { get; }

        int ID { get; }
    }
}
