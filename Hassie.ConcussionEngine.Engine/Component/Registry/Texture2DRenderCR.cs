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
        public override void Remove(int entityID)
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

            // Otherwise, update the indexes of components from the index of removal + 1.
            for (int i = entities[entityID] + 1; i < Count; i++)
            {
                entities[components[i].EntityID] -= 1;
            }

            // Remove entity.
            components.RemoveAt(entities[entityID]);
            entities.Remove(entityID);
        }

        public override void Set(Texture2DRenderComponent component)
        {
            int entityID = component.EntityID;
            int renderOrder = component.RenderOrder;

            // Check if entity exists.
            if (entities.ContainsKey(entityID))
            {
                // Get index.
                int index = entities[entityID];

                // If the render order has not changed, overwrite and return.
                if (components[index].RenderOrder == renderOrder)
                {
                    components[index] = component;
                    return;
                }
            }

            // Search list and insert in order.

            // If list count is 0, simply insert.
            if (Count == 0)
            {
                entities[entityID] = 0;
                components.Add(component);
                return;
            }

            // If render order is >= the last component, append.
            if (renderOrder >= components.Last().RenderOrder)
            {
                entities[entityID] = Count;
                components.Add(component);
                return;
            }

            bool found = false;
            int insertIndex = -1;

            // If render order is 0, insert after last component with render order 0.
            if (renderOrder == 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (components[i].RenderOrder > 0)
                    {
                        found = true;
                        insertIndex = i;
                        break;
                    }
                }
            }

            if (!found)
            {
                // Use binary search to find index to insert component at.
                int left = 0;
                int right = Count - 1;
                int mid = -1;
                while (left <= right)
                {
                    mid = (left + right) / 2;

                    // If component with the same render order is found,
                    // iterate array and insert after last component with the same render order.
                    if (components[mid].RenderOrder == renderOrder)
                    {
                        for (int i = mid + 1; i < Count; i++)
                        {
                            if (components[i].RenderOrder > renderOrder)
                            {
                                found = true;
                                insertIndex = i;
                            }
                        }
                    }
                    else if (components[mid].RenderOrder < renderOrder)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                if (!found)
                {
                    // If we reach here, it means a component with the same render order was not found.
                    // In this case, check the last mid item and insert before or after the set of components
                    // with the same render order of mid item.
                    int midRenderOrder = components[mid].RenderOrder;
                    if (midRenderOrder < renderOrder)
                    {
                        for (int i = mid + 1; i < Count; i++)
                        {
                            if (components[i].RenderOrder > midRenderOrder)
                            {
                                insertIndex = i;
                                break;
                            }
                        }
                    }
                    else if (midRenderOrder > renderOrder)
                    {
                        for (int i = mid - 1; i >= 0; i--)
                        {
                            if (components[i].RenderOrder < midRenderOrder)
                            {
                                insertIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

            // Insert component and update indexes of entities.
            entities[entityID] = insertIndex;
            components.Insert(insertIndex, component);
            for (int i = insertIndex + 1; i < Count; i++)
            {
                entities[components[i].EntityID] += 1;
            }
        }  
    }
}
