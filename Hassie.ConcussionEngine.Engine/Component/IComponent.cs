using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component
{
    /// <summary>
    /// The base interface for all components.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// The ID of the entity.
        /// </summary>
        int EntityID { get; }
    }
}
