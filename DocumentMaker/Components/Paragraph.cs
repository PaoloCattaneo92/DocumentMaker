using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class represents a simple HTML paragraph.
    /// </summary>
    public class Paragraph : RenderedObj
    {
        /// <summary>
        /// The plain text of the paragraph.
        /// </summary>
        public string BaseText { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text">The text contained into the paragraph.</param>
        public Paragraph(string text) : this()
        {
            BaseText = text;
        }
        /// <summary>
        /// Constructor.
        /// This does not set <see cref="BaseText"/>
        /// </summary>
        public Paragraph()
        {
        }
        /// <summary>
        /// Append the rendered content of this <see cref="RenderedObj"/>
        /// to the given StringBuilder.
        /// </summary>
        /// <param name="sb">The StringBuilder where the rendered content will be appended</param>
        /// <returns>The same StringBuilder but with this content appendend</returns>
        public override StringBuilder Render(StringBuilder sb)
        {
            return sb.Append(BaseText).Append(DocumentMakerConstants.DOUBLE_NEW_LINE);
        }
    }
}
