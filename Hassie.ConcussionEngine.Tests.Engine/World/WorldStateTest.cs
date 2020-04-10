using Hassie.ConcussionEngine.Engine.World;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.World
{
    /// <summary>
    /// World state tests.
    /// </summary>
    [TestFixture]
    public class WorldStateTest
    {
        private IWorldState worldState;

        /// <summary>
        /// Sets up the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialise world.
            worldState = new MockWorld(1, null, null);
        }

        /// <summary>
        /// Tests the pausing of a world.
        /// </summary>
        [Test]
        public void Pause()
        {
            // Act.
            worldState.Pause();

            // Assert.
            Assert.IsTrue(worldState.State == WorldState.Paused);
        }

        /// <summary>
        /// Tests the running of a world.
        /// </summary>
        [Test]
        public void Run()
        {
            // Act.
            worldState.Run();

            // Assert.
            Assert.IsTrue(worldState.State == WorldState.Running);
        }

        /// <summary>
        /// Tests the stopping of a world.
        /// </summary>
        [Test]
        public void Stop()
        {
            // Act.
            worldState.Stop(false);

            // Assert.
            Assert.IsTrue(worldState.State == WorldState.Stopped);
        }

        /// <summary>
        /// Tests the resetting of a world.
        /// </summary>
        [Test]
        public void Stop_Reset()
        {
            // Act.
            worldState.Stop(true);

            // Assert.
            Assert.IsTrue(worldState.State == WorldState.None);
        }
    }
}
