using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Registry
{
    /// <summary>
    /// A component registry stores a set of components for a component type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <remarks>
    /// A component registry implements <see cref="IEnumerable{T}"/> so that the components
    /// can be iterated directly through the interface.
    /// </remarks>
    public interface IComponentRegistry<T> : IRegistry, IEnumerable<T> where T : struct, IComponent
    {
        /// <summary>
        /// Gets a component for an entity.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>The component.</returns>
        T this[int entityID] { get; }

        /// <summary>
        /// Checks whether a component for an entity exists.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        bool Contains(int entityID);

        /// <summary>
        /// Removes a component from the registry.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        void Remove(int entityID);

        /// <summary>
        /// Sets the component for an entity.
        /// </summary>
        /// <param name="component">The component.</param>
        void Set(T component);
    }
}
