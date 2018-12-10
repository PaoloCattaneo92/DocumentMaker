using PaoloCattaneo.DocumentMaker;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// A <see cref="Table"/> which autom-maps Objects in rows writing property values
    /// in columns. Property names are put in the header of the table
    /// </summary>
    /// <typeparam name="E">The type of the Object to be parsed</typeparam>
    public class TableAutoMap<E> : Table
    {
        /// <summary>
        /// The array of the properties of the parsed object
        /// </summary>
        protected PropertyInfo[] ContentProperties;

        /// <summary>
        /// Constructor. Builds the Table but you still have to set content
        /// with <see cref="SetContent(E[])"/>
        /// </summary>
        /// <param name="rows"><see cref="Table.Rows"/></param>
        /// <param name="cols"><see cref="Table.Columns"/></param>
        public TableAutoMap(int rows, int cols) : base(rows, cols)
        {
        }
        /// <summary>
        /// Constructor. Builds the Table and fill its with content
        /// </summary>
        /// <param name="contentElements">An array of objects that will be set as content</param>
        public TableAutoMap(params E[] contentElements)
        {
            if (contentElements != null && contentElements.Length > 0)
            {
                ContentProperties = typeof(E).GetProperties();
                Init(contentElements.Length, ContentProperties.Length);
                SetHeaders(GetHeadings());
                SetContent(contentElements);
            }
        }
        /// <summary>
        /// Get the headers from the property names
        /// </summary>
        /// <returns>An array of string with the name of the properties for <see cref="E"/></returns>
        protected string[] GetHeadings()
        {
            var headings = new string[ContentProperties.Length];
            for (int i = 0; i < ContentProperties.Length; i++)
            {
                headings[i] = ContentProperties[i].Name;
            }
            return headings;
        }
        /// <summary>
        /// Set an array of Objects as the content for this table
        /// </summary>
        /// <param name="contentElements">An array of objects</param>
        public void SetContent(params E[] contentElements)
        {
            for (int e = 0; e < contentElements.Length; e++)
            {
                for (int p = 0; p < ContentProperties.Length; p++)
                {
                    SetCell(p, e, contentElements[e].GetType().GetProperty(ContentProperties[p].Name).GetValue(contentElements[e]).ToString());
                }
            }
        }
    }
}
