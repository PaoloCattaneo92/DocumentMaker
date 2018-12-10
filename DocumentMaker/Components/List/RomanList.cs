using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// A list rendered with roman numbers style.
    /// </summary>
    /// <example>
    /// Renders as:
    /// I. first
    /// II. second
    /// III. third
    /// IV. fourth
    /// </example>
    public class RomanList : DocList
    {
        protected static readonly string[] ROMAN_VALS = {   "I", "II", "III", "IV", "V", "VI", "VII", "VIII" , "IX", "X" };

        /// <summary>
        /// Constructor. Initialize the list with the given parameter.
        /// </summary>
        /// <param name="items">First elements of the list</param>
        public RomanList(params string[] items) : base(items)
        {
        }

        /// <summary>
        /// Constructor. Initialize an empty list.
        /// </summary>
        public RomanList() : base()
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
            int i = 0;
            foreach (string item in Items)
            {
                sb.Append(ROMAN_VALS[i++]).Append(". ").Append(item).Append("\n");
                i = (i + 1) % ROMAN_VALS.Length;
            }
            return sb;
        }
    }
}
