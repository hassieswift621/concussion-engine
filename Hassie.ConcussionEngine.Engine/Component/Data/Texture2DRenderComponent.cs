using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component for storing a Texture2D and the render order
    /// for an entity.
    /// </summary>
    public struct Texture2DRenderComponent : IComponent
    {
        /// <summary>
        /// The ID of the entity.
        /// </summary>
        public int EntityID { get; }

        /// <summary>
        /// The render order of the texture.
        /// </summary>
        public int RenderOrder { get; set; }

        /// <summary>
        /// The 2D texture.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="renderOrder">The render order of the texture.</param>
        /// <param name="texture">The 2D texture.</param>
        public Texture2DRenderComponent(int entityID, int renderOrder = 0, Texture2D texture = null)
        {
            EntityID = entityID;
            RenderOrder = renderOrder;
            Texture = texture;
        }
    }
}
