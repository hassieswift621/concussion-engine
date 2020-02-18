using Hassie.ConcussionEngine.Engine.Component.Data;
using Hassie.ConcussionEngine.Engine.Component.Registry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Component.Registry
{
    /// <summary>
    /// Tests for the abstract component registry.
    [TestFixture]
    public class AbstractComponentRegistryTest
    {
        private class DefaultRegistry : AbstractComponentRegistry<PositionComponent> { }

        private DefaultRegistry registry;
        private PositionComponent component1;
        private PositionComponent component2;
        private PositionComponent component3;
        private PositionComponent component4;

        /// <summary>
        /// Sets up the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Arrange.
            registry = new DefaultRegistry();
            component1 = new PositionComponent(14, 125.36f, 250f);
            component2 = new PositionComponent(76, 340.988f, 4.5f);
            component3 = new PositionComponent(793, 34f, 76.666f);
            component4 = new PositionComponent(9266, 650.09f, 70f);
        }

        /// <summary>
        /// Test for adding components to the registry.
        /// </summary>
        [Test]
        public void Add()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Test for getting components from the registry.
        /// </summary>
        [Test]
        public void Get()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Assert.
            Assert.IsTrue(component1 == registry[component1.EntityID] &&
                component2 == registry[component2.EntityID] &&
                component3 == registry[component3.EntityID] &&
                component4 == registry[component4.EntityID]);
        }

        /// <summary>
        /// Test contains.
        /// Expected result is true.
        /// </summary>
        [Test]
        public void Contains_ShouldBeTrue()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Assert.
            Assert.IsTrue(registry.Contains(component1.EntityID) &&
                registry.Contains(component2.EntityID) &&
                registry.Contains(component3.EntityID) &&
                registry.Contains(component4.EntityID));
        }

        /// <summary>
        /// Test contains.
        /// Expected result is false.
        /// </summary>
        [Test]
        public void Contains_ShouldBeFalse()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Assert.
            Assert.IsFalse(registry.Contains(5));
        }

        /// <summary>
        /// Test count.
        /// Expected result is 4.
        /// </summary>
        [Test]
        public void Count_ShouldBe4()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Assert.
            Assert.IsTrue(registry.Count == 4);
        }

        /// <summary>
        /// Test for removing a component from the registry.
        /// </summary>
        [Test]
        public void Remove()
        {
            // Arrange.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);

            // Act.
            registry.Remove(component3.EntityID);

            // Assert.
            Assert.IsTrue(registry.Count == 3 && !registry.Contains(component3.EntityID));
        }
    }
}
