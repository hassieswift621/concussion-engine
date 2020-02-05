﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to tag an entity to be checked against collidable entities
    /// using the bounding circle collision method.
    /// </summary>
    public struct CircleCollisionComponent : IComponent
    {
        /// <summary>
        /// The ID of the entity.
        /// </summary>
        public int EntityID { get; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        public CircleCollisionComponent(int entityID)
        {
            EntityID = entityID;
        }
    }
}
