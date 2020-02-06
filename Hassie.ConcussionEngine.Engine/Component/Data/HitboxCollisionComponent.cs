using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to tag an entity to be checked against collidable entities
    /// using the hitbox collision method.
    /// </summary>
    public struct HitboxCollisionComponent : IComponent, IEquatable<HitboxCollisionComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        public HitboxCollisionComponent(int entityID)
        {
            EntityID = entityID;
        }

        public bool Equals(HitboxCollisionComponent other)
        {
            if (EntityID == other.EntityID)
            {
                return true;
            }

            return false;
        }
    }
}
