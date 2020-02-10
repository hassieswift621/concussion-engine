using System;
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
    public class AbstractComponentRegistry<T> : IComponentRegistry<T> where T : struct, IComponent
    {
        protected readonly IDictionary<int, int> entities; // Map of entities and their component indexes in the list.
        protected readonly IList<T> components; // List of components.

        /// <summary>
        /// Constructor for the component registry.
        /// </summary>
        public AbstractComponentRegistry()
        {
            // Initialise map and list.
            entities = new Dictionary<int, int>();
            components = new List<T>();
        }

        public virtual T this[int entityID]
        {
            get => components[entities[entityID]];
            set
            {
                // Check if the entity exists.
                if (entities.ContainsKey(entityID))
                {
                    // Overwrite.
                    components[entities[entityID]] = value;
                }
                else
                {
                    // Add.
                    entities[entityID] = components.Count;
                    components.Add(value);
                }
            }
        }

        public int Count => components.Count;

        public bool Contains(int entityID)
        {
            return entities.ContainsKey(entityID);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return components.GetEnumerator();
        }

        public virtual void Remove(int entityID)
        {
            // Check if entity exists.
            if (!entities.ContainsKey(entityID))
            {
                return;
            }

            // If size of list is 1, simply remove entity.
            if (components.Count == 1)
            {
                components.RemoveAt(0);
                entities.Remove(entityID);
                return;
            }

            // Otherwise, move last element of components list into the component index of the entity that is about to be removed.
            // Otherwise, we'll have to update every index in the map from the point of removal.
            T component = components.Last();
            components[entities[entityID]] = component;
            components.RemoveAt(components.Count - 1);
            entities.Remove(entityID);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return components.GetEnumerator();
        }
    }
}
