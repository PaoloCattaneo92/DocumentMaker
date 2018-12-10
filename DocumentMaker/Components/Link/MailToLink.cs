using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class renders a "mailto:" link.
    /// </summary>
    /// <remarks>
    /// This will be rendered as HTML text even in MarkDown rendering.
    /// </remarks>
    public class MailToLink : DocLink
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="link">The main link</param>
        public MailToLink(string link) : base(link)
        {
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="link">The main link</param>
        /// <param name="text">The text that will be shown</param>
        public MailToLink(string link, string text) : base(link, text)
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
            return sb.Append(string.Format(DocumentMakerConstants.LINK_MAILTO, MainLink, Text));
        }
    }
}
