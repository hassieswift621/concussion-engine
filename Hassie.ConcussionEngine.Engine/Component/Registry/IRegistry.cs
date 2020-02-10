using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Registry
{
    /// <summary>
    /// A registry stores a set of data objects for a specific type.
    /// </summary>
    public interface IRegistry
    {
        /// <summary>
        /// The number of elements in the registry.
        /// </summary>
        int Count { get; }
    }
}
