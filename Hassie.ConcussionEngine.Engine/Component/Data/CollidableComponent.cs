using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to tag an entity as collidable.
    /// </summary>
    public struct CollidableComponent : IComponent, IEquatable<CollidableComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        public CollidableComponent(int entityID) => EntityID = entityID;

        public bool Equals(CollidableComponent other) => EntityID == other.EntityID;

        public override bool Equals(object obj) => obj is CollidableComponent component ? Equals(component) : false;

        public override int GetHashCode() => EntityID.GetHashCode();

        public static bool operator ==(CollidableComponent left, CollidableComponent right) => left.Equals(right);

        public static bool operator !=(CollidableComponent left, CollidableComponent right) => !(left == right);
    }
}
