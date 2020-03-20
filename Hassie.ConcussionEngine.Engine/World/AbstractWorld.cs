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
    public abstract class AbstractWorld : IWorld, IWorldState
    {
        public IComponentManager ComponentManager { get; }

        public ContentManager ContentManager { get; }

        public IEntityManager EntityManager { get; }

        public WorldState State { get; private set; } = WorldState.None;

        public int ID { get; }

        protected AbstractWorld(int id, ContentManager contentManager)
        {
            ID = id;
            ContentManager = contentManager;

            ComponentManager = new ComponentManager();
            EntityManager = new EntityManager((IComponentTerminator)ComponentManager);
        }

        public virtual void Pause()
        {
            State = WorldState.Paused;
        }

        public virtual void Run()
        {
            State = WorldState.Running;
        }

        public virtual void Stop(bool reset)
        {
            State = reset ? WorldState.None : WorldState.Stopped;
        }
    }
}
