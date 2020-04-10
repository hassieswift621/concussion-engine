using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Event
{
    /// <summary>
    /// Mock event args.
    /// </summary>
    public class MockEvent : EventArgs
    {
        public int Value { get; set; }
    }
}
