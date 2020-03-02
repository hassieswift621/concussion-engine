using Hassie.ConcussionEngine.Engine.Component.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Entity
{
    /// <summary>
    /// The entity manager handles the creation of entities and
    /// termination via a <see cref="IComponentTerminator"/>.
    /// </summary>
    public class EntityManager : IEntityManager
    {
        // Component terminator.
        private readonly IComponentTerminator componentTerminator;

        /// <summary>
        /// Constructor for the entity manager.
        /// </summary>
        /// <param name="terminator">A component terminator.</param>
        public EntityManager(IComponentTerminator terminator)
        {
            // Store component terminator.
            componentTerminator = terminator;
        }

        public int CreateEntity()
        {
            return EntityIDGenerator.New();
        }

        public void DestroyEntity(int entityID)
        {
            // Terminate entity via component terminator.
            componentTerminator.TerminateEntity(entityID);
        }
    }
}
