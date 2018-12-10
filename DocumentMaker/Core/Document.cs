using System.Collections.Generic;
using System.Text;
using System.IO;
using Markdig;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Main class of the DocumentMaker. Assemble this in order to create a .md document
    /// and eventually its rendered .html document.
    /// </summary>
    /// <example>
    /// Check the project "DocumentMakerExample" program for a full example of how to use this library
    /// </example>
    public class Document : SectionContainer
    {

        private string cssStyle;
        private bool extraEmphasis;
        private bool taskList;
        private bool extraList;
        private bool tables;
        private bool math;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Document() : base()
        {
        }

        /// <summary>
        /// Enable the Math component of MDEditor.
        /// </summary>
        /// <returns>A MDEditor able to render Math formulas (with <see cref="MATH"/>)</returns>
        public Document EnableMath()
        {
            math = true;
            return this;
        }
        /// <summary>
        /// Enable the Extra-Emphasis component of MDEditor.
        /// </summary>
        /// <returns>A MDEditor with the Extra-Emphasis component enabled</returns>
        public Document EnableExtraEmphasis()
        {
            extraEmphasis = true;
            return this;
        }
        /// <summary>
        /// Enable the TaskList (<see cref="TaskList"/>)
        /// </summary>
        /// <returns>A MDEditor able to render TaskLists</returns>
        public Document EnableTaskList()
        {
            taskList = true;
            return this;
        }
        /// <summary>
        /// Enable the ExtraLists (<see cref="RomanList"/> and <see cref="LetterList"/>)
        /// </summary>
        /// <returns>A MDEditor able to render various types of Lists</returns>
        public Document EnableExtraList()
        {
            extraList = true;
            taskList = true;
            return this;
        }
        /// <summary>
        /// Enable the Table (<see cref="Table"/>) renderer.
        /// </summary>
        /// <returns>A MDEditor able to render Tables</returns>
        public Document EnableTable()
        {
            tables = true;
            return this;
        }
        /// <summary>
        /// Set the CSS of the final HTML file.
        /// </summary>
        /// <param name="cssPath">Absolute path of the CSS file with the wanted style</param>
        /// <param name="embedded">If true, the whole CSS file will be written into the HTML file, if false
        /// it will only contain the absolute path of the CSS file</param>
        public void SetCss(FileInfo cssPath, bool embedded)
        {
            if (embedded)
            {
                cssStyle = string.Format(DocumentMakerConstants.SET_CSS_EMBEDDED, File.ReadAllText(cssPath.FullName));
            }
            else
            {
                cssStyle = string.Format(DocumentMakerConstants.SET_CSS_NOT_EMBEDDED, File.ReadAllText(cssPath.FullName));
            }
        }

        /// <summary>
        /// Set the CSS of the final HTML file.
        /// All the string containing the CSS style will be embedded in the final HTML file.
        /// </summary>
        /// <param name="cssString">A string containing some cssStyle</param>
        public void SetCss(string cssString)
        {
            cssStyle = string.Format(DocumentMakerConstants.SET_CSS_EMBEDDED, cssString);
        }

        public override StringBuilder Render(StringBuilder sb)
        {
            //Style first
            sb.Append(cssStyle).Append("\n\n");
            //Main document content
            foreach(IRenderable renderable in Content)
            {
                sb = renderable.Render(sb);
            }
            //Subsections rendering
            foreach (Section section in Sections)
            {
                sb = section.Render(sb);
            }
            return sb;
        }

        /// <summary>
        /// Render all the sections contained in the document
        /// into HTML format
        /// </summary>
        /// <param name="mdString">The string in MD format to transform in HTML</param>
        /// <returns>A string with the whole HTML document</returns>
        public string RenderToHtml(string mdString)
        {
            var pipeline = new MarkdownPipelineBuilder();
            if (extraEmphasis)
                pipeline = pipeline.UseEmphasisExtras();
            if (extraList)
                pipeline = pipeline.UseListExtras();
            if (taskList)
                pipeline = pipeline.UseTaskLists();
            if (tables)
                pipeline = pipeline.UsePipeTables();
            if (math)
                pipeline = pipeline.UseMathematics();

            return Markdown.ToHtml(mdString, pipeline.Build());
        }
        /// <summary>
        /// Render all the sections contained in the document
        /// into HTML format
        /// </summary>
        /// <returns>A string with the whole HTML document</returns>
        public string RenderToHtml()
        {
            return RenderToHtml(Render());
        }
        /// <summary>
        /// Render all the sections contained in the document
        /// in MD format
        /// and write them into a file
        /// </summary>
        /// <param name="fileName">The name of the output File (.md)</param>
        public void RenderToMdFile(string fileName)
        {
            File.WriteAllText(fileName, Render());
        }
        /// <summary>
        /// Render all the sections contained in the document
        /// in HTML format
        /// and write them into a file
        /// </summary>
        /// <param name="fileName">The name of the output File (.html)</param>
        public void RenderToHtmlFile(string fileName)
        {
            File.WriteAllText(fileName, RenderToHtml(Render()));
        }
    }
}
