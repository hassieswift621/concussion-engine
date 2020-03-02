using Hassie.ConcussionEngine.Engine.Component.Manager;
using System.Collections.Generic;

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

        // Alive entities.
        private readonly ISet<int> entities;

        /// <summary>
        /// Constructor for the entity manager.
        /// </summary>
        /// <param name="terminator">A component terminator.</param>
        public EntityManager(IComponentTerminator terminator)
        {
            // Store component terminator.
            componentTerminator = terminator;

            // Initialise entities set.
            entities = new HashSet<int>();
        }

        public int CreateEntity()
        {
            // Generate entity ID.
            int id = EntityIDGenerator.New();

            // Add to hash set.
            entities.Add(id);

            // Return ID.
            return id;
        }

        public void DestroyEntity(int entityID)
        {
            // Check if entity is alive.
            if (!entities.Contains(entityID))
            {
                return;
            }

            // Terminate entity via component terminator.
            componentTerminator.TerminateEntity(entityID);

            // Remove entity from hash set.
            entities.Remove(entityID);
        }

        public bool IsAlive(int entityID)
        {
            return entities.Contains(entityID);
        }
    }
}
