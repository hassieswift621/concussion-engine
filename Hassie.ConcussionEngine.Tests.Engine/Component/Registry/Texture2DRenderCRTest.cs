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
    }
}
