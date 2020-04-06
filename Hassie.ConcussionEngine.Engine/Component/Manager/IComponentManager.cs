using Hassie.ConcussionEngine.Engine.Component.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Manager
{
    /// <summary>
    /// A component manager manages the component registries.
    /// </summary>
    public interface IComponentManager
    {
        /// <summary>
        /// Checks whether a component exists.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        bool ContainsComponent<C>(int entityID) where C : struct, IComponent;

        /// <summary>
        /// Checks whether a registry exists for a component type.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <returns>True if the registry exists, false otherwise.</returns>
        bool ContainsRegistry<C>() where C : struct, IComponent;

        /// <summary>
        /// Gets a component.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>The component.</returns>
        C GetComponent<C>(int entityID) where C : struct, IComponent;

        /// <summary>
        /// Gets a component registry.
        /// </summary>
        /// <typeparam name="C">The component type the registry handles.</typeparam>
        /// <returns>The component registry.</returns>
        IComponentRegistry GetRegistry<C>() where C : struct, IComponent;

        /// <summary>
        /// Registers a component registry for a component type.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <typeparam name="R">The registry type.</typeparam>
        /// <returns>The component manager instance.</returns>
        IComponentManager RegisterType<C, R>() where C : struct, IComponent where R : IComponentRegistry<C>, new();

        /// <summary>
        /// Removes a component.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <param name="entityID">The ID of the entity.</param>
        /// <returns>The component manager instance.</returns>
        IComponentManager RemoveComponent<C>(int entityID) where C : struct, IComponent;

        /// <summary>
        /// Sets a component.
        /// </summary>
        /// <typeparam name="C">The component type.</typeparam>
        /// <param name="component">The component.</param>
        /// <returns>The component manager instance.</returns>
        IComponentManager SetComponent<C>(C component) where C : struct, IComponent;
    }
}
