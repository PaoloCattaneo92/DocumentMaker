using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class renders a link
    /// </summary>
    public class DocLink : RenderedObj
    {
        /// <summary>
        /// Destination link
        /// </summary>
        public string MainLink { get; set; }
        /// <summary>
        /// Text to show
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Title of the link
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor. Set all values.
        /// </summary>
        /// <param name="link"><see cref="MainLink"/></param>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="title"><see cref="Title"/></param>
        public DocLink(string link, string text, string title)
        {
            MainLink = link;
            Text = text;
            Title = title;
        }
        /// <summary>
        /// Constructor. Title of the link is null.
        /// </summary>
        /// <param name="link"><see cref="MainLink"/></param>
        /// <param name="text"><see cref="Text"/></param>
        public DocLink(string link, string text) : this(link, text, null)
        {
        }
        /// <summary>
        /// Constructor. Text will be the same of link.
        /// </summary>
        /// <param name="link"><see cref="MainLink"/></param>
        public DocLink(string link) : this(link, link, null)
        {
        }
        /// <summary>
        /// Constructor. This will link to a <see cref="Section"/>
        /// </summary>
        /// <param name="section">This <see cref="Section"/> will be the <see cref="MainLink"/></param>
        /// <param name="text"><see cref="Text"/></param>
        public DocLink(Section section, string text) : this(DocumentMakerConstants.HEADING_CHAR + section.HeaderTitle.Replace(' ', '-'), text)
        {
        }

        /// <summary>
        /// Constructor. This will link to a <see cref="Section"/>
        /// using her <see cref="Section.HeaderTitle"/> as <see cref="Text"/>
        /// </summary>
        /// <param name="section"></param>
        public DocLink(Section section) : this(section, section.HeaderTitle)
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
            sb.Append(DocumentMakerConstants.LINKTEXT_OPEN).Append(Text).Append(DocumentMakerConstants.LINKTEXT_CLOSE);
            sb.Append(DocumentMakerConstants.LINK_OPEN).Append(MainLink).Append(DocumentMakerConstants.LINK_CLOSE);
            if (Title != null)
            {
                sb.Append(DocumentMakerConstants.COMMAS).Append(Title).Append(DocumentMakerConstants.COMMAS);
            }
            return sb;
        }
    }
}
