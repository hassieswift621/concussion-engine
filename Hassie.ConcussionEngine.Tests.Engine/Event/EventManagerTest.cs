using Hassie.ConcussionEngine.Engine.Event;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Event
{
    /// <summary>
    /// Event manager tests.
    /// </summary>
    [TestFixture]
    public class EventManagerTest
    {
        /// <summary>
        /// Subscribe event listener test.
        /// </summary>
        [Test]
        public void Subscribe()
        {
            // Arrange.
            IEventManager eventManager = new EventManager();
            MockEventListener eventListener = new MockEventListener();

            // Act.
            eventManager.Subscribe<MockEvent>(eventListener.OnEvent);

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Unsubscribe event listener test.
        /// </summary>
        [Test]
        public void Unsubscribe()
        {
            // Arrange.
            IEventManager eventManager = new EventManager();
            MockEventListenerFail eventListener = new MockEventListenerFail();
            eventManager.Subscribe<MockEvent>(eventListener.OnEvent);

            // Act.
            eventManager.Unsubscribe<MockEvent>(eventListener.OnEvent);
            eventManager.Emit(new MockEvent());
        }

        /// <summary>
        /// Emit event test.
        /// </summary>
        [Test]
        public void Emit()
        {
            // Arrange.
            IEventManager eventManager = new EventManager();
            MockEventListener eventListener = new MockEventListener();
            eventManager.Subscribe<MockEvent>(eventListener.OnEvent);

            // Act.
            eventManager.Emit(new MockEvent()
            {
                Value = 500
            });
        }
    }
}
