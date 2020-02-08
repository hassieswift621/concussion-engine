using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to store a 2D position of an entity.
    /// </summary>
    public struct PositionComponent : IComponent, IEquatable<PositionComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// The x coordinate of the entity.
        /// </summary>
        public float X { get; set; }

        // The y coordinate of the entity.
        public float Y { get; set; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="x">The x coordinate of the entity.</param>
        /// <param name="y">The y coordinate of the entity.</param>
        public PositionComponent(int entityID, float x, float y)
        {
            EntityID = entityID;
            X = x;
            Y = y;
        }

        public bool Equals(PositionComponent other) => (EntityID, X, Y) == (other.EntityID, other.X, other.Y);

        public override bool Equals(object obj) => obj is PositionComponent component ? Equals(component) : false;

        public override int GetHashCode() => (EntityID, X, Y).GetHashCode();

        public static bool operator ==(PositionComponent left, PositionComponent right) => left.Equals(right);

        public static bool operator !=(PositionComponent left, PositionComponent right) => !(left == right);
    }
}
