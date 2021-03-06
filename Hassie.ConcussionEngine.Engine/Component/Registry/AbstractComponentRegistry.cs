﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Registry
{
    /// <summary>
    /// An abstract class for a component registry.
    /// A component registry stores a set of components for a component type.
    /// This is inherited by all component registries.
    /// </summary>
    /// <typeparam name="T">The type of component that the registry stores.</typeparam>
    public abstract class AbstractComponentRegistry<T> : IComponentRegistry<T> where T : struct, IComponent
    {
        protected readonly IDictionary<int, int> entities; // Map of entities and their component indexes in the list.
        protected readonly IList<T> components; // List of components.

        /// <summary>
        /// Constructor for the component registry.
        /// </summary>
        protected AbstractComponentRegistry()
        {
            // Initialise map and list.
            entities = new Dictionary<int, int>();
            components = new List<T>();
        }

        public T this[int index]
        {
            get => components[index];
            set => components[index] = value;
        }

        public int Count => components.Count;

        public bool Contains(int entityID) => entities.ContainsKey(entityID);

        public T Get(int entityID) => components[entities[entityID]];

        public IEnumerator<T> GetEnumerator() => components.GetEnumerator();

        public virtual void Remove(int entityID)
        {
            // Check if entity exists.
            if (!entities.ContainsKey(entityID))
            {
                return;
            }

            // If size of list is 1, simply remove entity.
            if (Count == 1)
            {
                components.RemoveAt(0);
                entities.Remove(entityID);
                return;
            }

            // Otherwise, move last element of components list into the component index of the entity that is about to be removed.
            // This keeps the components tightly packed in memory.
            T component = components.Last();
            components[entities[entityID]] = component;
            components.RemoveAt(Count - 1);
            entities.Remove(entityID);
        }

        public virtual void Set(T component)
        {
            // Check if the entity exists.
            if (entities.ContainsKey(component.EntityID))
            {
                // Overwrite.
                components[entities[component.EntityID]] = component;
            }
            else
            {
                // Add.
                entities[component.EntityID] = Count;
                components.Add(component);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => components.GetEnumerator();
    }
}
