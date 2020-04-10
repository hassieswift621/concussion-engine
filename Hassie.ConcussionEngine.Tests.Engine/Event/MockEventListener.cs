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
    /// Mock event listener.
    /// </summary>
    public class MockEventListener : IEventListener<MockEvent>
    {
        public void OnEvent(object sender, MockEvent args)
        {
            // Assert.
            Assert.AreEqual(args.Value, 500);
        }
    }
}
