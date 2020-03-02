using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Entity
{
    /// <summary>
    /// Entity ID generator.
    /// </summary>
    /// <remarks>
    /// The generator is static so that it is shared across all instances
    /// of the entity manager. This ensures all entity IDs will be unique.
    /// </remarks>
    static class EntityIDGenerator
    {
        private static int entitiesCreated;

        /// <summary>
        /// Generates a new ID.
        /// </summary>
        /// <returns>The ID.</returns>
        public static int New()
        {
            return ++entitiesCreated;
        }
    }
}
