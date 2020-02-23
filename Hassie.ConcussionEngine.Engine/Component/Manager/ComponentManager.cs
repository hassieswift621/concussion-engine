using Hassie.ConcussionEngine.Engine.Component.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Manager
{
    /// <summary>
    /// The component manager manages the component registries.
    /// </summary>
    public class ComponentManager : IComponentManager
    {
        // Component registries.
        // The key is the component type the registry handles.
        private readonly IDictionary<Type, IComponentRegistry> registries;

        /// <summary>
        /// Constructor for the component manager.
        /// </summary>
        public ComponentManager()
        {
            // Initialise registry map.
            registries = new Dictionary<Type, IComponentRegistry>();
        }

        public bool ContainsComponent<C>(int entityID) where C : struct, IComponent
        {
            return registries[typeof(C)].Contains(entityID);
        }

        public C GetComponent<C>(int entityID) where C : struct, IComponent
        {
            return ((IComponentRegistry<C>)registries[typeof(C)]).Get(entityID);
        }

        public IComponentRegistry GetRegistry<C>() where C : struct, IComponent
        {
            return registries[typeof(C)];
        }

        public IComponentManager RegisterType<C, R>() where C : struct, IComponent
            where R : IComponentRegistry<C>, new()
        {
            // Initialise registry.
            R registry = new R();

            // Add registry.
            registries.Add(typeof(C), registry);

            // Return instance.
            return this;
        }

        public IComponentManager RemoveComponent<C>(int entityID) where C : struct, IComponent
        {
            // Remove component.
            registries[typeof(C)].Remove(entityID);

            // Return instance.
            return this;
        }

        public IComponentManager SetComponent<C>(C component) where C : struct, IComponent
        {
            // Set component.
            ((IComponentRegistry<C>)registries[typeof(C)]).Set(component);

            // Return instance.
            return this;
        }
    }
}
