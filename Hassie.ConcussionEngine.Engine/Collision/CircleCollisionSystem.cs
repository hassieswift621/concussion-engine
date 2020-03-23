using Hassie.ConcussionEngine.Engine.Component.Data;
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
    /// The hitbox collision system calculates collisions using the bounding circle collision method
    /// and emits events for collision events.
    /// </summary>
    public class CircleCollisionSystem : AbstractUpdateSystem
    {
        public override void Destroy()
        {
            // Do nothing.
        }

        public override void Update(GameTime gameTime)
        {
            // Var to store collision event data.
            IList<CollisionEvent> collisionEvents = new List<CollisionEvent>();

            // Get running worlds.
            IReadOnlyList<IWorld> worlds = worldManager.GetWorldsInState(WorldState.Running);

            // Run through running worlds and check for collisions.
            foreach (IWorld world in worlds)
            {
                // Get required component registries.
                IComponentRegistry<CircleCollisionComponent> circleCollisionComponents =
                    (IComponentRegistry<CircleCollisionComponent>)world.ComponentManager.GetRegistry<CircleCollisionComponent>();
                IComponentRegistry<CollidableComponent> collidableComponents =
                    (IComponentRegistry<CollidableComponent>)world.ComponentManager.GetRegistry<CollidableComponent>();
                IComponentRegistry<PositionComponent> positionComponents =
                    (IComponentRegistry<PositionComponent>)world.ComponentManager.GetRegistry<PositionComponent>();
                IComponentRegistry<TransformComponent> transformComponents =
                    (IComponentRegistry<TransformComponent>)world.ComponentManager.GetRegistry<TransformComponent>();

                // Iterate circle collision components.
                for (int i = 0; i < circleCollisionComponents.Count; i++)
                {
                    // Get components.
                    CircleCollisionComponent circle = circleCollisionComponents[i];
                    PositionComponent position = positionComponents.Get(circle.EntityID);
                    TransformComponent transform = transformComponents.Get(circle.EntityID);

                    // Iterate collidable components and calculate collision.
                    for (int j = 0; j < collidableComponents.Count; j++)
                    {
                        // Get components for collidable entity.
                        CollidableComponent collidable = collidableComponents[j];
                        PositionComponent collidablePosition = positionComponents.Get(collidable.EntityID);
                        TransformComponent collidableTransform = transformComponents.Get(collidable.EntityID);

                        // Calculate the radius of the entities.
                        float rA = (transform.Scale * transform.Width) / 2;
                        float rB = (collidableTransform.Scale * collidableTransform.Width) / 2;

                        // Check if the distance between the two entities is less than the radii.
                        if (Vector2.Distance(new Vector2(position.X, position.Y), 
                            new Vector2(collidablePosition.X, collidablePosition.Y)) < (rA + rB))
                        {
                            // Entities collided.
                            collisionEvents.Add(new CollisionEvent(circle.EntityID, collidable.EntityID, world.ID));
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
