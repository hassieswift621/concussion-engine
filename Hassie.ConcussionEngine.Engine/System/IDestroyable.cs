﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.System
{
    /// <summary>
    /// Provides a method for an engine system to clean up.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Destroys the engine system.
        /// </summary>
        void Destroy();
    }
}
