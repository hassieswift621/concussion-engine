using Hassie.ConcussionEngine.Engine.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Pong.Component.Data
{
    /// <summary>
    /// Component to store renderable text.
    /// </summary>
    public struct TextRenderComponent : IComponent
    {
        /// <summary>
        /// The colour to use to render the text.
        /// </summary>
        public Color Colour { get; set; }

        public int EntityID { get; }

        /// <summary>
        /// The font to use to render the text.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// The text to render.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initialises a new instance of the text render component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="colour">The colour to use to render the text.</param>
        /// <param name="font">The font to use to render the text.</param>
        /// <param name="text">The text to render.</param>
        public TextRenderComponent(int entityID, Color colour, SpriteFont font, string text)
        {
            EntityID = entityID;
            Colour = colour;
            Font = font;
            Text = text;
        }
    }
}
