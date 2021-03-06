﻿using Hassie.ConcussionEngine.Engine.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hassie.ConcussionEngine.MegaPong
{
    /// <summary>
    /// The render logger logs the total elapsed time every time the game is rendered.
    /// After 15 seconds, the logs are outputted and the game is exited.
    /// </summary>
    public class RenderLogger
    {
        private readonly IEngine engine; // The engine.
        private readonly IList<string> logs; // Total elapsed time logs.

        private Stopwatch stopwatch; // The stopwatch used for timing.

        /// <summary>
        /// Initialises a new instance of the render logger.
        /// </summary>
        /// <param name="engine"></param>
        public RenderLogger(IEngine engine)
        {
            // Store engine.
            this.engine = engine;

            // Initialise logs list.
            logs = new List<string>();
        }

        /// <summary>
        /// Logs the total elapsed time.
        /// If time is >= 15 seconds since first render,
        /// the logs are outputted and the game exits.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Log(GameTime gameTime)
        {
            // Initialise stopwatch if null.
            if (stopwatch == null)
            {
                stopwatch = Stopwatch.StartNew();
            }

            if (stopwatch.Elapsed.TotalSeconds >= 15)
            {
                System.IO.File.WriteAllLines("render_log.txt", logs);

                engine.Exit();
            }

            // Log.
            logs.Add(gameTime.TotalGameTime.TotalMilliseconds.ToString());
        }
    }
}
