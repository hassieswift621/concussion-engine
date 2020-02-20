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
    [TestFixture]
    public class Texture2DRenderCRTest
    {
        private Texture2DRenderCR registry;
        private Texture2DRenderComponent component1;
        private Texture2DRenderComponent component2;
        private Texture2DRenderComponent component3;
        private Texture2DRenderComponent component4;
        private Texture2DRenderComponent component5;
        private Texture2DRenderComponent component6;

        /// <summary>
        /// Sets up the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialise registry.
            registry = new Texture2DRenderCR();

            // Initialise components.
            component1 = new Texture2DRenderComponent(40, 5, null);
            component2 = new Texture2DRenderComponent(600, 60, null);
            component3 = new Texture2DRenderComponent(435, 35, null);
            component4 = new Texture2DRenderComponent(143, 60, null);
            component5 = new Texture2DRenderComponent(369, 20, null);
            component6 = new Texture2DRenderComponent(3, 35, null);
        }

        /// <summary>
        /// Tests the adding of components to the registry.
        /// </summary>
        [Test]
        public void Add()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Tests the adding of components to the registry, ensuring they are
        /// stored in order by their render order.
        /// </summary>
        [Test]
        public void Add_ShouldBeOrderedByRenderOrder()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            int lastRenderOrder = -1;
            foreach (Texture2DRenderComponent component in registry)
            {
                if (component.RenderOrder < lastRenderOrder)
                {
                    Assert.Fail();
                }
                lastRenderOrder = component.RenderOrder;
            }
            Assert.Pass();
        }

        /// <summary>
        /// Test for getting components from the registry by entity ID.
        /// </summary>
        [Test]
        public void Get()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            Assert.IsTrue(component1 == registry.Get(component1.EntityID) &&
                component2 == registry.Get(component2.EntityID) &&
                component3 == registry.Get(component3.EntityID) &&
                component4 == registry.Get(component4.EntityID) &&
                component5 == registry.Get(component5.EntityID) &&
                component6 == registry.Get(component6.EntityID));
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
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            Assert.IsTrue(registry.Contains(component1.EntityID) &&
                registry.Contains(component2.EntityID) &&
                registry.Contains(component3.EntityID) &&
                registry.Contains(component4.EntityID) &&
                registry.Contains(component5.EntityID) &&
                registry.Contains(component6.EntityID));
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
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            Assert.IsFalse(registry.Contains(5));
        }

        /// <summary>
        /// Test count.
        /// Expected result is 6.
        /// </summary>
        [Test]
        public void Count_ShouldBe6()
        {
            // Act.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);
            registry.Set(component5);
            registry.Set(component6);

            // Assert.
            Assert.IsTrue(registry.Count == 6);
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
            registry.Set(component5);
            registry.Set(component6);

            // Act.
            registry.Remove(component3.EntityID);

            // Assert.
            Assert.IsTrue(registry.Count == 5 && !registry.Contains(component3.EntityID));
        }

        /// <summary>
        /// Test for removing a component from the registry
        /// and ensuring the components are still in order,
        /// </summary>
        [Test]
        public void Remove_ShouldBeInOrder()
        {
            // Arrange.
            registry.Set(component1);
            registry.Set(component2);
            registry.Set(component3);
            registry.Set(component4);
            registry.Set(component5);
            registry.Set(component6);

            Texture2DRenderComponent[] orderedComponents = new Texture2DRenderComponent[] { 
                component1, component5, component6, component2, component4
            };

            // Act.
            registry.Remove(component3.EntityID);

            // Assert.
            for (int i = 0; i < registry.Count; i++)
            {
                if (registry[i].EntityID != orderedComponents[i].EntityID)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
    }
}
