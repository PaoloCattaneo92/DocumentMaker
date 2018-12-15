using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class renders a DotList
    /// </summary>
    /// <example>
    /// If Items = ["a", "b", "c"], it will be rendered as:
    /// =>
    /// </example>
    public class DotList : DocList
    {
        protected static char ItemDot { get; } = '*';

        /// <summary>
        /// Constructor. Creates an empty List.
        /// </summary>
        public DotList() : base()
        {
        }
        /// <summary>
        /// Constructor. Initialize the List with the given string[]
        /// </summary>
        /// <param name="items">The initial values of the list</param>
        public DotList(params string[] items) : base(items)
        {
        }

        public override StringBuilder Render(StringBuilder sb)
        {
            foreach (string item in Items)
            {
                sb.Append(ItemDot).Append(" ").Append(item).Append(DocumentMakerConstants.NEW_LINE);
            }
            return sb;
        }
    }
}
