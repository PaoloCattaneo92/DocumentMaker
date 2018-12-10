using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This List renders as a numeric list
    /// </summary>
    /// <example>
    /// If the items are ["first", "second", "third"] it renders as
    /// 1. first
    /// 2. second
    /// 3. third
    /// </example>
    public class NumberList : DocList
    {
        /// <summary>
        /// Constructor. Initialize an empty list
        /// </summary>
        public NumberList() : base()
        {
        }
        /// <summary>
        /// Constructor. Initialize the list with
        /// the given parameter
        /// </summary>
        /// <param name="items">First items of the list</param>
        public NumberList(params string[] items) : base(items)
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
            int num = 1;
            foreach (string item in Items)
            {
                sb.Append(num++).Append(". ").Append(item).Append("\n");
            }
            return sb;
        }
    }
}