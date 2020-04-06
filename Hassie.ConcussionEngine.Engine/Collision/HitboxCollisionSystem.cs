using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Manager;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Update;
using Hassie.ConcussionEngine.Engine.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Collision
{
    /// <summary>
    /// The hitbox collision system calculates collisions using the hitbox collision method
    /// and emits events for collision events.
    /// </summary>
    public class HitboxCollisionSystem : AbstractUpdateSystem
    {
        public override void Update(GameTime gameTime)
        {
            // Var to store collision event data.
            IList<CollisionEvent> collisionEvents = new List<CollisionEvent>();

            // Get running worlds.
            IReadOnlyList<IWorld> worlds = worldManager.GetWorldsInState(WorldState.Running);

            // Run through running worlds and check for collisions.
            foreach (IWorld world in worlds)
            {
                // Store component manager.
                IComponentManager componentManager = world.ComponentManager;

                // Check if the world has the required component registries.
                if (!componentManager.ContainsRegistry<CollidableComponent>() ||
                    !componentManager.ContainsRegistry<HitboxCollisionComponent>() ||
                    !componentManager.ContainsRegistry<PositionComponent>() ||
                    !componentManager.ContainsRegistry<TransformComponent>())
                {
                    continue;
                }

                // Get component registries.
                IComponentRegistry<CollidableComponent> collidableComponents =
                    (IComponentRegistry<CollidableComponent>)componentManager.GetRegistry<CollidableComponent>();
                IComponentRegistry<HitboxCollisionComponent> hitboxCollisionComponents =
                    (IComponentRegistry<HitboxCollisionComponent>)componentManager.GetRegistry<HitboxCollisionComponent>();
                IComponentRegistry<PositionComponent> positionComponents =
                    (IComponentRegistry<PositionComponent>)componentManager.GetRegistry<PositionComponent>();
                IComponentRegistry<TransformComponent> transformComponents =
                    (IComponentRegistry<TransformComponent>)componentManager.GetRegistry<TransformComponent>();

                // Iterate hitbox collision components.
                for (int i = 0; i < hitboxCollisionComponents.Count; i++)
                {
                    // Get components.
                    HitboxCollisionComponent hitbox = hitboxCollisionComponents[i];
                    PositionComponent position = positionComponents.Get(hitbox.EntityID);
                    TransformComponent transform = transformComponents.Get(hitbox.EntityID);

                    // Iterate collidable components and calculate collision.
                    for (int j = 0; j < collidableComponents.Count; j++)
                    {
                        // Get components for collidable entity.
                        CollidableComponent collidable = collidableComponents[j];
                        PositionComponent collidablePosition = positionComponents.Get(collidable.EntityID);
                        TransformComponent collidableTransform = transformComponents.Get(collidable.EntityID);

                        // Create hitboxes.
                        Rectangle entityA = new Rectangle((int)position.X, (int)position.Y, transform.Width, transform.Height);
                        Rectangle entityB = new Rectangle((int)collidablePosition.X, (int)collidablePosition.Y,
                            collidableTransform.Width, collidableTransform.Height);

                        // Perform collision detection.
                        if (entityA.Intersects(entityB))
                        {
                            // Entities collided.
                            collisionEvents.Add(new CollisionEvent(hitbox.EntityID, collidable.EntityID, world.ID));
                        }
                    }
                }
            }

            // An entity can be both a collider and a collidable, so filter out any events where this is true.
            // We could check this before performing the collision detection but we want to avoid
            // branch predictions in the hot path as much as possible.
            collisionEvents = collisionEvents.Where(x => x.Collidable != x.Collider).ToList();

            // Emit events.
            foreach (CollisionEvent collisionEvent in collisionEvents)
            {
                eventManager.Emit(collisionEvent);
            }
        }
    }
}
