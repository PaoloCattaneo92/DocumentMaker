using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class renders tables in MD
    /// </summary>
    public class Table : RenderedObj
    {
        protected static readonly string COL_SEP = "|";
        protected static readonly string ALIGN = ":";
        protected static readonly string LINE = "---";

        /// <summary>
        /// This <see cref="IRenderable"/> object will be rendered
        /// if the the Table does not have content.
        /// You can modify it.
        /// </summary>
        public IRenderable NoContentRenderable { get; set; } = new Paragraph("This table is empty");

        /// <summary>
        /// Matrix of string with all the contents of the cells
        /// </summary>
        public string[,] ContentMatrix { get; protected set; }
        /// <summary>
        /// Number of rows of the table (of real content, headers are not included)
        /// </summary>
        public int Rows { get; protected set; }
        /// <summary>
        /// Number of columns of the table
        /// </summary>
        public int Columns { get; protected set; }
        /// <summary>
        /// All alignments (one fore each column)
        /// </summary>
        public TableAlignment[] Alignments { get; protected set; }
        /// <summary>
        /// Constructor. Initialize the table with its (fixed) dimensions.
        /// Note: the values are for effective content (headers are automatically added)
        /// </summary>
        /// <param name="rows"><see cref="Rows"/></param>
        /// <param name="cols"><see cref="Columns"/></param>
        public Table(int rows, int cols)
        {
            if(rows > 0)
            {
                Init(rows, cols);
            }
        }
        /// <summary>
        /// Default constructor for derived classes.
        /// </summary>
        protected Table()
        {
        }
        /// <summary>
        /// Initialize the table with the given rows and columns
        /// </summary>
        /// <param name="rows"><see cref="Rows"/></param>
        /// <param name="cols"><see cref="Columns"/></param>
        protected void Init(int rows, int cols)
        {
            Rows = rows + 2;
            Columns = cols;
            ContentMatrix = new string[Rows, Columns];
            Alignments = new TableAlignment[Columns];
        }
        /// <summary>
        /// Utility method
        /// </summary>
        /// <param name="contents">Array of Objects</param>
        /// <returns>Array of strings</returns>
        protected string[] ObjArrToStringArr(params Object[] contents)
        {
            var strings = new string[contents.Length];
            int i = 0;
            contents.ToList().ForEach(x => strings[i++] = x.ToString());
            return strings;
        }
        /// <summary>
        /// Utility method
        /// </summary>
        /// <param name="contents">Array of IRenderable</param>
        /// <returns>Array of rendered strings</returns>
        protected string[] IRenderableArrToStringArr(params IRenderable[] contents)
        {
            var strings = new string[contents.Length];
            int i = 0;
            contents.ToList().ForEach(x => strings[i++] = x.Render());
            return strings;
        }
        /// <summary>
        /// Set the alignment for the indexed column
        /// </summary>
        /// <param name="col">The column which the alignment is set</param>
        /// <param name="tableAlignment">Its new <see cref="TableAlignment"/></param>
        public void SetAlignement(int col, TableAlignment tableAlignment)
        {
            Alignments[col] = tableAlignment;
        }
        /// <summary>
        /// Set <see cref="Alignments"/>
        /// </summary>
        /// <param name="tableAlignments">New value for <see cref="Alignments"/></param>
        public void SetAlignement(TableAlignment[] tableAlignments)
        {
            for (int c = 0; c < Columns; c++)
            {
                Alignments[c] = tableAlignments[c];
            }
        }
        /// <summary>
        /// Set <see cref="Alignments"/> all with the same value
        /// </summary>
        /// <param name="tableAlignment">New value for all <see cref="Alignments"/></param>
        public void SetAlignement(TableAlignment tableAlignment)
        {
            for (int c = 0; c < Columns; c++)
            {
                Alignments[c] = tableAlignment;
            }
        }
        /// <summary>
        /// Set headers for the table
        /// </summary>
        /// <param name="headings">Array of strings with the headers</param>
        public void SetHeaders(params string[] headings)
        {
            try
            {
                for (int c = 0; c < Columns; c++)
                {
                    ContentMatrix[0, c] = headings[c];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Set the content for the given row
        /// </summary>
        /// <param name="row">Row to set content</param>
        /// <param name="contents">Content to set</param>
        public void SetRow(int row, params string[] contents)
        {
            try
            {
                for (int col = 0; col < Columns; col++)
                {
                    ContentMatrix[row + 2, col] = contents[col];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Set the content for the given row
        /// </summary>
        /// <param name="row">Row to set content</param>
        /// <param name="contents">Content to set (every Object will be "ToString()-ed"</param>
        public void SetRow(int row, params Object[] contents)
        {
            SetRow(row, ObjArrToStringArr(contents));
        }

        /// <summary>
        /// Set the content for the given row
        /// </summary>
        /// <param name="row">Row to set content</param>
        /// <param name="contents">Content to set</param>
        public void SetRow(int row, params IRenderable[] contents)
        {
            SetRow(row, IRenderableArrToStringArr(contents));
        }
        /// <summary>
        /// Set the content for the given column
        /// </summary>
        /// <param name="col">Column to set content</param>
        /// <param name="contents">Content to set</param>
        public void SetCol(int col, params string[] contents)
        {
            try
            {
                for (int row = 2; row < Rows; row++)
                {
                    ContentMatrix[row, col] = contents[row - 1];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Set the content for the given column
        /// </summary>
        /// <param name="col">Row to set content</param>
        /// <param name="contents">Content to set (every Object will be "ToString()-ed"</param>
        public void SetCol(int col, params Object[] contents)
        {
            SetCol(col, ObjArrToStringArr(contents));
        }
        /// <summary>
        /// Set the content for the given row
        /// </summary>
        /// <param name="row">Row to set content</param>
        /// <param name="contents">Content to set</param>
        public void SetCol(int row, params IRenderable[] contents)
        {
            SetCol(row, IRenderableArrToStringArr(contents));
        }

        /// <summary>
        /// Set the content for the given cell (at row and column)
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="col">Column of the cell</param>
        /// <param name="content">New content of the cell</param>
        public void SetCell(int row, int col, string content)
        {
            try
            {
                ContentMatrix[row + 2, col] = content;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Set the content for the given cell (at row and column)
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="col">Column of the cell</param>
        /// <param name="content">New content of the cell (Object will be "ToString()-ed")</param>
        public void SetCell(int row, int col, Object content)
        {
            SetCell(row, col, content.ToString());
        }

        /// <summary>
        /// Set the content for the given cell (at row and column)
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="col">Column of the cell</param>
        /// <param name="renderableContent">New content of the cell (will be rendered on set)</param>
        public void SetCell(int row, int col, IRenderable renderableContent)
        {
            try
            {
                SetCell(row, col, renderableContent.Render());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Renders the alignment for the table
        /// </summary>
        protected void RenderAlignment()
        {
            for (int col = 0; col < Columns; col++)
            {
                switch (Alignments[col])
                {
                    case TableAlignment.LEFT:
                        {
                            ContentMatrix[1, col] = ALIGN + LINE;
                            break;
                        }
                    case TableAlignment.CENTER:
                        {
                            ContentMatrix[1, col] = ALIGN + LINE + ALIGN;
                            break;
                        }
                    case TableAlignment.RIGHT:
                        {
                            ContentMatrix[1, col] = LINE + ALIGN;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Append the rendered content of this <see cref="RenderedObj"/>
        /// to the given StringBuilder.
        /// </summary>
        /// <param name="sb">The StringBuilder where the rendered content will be appended</param>
        /// <returns>The same StringBuilder but with this content appendend</returns>
        public override StringBuilder Render(StringBuilder sb)
        {
            if (ContentMatrix != null)
            {
                RenderAlignment();
                sb.Append("\n");
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Columns; col++)
                    {
                        sb.Append(ContentMatrix[row, col]);
                        if (col < Columns - 1)
                        {
                            sb.Append(COL_SEP);
                        }
                    }
                    sb.Append("\n");
                }
                sb.Append("\n\n");
            }
            else
            {
                sb.Append(NoContentRenderable?.Render());
            }
            return sb;
        }
    }
}