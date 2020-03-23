using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.System
{
    /// <summary>
    /// The engine manages the operation of all subsystems for the game.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// The default MonoGame content manager.
        /// </summary>
        ContentManager ContentManager { get; }

        /// <summary>
        /// The screen height of the game window.
        /// </summary>
        int ScreenHeight { get; }

        /// <summary>
        /// The screen width of the game window.
        /// </summary>
        int ScreenWidth { get; }

        /// <summary>
        /// The MonoGame service provider.
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Exits the game.
        /// </summary>
        void Exit();

        /// <summary>
        /// Registers an engine subsystem.
        /// </summary>
        /// <param name="system">The subsystem to register.</param>
        void RegisterSystem(ISystem system);

        /// <summary>
        /// Unregisters an engine subsystem.
        /// </summary>
        /// <param name="system">The subsystem to unregister.</param>
        void UnregisterSystem(ISystem system);
    }
}
