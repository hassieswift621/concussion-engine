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

namespace Hassie.ConcussionEngine.Engine.Physics
{
    /// <summary>
    /// The physics system handles simple 2D physics in the game.
    /// </summary>
    public class PhysicsSystem : AbstractUpdateSystem
    {
        public override void Update(GameTime gameTime)
        {
            // Get running worlds.
            IReadOnlyList<IWorld> worlds = worldManager.GetWorldsInState(WorldState.Running);

            // For each running world, update physics.
            foreach (IWorld world in worlds)
            {
                // Get required component registries.
                IComponentRegistry<PhysicsComponent> physicsComponents =
                    (IComponentRegistry<PhysicsComponent>)world.ComponentManager.GetRegistry<PhysicsComponent>();
                IComponentRegistry<PositionComponent> positionComponents =
                    (IComponentRegistry<PositionComponent>)world.ComponentManager.GetRegistry<PositionComponent>();

                // Iterate physics components.
                for (int i = 0; i < physicsComponents.Count; i++)
                {
                    // Get components
                    PhysicsComponent physics = physicsComponents[i];
                    PositionComponent position = positionComponents.Get(physics.EntityID);

                    // Update physics.

                    // Calculate delta time.
                    float dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000;

                    // Calculate velocity.
                    physics.VelocityX += (dt * physics.AccelerationX) + physics.GravityX;
                    physics.VelocityY += (dt * physics.AccelerationY) + physics.GravityY;

                    // Update position.
                    position.X += physics.VelocityX;
                    position.Y += physics.VelocityY;

                    // Store.
                    physicsComponents[i] = physics;
                    positionComponents.Set(position);
                }
            }
        }
    }
}
