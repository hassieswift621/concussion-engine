﻿using Hassie.ConcussionEngine.Engine.Component.Data;
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
                // Store component manager.
                IComponentManager componentManager = world.ComponentManager;

                // Check if the world has the required component registries.
                if (!componentManager.ContainsRegistry<PhysicsComponent>() ||
                    !componentManager.ContainsRegistry<PositionComponent>())
                {
                    continue;
                }

                // Get component registries.
                IComponentRegistry<PhysicsComponent> physicsComponents =
                    (IComponentRegistry<PhysicsComponent>)componentManager.GetRegistry<PhysicsComponent>();
                IComponentRegistry<PositionComponent> positionComponents =
                    (IComponentRegistry<PositionComponent>)componentManager.GetRegistry<PositionComponent>();

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
                    physics.VelocityX += (physics.AccelerationX * dt) + physics.GravityX;
                    physics.VelocityY += (physics.AccelerationY * dt) + physics.GravityY;

                    // Update position.
                    position.X += physics.VelocityX * dt;
                    position.Y += physics.VelocityY * dt;

                    // Store.
                    physicsComponents[i] = physics;
                    positionComponents.Set(position);
                }
            }
        }
    }
}
