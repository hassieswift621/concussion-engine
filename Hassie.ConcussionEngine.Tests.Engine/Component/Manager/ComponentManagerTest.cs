using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Manager;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Component.Manager
{
    [TestFixture]
    public class ComponentManagerTest
    {
        private IComponentManager componentManager;

        /// <summary>
        /// Sets up the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialise component manager.
            componentManager = new ComponentManager();
        }

        /// <summary>
        /// Tests the registering of component types.
        /// </summary>
        [Test]
        public void RegisterType()
        {
            // Act.
            componentManager
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>();

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Tests the retrieval of component registries.
        /// </summary>
        [Test]
        public void GetRegistry_ShouldBeCorrectType()
        {
            // Arrange.
            componentManager
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>();

            // Act.
            IComponentRegistry<PositionComponent> positionCR =
                (IComponentRegistry<PositionComponent>)componentManager.GetRegistry<PositionComponent>();
            IComponentRegistry<Texture2DRenderComponent> texture2DRenderCR =
               (IComponentRegistry<Texture2DRenderComponent>)componentManager.GetRegistry<Texture2DRenderComponent>();

            // Assert.
            Assert.IsTrue(positionCR != null && texture2DRenderCR != null);
        }

        /// <summary>
        /// Tests the setting of a component.
        /// </summary>
        [Test]
        public void Set()
        {
            // Arrange.
            componentManager.RegisterType<PositionComponent, PositionCR>();
            PositionComponent component = new PositionComponent(87, 65.8f, 90.8f);

            // Act.
            componentManager.SetComponent(component);

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Tests the retrieval of components.
        /// </summary>
        [Test]
        public void GetComponent_ShouldBeEqual()
        {
            // Arrange.
            componentManager.RegisterType<PositionComponent, PositionCR>();
            PositionComponent component = new PositionComponent(87, 65.8f, 90.8f);

            // Act.
            componentManager.SetComponent(component);

            // Assert.
            Assert.IsTrue(componentManager.GetComponent<PositionComponent>(component.EntityID) == component);
        }

        /// <summary>
        /// Tests whether a component exists.
        /// </summary>
        [Test]
        public void ContainsComponent_ShouldBeTrue()
        {
            // Arrange.
            CircleCollisionComponent component = new CircleCollisionComponent(56);
            componentManager
                .RegisterType<CircleCollisionComponent, CircleCollisionCR>()
                .SetComponent(component);

            // Act.
            bool contains = componentManager.ContainsComponent<CircleCollisionComponent>(component.EntityID);

            // Assert.
            Assert.IsTrue(contains);
        }

        /// <summary>
        /// Tests the removal of a component.
        /// </summary>
        [Test]
        public void RemoveComponent()
        {
            // Arrange.
            Texture2DRenderComponent component = new Texture2DRenderComponent(55, 4, null);
            componentManager
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>()
                .SetComponent(component);

            // Act.
            componentManager.RemoveComponent<Texture2DRenderComponent>(component.EntityID);

            // Assert.
            Assert.IsFalse(componentManager.ContainsComponent<Texture2DRenderComponent>(component.EntityID));
        }

        /// <summary>
        /// Tests the termination of an entity.
        /// </summary>
        [Test]
        public void TerminateEntity()
        {
            // Arrange.
            int entityID = 76;

            CollidableComponent collidable = new CollidableComponent(entityID);
            PositionComponent position = new PositionComponent(entityID, 43f, 0f);
            Texture2DRenderComponent texture = new Texture2DRenderComponent(entityID, 7, null);

            componentManager
                .RegisterType<CollidableComponent, CollidableComponentCR>()
                .RegisterType<PositionComponent, PositionCR>()
                .RegisterType<Texture2DRenderComponent, Texture2DRenderCR>()
                .SetComponent(collidable)
                .SetComponent(position)
                .SetComponent(texture);

            // Act.
            ((IComponentTerminator)componentManager).TerminateEntity(entityID);

            // Assert.
            Assert.IsTrue(!componentManager.ContainsComponent<CollidableComponent>(entityID) &&
                !componentManager.ContainsComponent<PositionComponent>(entityID) &&
                !componentManager.ContainsComponent<Texture2DRenderComponent>(entityID));
        }
    }
}
