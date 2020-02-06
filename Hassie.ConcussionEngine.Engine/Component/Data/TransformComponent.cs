using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to store transform properties of an entity.
    /// </summary>
    public struct TransformComponent : IComponent, IEquatable<TransformComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// The height of the entity.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The rotation of the entity.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// The scale of the entity.
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// The width of the entity.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        /// <param name="rotation">The rotation of the entity.</param>
        /// <param name="scale">The scale of the entity.</param>
        /// <param name="width">The width of the entity.</param>
        public TransformComponent(int entityID, int height, float rotation, float scale, int width)
        {
            EntityID = entityID;
            Height = height;
            Rotation = rotation;
            Scale = scale;
            Width = width;
        }

        public bool Equals(TransformComponent other)
        {
            if (EntityID == other.EntityID &&
                Height == other.Height &&
                Rotation == other.Rotation &&
                Scale == other.Scale &&
                Width == other.Width)
            {
                return true;
            }

            return false;
        }
    }
}
