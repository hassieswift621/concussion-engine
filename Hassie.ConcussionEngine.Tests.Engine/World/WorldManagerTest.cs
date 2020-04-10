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
    }
}
