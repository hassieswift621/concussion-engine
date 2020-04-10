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
    /// World manager tests.
    /// </summary>
    [TestFixture]
    public partial class WorldManagerTest
    {
        /// <summary>
        /// Tests the adding of a world.
        /// </summary>
        [Test]
        public void AddWorld()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            IWorld world = new MockWorld(1, null, null);

            // Act.
            worldManager.AddWorld(world);

            // Assert.
            Assert.Pass();
        }

        /// <summary>
        /// Tests the retrieval of a world.
        /// </summary>
        [Test]
        public void GetWorld()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            IWorld world = new MockWorld(1, null, null);

            // Act.
            worldManager.AddWorld(world);

            // Assert.
            Assert.IsTrue(worldManager.GetWorld(1) == world);
        }

        /// <summary>
        /// Tests the retrieval of worlds in a specific state.
        /// </summary>
        [Test]
        public void GetWorldsInState()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            IWorld world1 = new MockWorld(1, null, null);
            IWorld world2 = new MockWorld(2, null, null);
            IWorld world3 = new MockWorld(3, null, null);

            // Act.
            worldManager.AddWorld(world1);
            worldManager.RunWorld(1);
            worldManager.AddWorld(world2);
            worldManager.RunWorld(2);
            worldManager.AddWorld(world3);

            IReadOnlyList<IWorld> worlds = worldManager.GetWorldsInState(WorldState.Running);

            // Assert.
            Assert.IsTrue(worlds.Count == 2 && worlds.Contains(world1) && worlds.Contains(world2));
        }

        /// <summary>
        /// Tests the pausing of a world.
        /// </summary>
        [Test]
        public void PauseWorld()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            AbstractWorld world = new MockWorld(1, null, null);
            worldManager.AddWorld(world);

            // Act.
            worldManager.PauseWorld(1);

            // Assert.
            Assert.IsTrue(world.State == WorldState.Paused);
        }

        /// <summary>
        /// Tests the running of a world.
        /// </summary>
        [Test]
        public void RunWorld()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            AbstractWorld world = new MockWorld(1, null, null);
            worldManager.AddWorld(world);

            // Act.
            worldManager.RunWorld(1);

            // Assert.
            Assert.IsTrue(world.State == WorldState.Running);
        }

        /// <summary>
        /// Tests the stopping of a world.
        /// </summary>
        [Test]
        public void StopWorld()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            AbstractWorld world = new MockWorld(1, null, null);
            worldManager.AddWorld(world);
            worldManager.RunWorld(1);

            // Act.
            worldManager.StopWorld(1, false);

            // Assert.
            Assert.IsTrue(world.State == WorldState.Stopped);
        }

        /// <summary>
        /// Tests the resetting of a world.
        /// </summary>
        [Test]
        public void StopWorld_Reset()
        {
            // Arrange.
            IWorldManager worldManager = new WorldManager();
            AbstractWorld world = new MockWorld(1, null, null);
            worldManager.AddWorld(world);
            worldManager.RunWorld(1);

            // Act.
            worldManager.StopWorld(1, true);

            // Assert.
            Assert.IsTrue(world.State == WorldState.None);
        }
    }
}
