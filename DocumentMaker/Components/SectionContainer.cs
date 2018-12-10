using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This abstract class implement something <see cref="IRenderable"/>
    /// that contains nested sections.
    /// </summary>
    public abstract class SectionContainer : RenderedObj
    {
        /// <summary>
        /// List of nested sections
        /// </summary>
        public List<Section> Sections { get; set; }

        /// <summary>
        /// Content, as a list of renderable items
        /// </summary>
        public List<IRenderable> Content { get; set; }

        /// <summary>
        /// Constructor. Creates an empty list of Sections.
        /// </summary>
        protected SectionContainer()
        {
            Sections = new List<Section>();
            Content = new List<IRenderable>();
        }
        
        /// <summary>
        /// Add a section to <see cref="Sections"/>
        /// </summary>
        /// <param name="section">A section to add</param>
        public SectionContainer AddSection(Section section)
        {
            Sections.Add(section);
            return this;
        }

        public override StringBuilder Render(StringBuilder sb)
        {
            foreach(Section section in Sections)
            {
                sb = section.Render(sb);
            }
            return sb;
        }

        /// <summary>
        /// Add a string as paragraph.
        /// </summary>
        /// <param name="paragraph">Paragraph to add</param>
        public void AddParagraph(string paragraph)
        {
            Content.Add(new Paragraph(paragraph));
        }
        public void AddParagraph()
        {
            AddParagraph("");
        }
        /// <summary>
        /// Add all the lines of a text file to a paragraph.
        /// </summary>
        /// <param name="file">The file containing the paragraph</param>
        public void AddParagraph(FileInfo file)
        {
            AddParagraph(File.ReadAllText(file.FullName));
        }

        /// <summary>
        /// Add a <see cref="IRenderable"/> object to the text
        /// </summary>
        /// <param name="renderable">An object that can be rendered</param>
        public void Add(IRenderable renderable)
        {
            Content.Add(renderable);
        }

        /// <summary>
        /// Add a quote to the text
        /// </summary>
        /// <param name="quoteText">A quote</param>
        public void AddQuote(string quoteText)
        {
            AddParagraph(DocumentMakerConstants.QUOTE + quoteText);
        }
        /// <summary>
        /// Add an horizontal line into the text
        /// </summary>
        public void AddHr()
        {
            Content.Add(new ThematicBreakHR());
        }


    }
}

