using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Entity
{
    /// <summary>
    /// An entity manager handles the creation and termination of entities.
    /// </summary>
    public interface IEntityManager
    {
        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <returns>The entity ID.</returns>
        int CreateEntity();

        /// <summary>
        /// Destroys an entity.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        void DestroyEntity(int entityID);

        /// <summary>
        /// Checks whether an entity is alive.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>True if the entity is alive, false otherwise.</returns>
        bool IsAlive(int entityID);
    }
}
