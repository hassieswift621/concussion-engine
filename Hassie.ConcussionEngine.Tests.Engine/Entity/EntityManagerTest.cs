using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Manager;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using Hassie.ConcussionEngine.Engine.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Entity
{
    /// <summary>
    /// Entity manager tests.
    /// </summary>
    [TestFixture]
    public class EntityManagerTest
    {
        /// <summary>
        /// Tests the creation of entities.
        /// </summary>
        [Test]
        public void CreateEntity()
        {
            // Arrange.
            IComponentManager componentManager = new ComponentManager();
            IEntityManager entityManager = new EntityManager((IComponentTerminator)componentManager);

            // Act.
            int id1 = entityManager.CreateEntity();
            int id2 = entityManager.CreateEntity();
            int id3 = entityManager.CreateEntity();

            // Assert.
            Assert.IsTrue(id1 == 1 && id2 == 2 && id3 == 3);
        }

        /// <summary>
        /// Tests the creation of entities across multiple entity managers.
        /// </summary>
        [Test]
        public void CreateEntity_MultipleManagers()
        {
            // Arrange.
            IComponentManager componentManager1 = new ComponentManager();
            IEntityManager entityManager1 = new EntityManager((IComponentTerminator)componentManager1);
            IComponentManager componentManager2 = new ComponentManager();
            IEntityManager entityManager2 = new EntityManager((IComponentTerminator)componentManager2);
            IComponentManager componentManager3 = new ComponentManager();
            IEntityManager entityManager3 = new EntityManager((IComponentTerminator)componentManager3);

            // Act.
            int id1 = entityManager1.CreateEntity();
            int id2 = entityManager2.CreateEntity();
            int id3 = entityManager3.CreateEntity();

            // Assert.
            Assert.IsTrue(id1 == 1 && id2 == 2 && id3 == 3);
        }

        /// <summary>
        /// Tests whether an entity is considered alive whilst not destroyed.
        /// </summary>
        [Test]
        public void IsAlive()
        {
            // Arrange.
            IComponentManager componentManager = new ComponentManager();
            IEntityManager entityManager = new EntityManager((IComponentTerminator)componentManager);

            // Act.
            int entity = entityManager.CreateEntity();

            // Assert.
            Assert.IsTrue(entityManager.IsAlive(entity));
        }

        /// <summary>
        /// Tests the termination of an entity.
        /// </summary>
        [Test]
        public void DestroyEntity()
        {
            // Arrange.
            IComponentManager componentManager = new ComponentManager();
            IEntityManager entityManager = new EntityManager((IComponentTerminator)componentManager);

            componentManager
                .RegisterType<CircleCollisionComponent, CircleCollisionCR>()
                .RegisterType<PositionComponent, PositionCR>();

            int entity = entityManager.CreateEntity();
            componentManager.SetComponent(new CircleCollisionComponent(entity));
            componentManager.SetComponent(new PositionComponent(entity, 1, 1));

            // Act.
            entityManager.DestroyEntity(entity);

            // Assert.
            Assert.IsTrue(!entityManager.IsAlive(entity) &&
                !componentManager.ContainsComponent<CircleCollisionComponent>(entity) &&
                !componentManager.ContainsComponent<PositionComponent>(entity));
        }

        /// <summary>
        /// Tests the termination of all entities created by an entity manager.
        /// </summary>
        [Test]
        public void DestroyEntities()
        {
            // Arrange.
            IComponentManager componentManager = new ComponentManager();
            IEntityManager entityManager = new EntityManager((IComponentTerminator)componentManager);

            componentManager
                .RegisterType<PositionComponent, PositionCR>();

            int entity1 = entityManager.CreateEntity();
            componentManager.SetComponent(new PositionComponent(entity1, 1, 1));

            int entity2 = entityManager.CreateEntity();
            componentManager.SetComponent(new PositionComponent(entity2, 1, 1));

            // Act.
            entityManager.DestroyEntities();

            // Assert.
            Assert.IsTrue(!entityManager.IsAlive(entity1) &&
                !componentManager.ContainsComponent<PositionComponent>(entity1) &&
                !entityManager.IsAlive(entity2) &&
                !componentManager.ContainsComponent<PositionComponent>(entity2));
        }
    }
}
