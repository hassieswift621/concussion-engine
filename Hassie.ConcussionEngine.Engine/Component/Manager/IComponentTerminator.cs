using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Manager
{
    /// <summary>
    /// A component terminator destroys an entity by removing all of its components.
    /// </summary>
    public interface IComponentTerminator
    {
        /// <summary>
        /// Terminates an entity.
        /// </summary>
        /// <param name="entityID">The ID of th entity.</param>
        void TerminateEntity(int entityID);
    }
}
