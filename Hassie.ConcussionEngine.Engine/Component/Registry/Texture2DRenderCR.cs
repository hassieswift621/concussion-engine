using Hassie.ConcussionEngine.Engine.Component.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Registry
{
    /// <summary>
    /// Component registry for <see cref="Texture2DRenderCR"/>.
    /// </summary>
    /// <remarks>
    /// The components are stored in order based on the render order.
    /// </remarks>
    public class Texture2DRenderCR : AbstractComponentRegistry<Texture2DRenderComponent>
    {
        public override Texture2DRenderComponent this[int entityID]
        {
            get => base[entityID];
            set
            {
                // Check if entity exists.
                if (entities.ContainsKey(entityID))
                {
                    // Get index.
                    int index = entities[entityID];

                    // If the render order has not changed, overwrite and return.
                    if (components[index].RenderOrder == value.RenderOrder)
                    {
                        components[index] = value;
                        return;
                    }
                }

                // Search list and insert in order.

                // If list count is 0, simply insert.
                if (components.Count == 0)
                {
                    entities[entityID] = 0;
                    components.Add(value);
                    return;
                }

                // If render order is >= the last component, append.
                if (value.RenderOrder >= components.Last().RenderOrder)
                {
                    entities[entityID] = components.Count;
                    components.Add(value);
                    return;
                }

                // If render order is 0, insert after last component with render order 0 and update indexes.
                if (value.RenderOrder == 0)
                {
                    for (int i = 0; i < components.Count; i++)
                    {
                        if (components[i].RenderOrder > 0)
                        {
                            entities[entityID] = i;
                            components.Insert(i, value);
                            for (int j = i + 1; j < components.Count; j++)
                            {
                                entities[components[j].EntityID] = j - 1;
                            }
                            break;
                        }
                    }
                }

                // TODO: Binary search.
            }
        }

        public override void Remove(int entityID)
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

            // Otherwise, update the indexes of components from the index of removal + 1.
            for (int i = entities[entityID] + 1; i < components.Count; i++)
            {
                entities[components[i].EntityID] = i - 1;
            }

            // Remove entity.
            components.RemoveAt(entities[entityID]);
            entities.Remove(entityID);
        }
    }
}
